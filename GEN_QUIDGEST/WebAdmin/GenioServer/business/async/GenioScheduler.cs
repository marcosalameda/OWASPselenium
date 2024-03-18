using System;
using System.Collections.Generic;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;


namespace CSGenio.business.async
{
    using Unit = String;
    using Process = CSGenioAs_apr;    

    /// <summary>
    /// Class responsible for distributing jobs to every worker.
    /// It's a singleton class, only one instance can exist at a time.
    /// Be careful, every public method must deal with possible concurrency.
    /// </summary>
    public class SchedulerBroker
    {
        /// <summary>
        /// 
        /// </summary>
        private List<Process> process = new List<Process>(); //Beware, not all fields have data, check ObtainProcess()
        
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, List<Process>> allProcess = new Dictionary<string, List<Process>>();
        
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, DateTime> lastCheck;

        /// <summary>
        /// 
        /// </summary>
        private Object lockProcess = new Object();

        private GenioScheduler scheduler = new GenioScheduler();

        /// <summary>
        /// Finds the next process that can be executed and returns the corresponding job.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>A job to be executed or null if no work can be executed</returns>
        public IGenioWork GetWork(User user)
        {
            PersistentSupport sp = null;
            try
            {
                sp = PersistentSupport.getPersistentSupport(user.Year);
                sp.openTransaction();

                //If the scheduler is not working, no one gets new work.
                //CSGenioAglob glob = GlobalFunctions.SearchListUnique<CSGenioAglob>(sp, null, user, false);                
                //CSGenioAglob glob = null;

                lock (lockProcess)
                {
                    process = GetProcess(sp, user);
                                        
                    //if (glob.ValDesbloqu == 1)
                    KillUnresponsive(user);

                    if (CanWork() == false)
                    {
                        //If there is no work to be done, return null
                        return null;
                    }

                    GenioWork mostUrgent = scheduler.GetWork(process, sp, user);
                    if (mostUrgent != null)
                    {
                        //Se conseguirmos marcar o processo retornamos
                        GenioProcessManager manager = GenioProcessManager.PersistProcessManager(user);
                        if (manager.AllocateProcess(mostUrgent.Process))
                        {
                            return mostUrgent;
                        }
                        else
                        {
                            //Someone changed the state of the process being allocated.  We will simply return null;
                        }
                    }
                    sp.closeTransaction();
                    return null;
                }

            }
            catch (InvalidProcessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                sp.rollbackTransaction();
                //Se houver problemas damos exceção
                string message = Translations.Get("MSG_ERROR_OBTAIN_NEXT_PROCESS", user.Language);
                throw new BusinessException(message, "Scheduler.GetWork", ex.Message);
            }
            finally
            {
                sp.closeTransaction();
            }
        }

        private void KillUnresponsive(User user)
        {
            //var unit = MonitorUtils.GetTimeUnit(glob.ValDesblqun);
            var unit = MonitorUtils.GetTimeUnit("S");
            var manager = GenioProcessManager.PersistProcessManager(user);
                       
            //double val = glob.ValDesblqpr;
            double val = 120;
            if (Configuration.ExistsProperty("inactivitytime"))
                val = Conversion.string2Double(Configuration.GetProperty("inactivitytime"));

            foreach (var proc in process.Where(NotResponding))
            {
                var passedTime = DateTime.Now - proc.ValLastupdt;
                bool overtime = MonitorUtils.CompareTimeDiff(passedTime, val, unit);

                if (overtime)
                {
                    string msg = Translations.Get("MSG_ABORT_PROCESS_AUTO", user.Language);
                    int t = (int)MonitorUtils.GetUnitTimeSpan(unit, passedTime);
                    msg = string.Format(msg, t, MonitorUtils.GetTimeUnitAsString(unit));
                    //proc.ValUnblock = 1;
                    manager.AbortProcess(proc, msg);
                    manager.NotifyProcess(proc);
                }
            }
        }


        //Checks if the scheduler is turned on.
        private bool Shutdown()
        {
            string sched = Environment.GetEnvironmentVariable("Schedulerswith");
            if (sched == null)
                return false;

            return sched.Equals("off");
            //return glob.ValSchedoff == 1;
        }

        /// <summary>
        /// Validate if it is possible to continue work
        /// </summary>
        /// <param name="glob"></param>
        /// <returns></returns>
        /// private bool CanWork(CSGenioAglob glob)
        private bool CanWork()
        {
            //string concurrencyType = Environment.GetEnvironmentVariable("concurrencytype");
            string concurrencyType = null;

            if (Configuration.ExistsProperty("concurrencytype"))
                concurrencyType = Configuration.GetProperty("concurrencytype");
            
            if (concurrencyType != null)
            {
                if(concurrencyType == "L")
                {
                    int convertedMaxProc = 1;
                    //string maxprocess = Environment.GetEnvironmentVariable("maxprocess");
                    if (Configuration.ExistsProperty("maxprocess"))
                        convertedMaxProc = Conversion.string2Int(Configuration.GetProperty("maxprocess"));

                    int numProcessos = process.Count(IsExecuting);
                    if (numProcessos >= convertedMaxProc)
                        return false;
                    else
                        return true;
                }
                else if (concurrencyType == "I")
                {
                    return true;
                }
            }
            else
            {
                //Por defeito faz o caso de 'Apenas 1'
                return !process.Exists(IsExecuting);
            }

            //if (glob.ValConcorre == ArrayAconcorr.E_L_2)
            //{
            //    int numProcessos = process.Count(EmExecucao);
            //    if (numProcessos >= glob.ValMax_proc)
            //        return false;
            //    else
            //        return true;
            //}
            //else if (glob.ValConcorre == ArrayAconcorr.E_I_3)
            //{
            //    return true;
            //}
            //else
            //{
            //    //Por defeito faz o caso de 'Apenas 1'
            //    return !process.Exists(EmExecucao);
            //}
            return true;
        }

        /// <summary>
        /// Get the list of all valid/available process for execution
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private List<Process> GetProcess(PersistentSupport sp, User user)
        {
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, 500); // 0.5 seconds
            if (!lastCheck.ContainsKey(user.Year))
                lastCheck[user.Year] = DateTime.MinValue;

            if (DateTime.Now - lastCheck[user.Year] > duration)
            {
                List<Process> results = Process.searchList(sp, user,
                    CriteriaSet.And()
                        .Equal(Process.FldFinished, 0)
                        .Equal(Process.FldZzstate, 0)
                        .SubSet(CriteriaSet.NotAnd()
                            .Equal(Process.FldRtstatus, ArrayS_prstat.E_AC_8)
                            .Equal(Process.FldRtstatus, ArrayS_prstat.E_NR_6))
                        //Não count com processos em fila de espera que estão em manutenção 
                        //(os em execução têm de ser considerados to a concorrência)
                        //.SubSet(CriteriaSet.NotAnd()
                        //    .Equal(Process.FldStatus, ArrayS_prstat.E_FE_2)
                            //.Exists(new SelectQuery()
                            //    .Select(new SqlValue(1), "exists")
                            //    .From(CSGenioAprman.AreaPRMAN)
                            //    .Where(CriteriaSet.And()
                            //        .Equal(CSGenioAprman.FldTipoproc, CSGenioAlogp0.FldTipoproc)
                            //        .In(CSGenioAprman.FldModomanu, new string[] { ArrayAmanproc.E_E_2, ArrayAmanproc.E_AE_3 }))
                            //        )
                        //)
                    );

                lastCheck[user.Year] = DateTime.Now;
                allProcess[user.Year] = results;
                return results;
            }
            else
            {
                //Se não passou time suficente retornamos o que está em memoria.
                return allProcess[user.Year];
            }
        }

        private static bool IsWaiting(Process processo)
        {
            return processo.ValRtstatus == ArrayS_prstat.E_FE_2;
        }

        public static bool IsExecuting(Process processo)
        {
            return processo.ValRtstatus == ArrayS_prstat.E_AG_3 ||
                processo.ValRtstatus == ArrayS_prstat.E_EE_1 ||
                processo.ValRtstatus == ArrayS_prstat.E_AC_8;
        }

        private static bool NotResponding(Process processo)
        {
            return processo.ValRtstatus == ArrayS_prstat.E_NR_6;
        }

        /* Esta classe é Singleton, só pode haver uma instancia! */
        private static SchedulerBroker instance = null;
        private SchedulerBroker()
        {
            lastCheck = new Dictionary<string, DateTime>();
            process = new List<Process>();
        }

        public static SchedulerBroker GetBroker()
        {
            if (instance == null)
            {
                lock (typeof(SchedulerBroker))
                {
                    if (instance == null)
                        instance = new SchedulerBroker();
                }
            }

            return instance;
        }

        /// <summary>
        /// Indicates that a process has terminated successfully.
        /// </summary>
        /// <param name="processo">The terminated process</param>
        public void TerminatedProcess(Process processo)
        {
            lock (lockProcess)
            {
                //Finds a process in the cache and updates the state. No need to go to the DB.
                process.RemoveAll(x => x.ValCodascpr == processo.ValCodascpr);
            }
        }
    }

    public class GenioScheduler
    {
        private List<GenioWork> works = new List<GenioWork>();
        //private List<CSGenioAprman> inMaintenance = new List<CSGenioAprman>();


        public GenioWork GetWork(List<Process> processos, PersistentSupport sp, User user)
        {
            UpdateWorks(processos, sp, user);

            for (int i = 0; i < works.Count; i++)
            {
                //Se está em fila de espera tentamos subi-lo na lista de execução
                if (works[i].Process.ValRtstatus == ArrayS_prstat.E_FE_2 && works[i].FulfillRequirements(sp, user))
                {

                    for (int j = i - 1; ; j--)
                    {
                        if (j == -1)
                            //If evaluating the first process, that means it's executable right now.
                            return works[i];
                        else if (Collision(works[i].Job, works[j].Job, sp))
                            break;
                        else
                            //Move up the list, continue checking for collisions
                            continue;
                    }
                    //If it hasn't returned, this process cannot be executed. Move to next
                    continue;
                }
            }

            return null;
        }

        public bool Collision(GenioExecutableJob first, GenioExecutableJob second, PersistentSupport sp)
        {
            PartitionPolicy firstPolicy = first.GetPartitionPolicy(second);
            PartitionPolicy secondPolicy = second.GetPartitionPolicy(first);

            if (firstPolicy.IsGlobal || secondPolicy.IsGlobal)
            {
                return true;
            }
            else
            {
                List<Unit> firstList = firstPolicy.GetSubUnits(sp);
                List<Unit> secondList = secondPolicy.GetSubUnits(sp);
                return firstList.Intersect(secondList).Any();
            }            
        }

        private int OlderFirst(GenioWork first, GenioWork second)
        {
            if (first.Process.ValId > second.Process.ValId)
                return 1;
            else if (first.Process.ValId == second.Process.ValId)
                return 0;
            else
                return -1;
        }

        private int HighestPriority(GenioWork first, GenioWork second)
        {
            if (first.Priority > second.Priority)
                return 1;
            else if (first.Priority == second.Priority)
                return OlderFirst(first, second);
            else
                return -1;
        }

        private void UpdateWorks(List<Process> processos, PersistentSupport sp, User user)
        {
            //If a process isn't in the list it has finished. Remove it.
            var finished = works.Select(x => x.Process.ValCodascpr)
                .Except(processos.Select(x => x.ValCodascpr));
            if (finished.Count() > 0)
                works.RemoveAll(x => finished.Contains(x.Process.ValCodascpr));

            //Add new process and update existing ones
            JobFinder finder = new JobFinder();
            foreach (Process process in processos)
            {
                GenioWork existing = works.Find(x => x.Process.ValCodascpr == process.ValCodascpr);
                if (existing != null)
                {
                    if (existing.Process.ValExternal == 1 && existing.Process.ValRtstatus != process.ValRtstatus)
                    {
                        existing.Process.ValRtstatus = process.ValRtstatus;
                    }
                }
                else
                {
                    GenioExecutableJob job = finder.ObtainJob(process);
                    job.FillArguments(sp, user, process);
                    job.SetPartitionPolicies();
                    works.Add(new GenioWork(process, job));
                }
            }

            var executing = works.Where(w => SchedulerBroker.IsExecuting(w.Process));
            var notExecuting = works.Where(w => !SchedulerBroker.IsExecuting(w.Process)).ToList();
            notExecuting.Sort(HighestPriority);

            works = executing.Union(notExecuting).ToList();
        }
    }

    class InvalidProcessException : BusinessException
    {
        public InvalidProcessException(string message, string localErro, string causaErro)
            : base(message, localErro, causaErro)
        {
        }
    }

    public enum TimeUnit
    {
        Seconds,
        Minutes,
        Hours
    }

    public static class MonitorUtils
    {
        public static string GetTimeUnitAsString(TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Seconds:
                    return "segundos";
                case TimeUnit.Minutes:
                    return "minutos";
                case TimeUnit.Hours:
                    return "horas";
            }
            return string.Empty;
        }

        public static bool CompareTimeDiff(TimeSpan span, double val, TimeUnit unit)
        {
            bool result = false;

            switch (unit)
            {
                case TimeUnit.Seconds:
                    result = span.TotalSeconds > val;
                    break;
                case TimeUnit.Minutes:
                    result = span.TotalMinutes > val;
                    break;
                case TimeUnit.Hours:
                    result = span.TotalHours > val;
                    break;
                default:
                    break;
            }

            return result;
        }

        public static double GetUnitTimeSpan(TimeUnit unit, TimeSpan span)
        {
            switch (unit)
            {
                case TimeUnit.Seconds:
                    return span.TotalSeconds;
                case TimeUnit.Minutes:
                    return span.TotalMinutes;
                case TimeUnit.Hours:
                    return span.TotalHours;
            }
            return span.Minutes;
        }

        public static TimeUnit GetTimeUnit(string unit)
        {
            switch (unit)
            {
                case "H":
                    return TimeUnit.Hours;
                case "M":
                    return TimeUnit.Minutes;
                case "S":
                    return TimeUnit.Seconds;
                default:
                    return TimeUnit.Seconds;
            }
        }
    }


}
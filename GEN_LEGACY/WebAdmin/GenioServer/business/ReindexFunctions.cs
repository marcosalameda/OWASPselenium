using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- GQPAddress --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAaddre.FldCodaddre)
                .From(CSGenioAaddre.AreaADDRE)
                .Where(CriteriaSet.And().In(CSGenioAaddre.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAaddre model = new CSGenioAaddre(user);
                model.ValCodaddre = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTADDRL --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAaddrl.FldCustomeraddressid)
                .From(CSGenioAaddrl.AreaADDRL)
                .Where(CriteriaSet.And().In(CSGenioAaddrl.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAaddrl model = new CSGenioAaddrl(user);
                model.ValCustomeraddressid = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAERO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAaero.FldCodaero)
                .From(CSGenioAaero.AreaAERO)
                .Where(CriteriaSet.And().In(CSGenioAaero.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAaero model = new CSGenioAaero(user);
                model.ValCodaero = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAGENT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAagent.FldCodagent)
                .From(CSGenioAagent.AreaAGENT)
                .Where(CriteriaSet.And().In(CSGenioAagent.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAagent model = new CSGenioAagent(user);
                model.ValCodagent = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAIRLN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAairln.FldCodairln)
                .From(CSGenioAairln.AreaAIRLN)
                .Where(CriteriaSet.And().In(CSGenioAairln.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAairln model = new CSGenioAairln(user);
                model.ValCodairln = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAUDIT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAaudit.FldCodaudit)
                .From(CSGenioAaudit.AreaAUDIT)
                .Where(CriteriaSet.And().In(CSGenioAaudit.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAaudit model = new CSGenioAaudit(user);
                model.ValCodaudit = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCategorias --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcateg.FldCodcateg)
                .From(CSGenioAcateg.AreaCATEG)
                .Where(CriteriaSet.And().In(CSGenioAcateg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcateg model = new CSGenioAcateg(user);
                model.ValCodcateg = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCFAQS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcfaqs.FldCodcfaqs)
                .From(CSGenioAcfaqs.AreaCFAQS)
                .Where(CriteriaSet.And().In(CSGenioAcfaqs.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcfaqs model = new CSGenioAcfaqs(user);
                model.ValCodcfaqs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCNTRY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcntry.FldCodcntry)
                .From(CSGenioAcntry.AreaCNTRY)
                .Where(CriteriaSet.And().In(CSGenioAcntry.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcntry model = new CSGenioAcntry(user);
                model.ValCodcntry = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCTRY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioActry.FldCodctry)
                .From(CSGenioActry.AreaCTRY)
                .Where(CriteriaSet.And().In(CSGenioActry.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioActry model = new CSGenioActry(user);
                model.ValCodctry = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDECOM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdecom.FldCoddeco)
                .From(CSGenioAdecom.AreaDECOM)
                .Where(CriteriaSet.And().In(CSGenioAdecom.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdecom model = new CSGenioAdecom(user);
                model.ValCoddeco = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDESAM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdesam.FldCoddesam)
                .From(CSGenioAdesam.AreaDESAM)
                .Where(CriteriaSet.And().In(CSGenioAdesam.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdesam model = new CSGenioAdesam(user);
                model.ValCoddesam = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDISST --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdisst.FldCoddisst)
                .From(CSGenioAdisst.AreaDISST)
                .Where(CriteriaSet.And().In(CSGenioAdisst.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdisst model = new CSGenioAdisst(user);
                model.ValCoddisst = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDataTypes --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdttyp.FldCoddttyp)
                .From(CSGenioAdttyp.AreaDTTYP)
                .Where(CriteriaSet.And().In(CSGenioAdttyp.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdttyp model = new CSGenioAdttyp(user);
                model.ValCoddttyp = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFacilityType --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfacty.FldCodfacty)
                .From(CSGenioAfacty.AreaFACTY)
                .Where(CriteriaSet.And().In(CSGenioAfacty.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfacty model = new CSGenioAfacty(user);
                model.ValCodfacty = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFAMIL --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfamil.FldCodfamil)
                .From(CSGenioAfamil.AreaFAMIL)
                .Where(CriteriaSet.And().In(CSGenioAfamil.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfamil model = new CSGenioAfamil(user);
                model.ValCodfamil = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFTGRI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAftgri.FldCodphoto)
                .From(CSGenioAftgri.AreaFTGRI)
                .Where(CriteriaSet.And().In(CSGenioAftgri.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAftgri model = new CSGenioAftgri(user);
                model.ValCodphoto = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGENRE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgenre.FldCodgenre)
                .From(CSGenioAgenre.AreaGENRE)
                .Where(CriteriaSet.And().In(CSGenioAgenre.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgenre model = new CSGenioAgenre(user);
                model.ValCodgenre = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGITEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgitem.FldCodgitem)
                .From(CSGenioAgitem.AreaGITEM)
                .Where(CriteriaSet.And().In(CSGenioAgitem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgitem model = new CSGenioAgitem(user);
                model.ValCodgitem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGRPB --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgrpb.FldCodgrpb)
                .From(CSGenioAgrpb.AreaGRPB)
                .Where(CriteriaSet.And().In(CSGenioAgrpb.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgrpb model = new CSGenioAgrpb(user);
                model.ValCodgrpb = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTINPGR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAinpgr.FldCodinpgr)
                .From(CSGenioAinpgr.AreaINPGR)
                .Where(CriteriaSet.And().In(CSGenioAinpgr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAinpgr model = new CSGenioAinpgr(user);
                model.ValCodinpgr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTKindOfEquipment --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAkinde.FldCodkinde)
                .From(CSGenioAkinde.AreaKINDE)
                .Where(CriteriaSet.And().In(CSGenioAkinde.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAkinde model = new CSGenioAkinde(user);
                model.ValCodkinde = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLANGU --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlangu.FldCodlang)
                .From(CSGenioAlangu.AreaLANGU)
                .Where(CriteriaSet.And().In(CSGenioAlangu.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlangu model = new CSGenioAlangu(user);
                model.ValCodlang = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTORGAN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAorgan.FldCodorgan)
                .From(CSGenioAorgan.AreaORGAN)
                .Where(CriteriaSet.And().In(CSGenioAorgan.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAorgan model = new CSGenioAorgan(user);
                model.ValCodorgan = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTOUDOC --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAoudoc.FldCoddocsd)
                .From(CSGenioAoudoc.AreaOUDOC)
                .Where(CriteriaSet.And().In(CSGenioAoudoc.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAoudoc model = new CSGenioAoudoc(user);
                model.ValCoddocsd = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPEDID --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApedid.FldCodpedid)
                .From(CSGenioApedid.AreaPEDID)
                .Where(CriteriaSet.And().In(CSGenioApedid.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApedid model = new CSGenioApedid(user);
                model.ValCodpedid = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPeriod --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAperio.FldCodperio)
                .From(CSGenioAperio.AreaPERIO)
                .Where(CriteriaSet.And().In(CSGenioAperio.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAperio model = new CSGenioAperio(user);
                model.ValCodperio = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPerson --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAperso.FldCodperso)
                .From(CSGenioAperso.AreaPERSO)
                .Where(CriteriaSet.And().In(CSGenioAperso.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAperso model = new CSGenioAperso(user);
                model.ValCodperso = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPSNGR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsngr.FldCodpsngr)
                .From(CSGenioApsngr.AreaPSNGR)
                .Where(CriteriaSet.And().In(CSGenioApsngr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsngr model = new CSGenioApsngr(user);
                model.ValCodpsngr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTREGIS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAregis.FldCodregis)
                .From(CSGenioAregis.AreaREGIS)
                .Where(CriteriaSet.And().In(CSGenioAregis.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAregis model = new CSGenioAregis(user);
                model.ValCodregis = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTROGL1 --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArogl1.FldCodrogl1)
                .From(CSGenioArogl1.AreaROGL1)
                .Where(CriteriaSet.And().In(CSGenioArogl1.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArogl1 model = new CSGenioArogl1(user);
                model.ValCodrogl1 = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTROLE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArole.FldCodrole)
                .From(CSGenioArole.AreaROLE)
                .Where(CriteriaSet.And().In(CSGenioArole.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArole model = new CSGenioArole(user);
                model.ValCodrole = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTROOMS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArooms.FldCodrooms)
                .From(CSGenioArooms.AreaROOMS)
                .Where(CriteriaSet.And().In(CSGenioArooms.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArooms model = new CSGenioArooms(user);
                model.ValCodrooms = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTRORDF --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArordf.FldCodrordf)
                .From(CSGenioArordf.AreaRORDF)
                .Where(CriteriaSet.And().In(CSGenioArordf.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArordf model = new CSGenioArordf(user);
                model.ValCodrordf = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTRORDI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArordi.FldCodrordi)
                .From(CSGenioArordi.AreaRORDI)
                .Where(CriteriaSet.And().In(CSGenioArordi.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArordi model = new CSGenioArordi(user);
                model.ValCodrordi = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTRULES --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArules.FldCodregra)
                .From(CSGenioArules.AreaRULES)
                .Where(CriteriaSet.And().In(CSGenioArules.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArules model = new CSGenioArules(user);
                model.ValCodregra = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSBCAT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAsbcat.FldCodsbcat)
                .From(CSGenioAsbcat.AreaSBCAT)
                .Where(CriteriaSet.And().In(CSGenioAsbcat.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAsbcat model = new CSGenioAsbcat(user);
                model.ValCodsbcat = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSHITY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAshity.FldCodshity)
                .From(CSGenioAshity.AreaSHITY)
                .Where(CriteriaSet.And().In(CSGenioAshity.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAshity model = new CSGenioAshity(user);
                model.ValCodshity = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSPACE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAspace.FldCodespac)
                .From(CSGenioAspace.AreaSPACE)
                .Where(CriteriaSet.And().In(CSGenioAspace.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAspace model = new CSGenioAspace(user);
                model.ValCodespac = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSPECI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAspeci.FldCodespec)
                .From(CSGenioAspeci.AreaSPECI)
                .Where(CriteriaSet.And().In(CSGenioAspeci.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAspeci model = new CSGenioAspeci(user);
                model.ValCodespec = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSTAKE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAstake.FldCodparte)
                .From(CSGenioAstake.AreaSTAKE)
                .Where(CriteriaSet.And().In(CSGenioAstake.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAstake model = new CSGenioAstake(user);
                model.ValCodparte = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSTRAT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAstrat.FldCodestra)
                .From(CSGenioAstrat.AreaSTRAT)
                .Where(CriteriaSet.And().In(CSGenioAstrat.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAstrat model = new CSGenioAstrat(user);
                model.ValCodestra = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTEAMP --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAteamp.FldCodeqjog)
                .From(CSGenioAteamp.AreaTEAMP)
                .Where(CriteriaSet.And().In(CSGenioAteamp.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAteamp model = new CSGenioAteamp(user);
                model.ValCodeqjog = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTPPRO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtppro.FldCodtppro)
                .From(CSGenioAtppro.AreaTPPRO)
                .Where(CriteriaSet.And().In(CSGenioAtppro.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtppro model = new CSGenioAtppro(user);
                model.ValCodtppro = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTRSB --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtrsb.FldCodtrsb)
                .From(CSGenioAtrsb.AreaTRSB)
                .Where(CriteriaSet.And().In(CSGenioAtrsb.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtrsb model = new CSGenioAtrsb(user);
                model.ValCodtrsb = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTUICOM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAuicom.FldCoduicom)
                .From(CSGenioAuicom.AreaUICOM)
                .Where(CriteriaSet.And().In(CSGenioAuicom.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAuicom model = new CSGenioAuicom(user);
                model.ValCoduicom = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTWAREH --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAwareh.FldCodwareh)
                .From(CSGenioAwareh.AreaWAREH)
                .Where(CriteriaSet.And().In(CSGenioAwareh.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAwareh model = new CSGenioAwareh(user);
                model.ValCodwareh = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTYEAR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAyear.FldCodyear)
                .From(CSGenioAyear.AreaYEAR)
                .Where(CriteriaSet.And().In(CSGenioAyear.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAyear model = new CSGenioAyear(user);
                model.ValCodyear = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAIRPL --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAairpl.FldCodairpl)
                .From(CSGenioAairpl.AreaAIRPL)
                .Where(CriteriaSet.And().In(CSGenioAairpl.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAairpl model = new CSGenioAairpl(user);
                model.ValCodairpl = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAIRPT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAairpt.FldCodairpt)
                .From(CSGenioAairpt.AreaAIRPT)
                .Where(CriteriaSet.And().In(CSGenioAairpt.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAairpt model = new CSGenioAairpt(user);
                model.ValCodairpt = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCATTP --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcattp.FldCodtpcat)
                .From(CSGenioAcattp.AreaCATTP)
                .Where(CriteriaSet.And().In(CSGenioAcattp.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcattp model = new CSGenioAcattp(user);
                model.ValCodtpcat = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCITY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcity.FldCodcity)
                .From(CSGenioAcity.AreaCITY)
                .Where(CriteriaSet.And().In(CSGenioAcity.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcity model = new CSGenioAcity(user);
                model.ValCodcity = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCMPNY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcmpny.FldCodempre)
                .From(CSGenioAcmpny.AreaCMPNY)
                .Where(CriteriaSet.And().In(CSGenioAcmpny.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcmpny model = new CSGenioAcmpny(user);
                model.ValCodempre = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFacility --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfacil.FldCodfacil)
                .From(CSGenioAfacil.AreaFACIL)
                .Where(CriteriaSet.And().In(CSGenioAfacil.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfacil model = new CSGenioAfacil(user);
                model.ValCodfacil = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFAQS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfaqs.FldCodfaqs)
                .From(CSGenioAfaqs.AreaFAQS)
                .Where(CriteriaSet.And().In(CSGenioAfaqs.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfaqs model = new CSGenioAfaqs(user);
                model.ValCodfaqs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGLOB --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAglob.FldCodglob)
                .From(CSGenioAglob.AreaGLOB)
                .Where(CriteriaSet.And().In(CSGenioAglob.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAglob model = new CSGenioAglob(user);
                model.ValCodglob = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTITEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAitem.FldCoditem)
                .From(CSGenioAitem.AreaITEM)
                .Where(CriteriaSet.And().In(CSGenioAitem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAitem model = new CSGenioAitem(user);
                model.ValCoditem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTManualToCollect --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmanua.FldCodmanua)
                .From(CSGenioAmanua.AreaMANUA)
                .Where(CriteriaSet.And().In(CSGenioAmanua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmanua model = new CSGenioAmanua(user);
                model.ValCodmanua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTParameter --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAparam.FldCodparam)
                .From(CSGenioAparam.AreaPARAM)
                .Where(CriteriaSet.And().In(CSGenioAparam.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAparam model = new CSGenioAparam(user);
                model.ValCodparam = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPRPIN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAprpin.FldCodpesso)
                .From(CSGenioAprpin.AreaPRPIN)
                .Where(CriteriaSet.And().In(CSGenioAprpin.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAprpin model = new CSGenioAprpin(user);
                model.ValCodpesso = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPWORG --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApworg.FldCodpworg)
                .From(CSGenioApworg.AreaPWORG)
                .Where(CriteriaSet.And().In(CSGenioApworg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApworg model = new CSGenioApworg(user);
                model.ValCodpworg = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTROIGF --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAroigf.FldCodroigf)
                .From(CSGenioAroigf.AreaROIGF)
                .Where(CriteriaSet.And().In(CSGenioAroigf.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAroigf model = new CSGenioAroigf(user);
                model.ValCodroigf = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTROIGI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAroigi.FldCodroigi)
                .From(CSGenioAroigi.AreaROIGI)
                .Where(CriteriaSet.And().In(CSGenioAroigi.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAroigi model = new CSGenioAroigi(user);
                model.ValCodroigi = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSALE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAsale.FldCodvenda)
                .From(CSGenioAsale.AreaSALE)
                .Where(CriteriaSet.And().In(CSGenioAsale.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAsale model = new CSGenioAsale(user);
                model.ValCodvenda = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTSALES --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAsales.FldCodsales)
                .From(CSGenioAsales.AreaSALES)
                .Where(CriteriaSet.And().In(CSGenioAsales.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAsales model = new CSGenioAsales(user);
                model.ValCodsales = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTBLB --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtblb.FldCodtblb)
                .From(CSGenioAtblb.AreaTBLB)
                .Where(CriteriaSet.And().In(CSGenioAtblb.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtblb model = new CSGenioAtblb(user);
                model.ValCodtblb = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTBLK --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtblk.FldCodtblk)
                .From(CSGenioAtblk.AreaTBLK)
                .Where(CriteriaSet.And().In(CSGenioAtblk.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtblk model = new CSGenioAtblk(user);
                model.ValCodtblk = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTICKT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtickt.FldCodtickt)
                .From(CSGenioAtickt.AreaTICKT)
                .Where(CriteriaSet.And().In(CSGenioAtickt.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtickt model = new CSGenioAtickt(user);
                model.ValCodtickt = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTPCON --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtpcon.FldCodtpcon)
                .From(CSGenioAtpcon.AreaTPCON)
                .Where(CriteriaSet.And().In(CSGenioAtpcon.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtpcon model = new CSGenioAtpcon(user);
                model.ValCodtpcon = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTPEQU --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtpequ.FldCodtpequ)
                .From(CSGenioAtpequ.AreaTPEQU)
                .Where(CriteriaSet.And().In(CSGenioAtpequ.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtpequ model = new CSGenioAtpequ(user);
                model.ValCodtpequ = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTUSERS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAusers.FldCodusers)
                .From(CSGenioAusers.AreaUSERS)
                .Where(CriteriaSet.And().In(CSGenioAusers.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAusers model = new CSGenioAusers(user);
                model.ValCodusers = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTWPESS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAwpess.FldCodpess)
                .From(CSGenioAwpess.AreaWPESS)
                .Where(CriteriaSet.And().In(CSGenioAwpess.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAwpess model = new CSGenioAwpess(user);
                model.ValCodpess = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGAMES --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgames.FldCodgames)
                .From(CSGenioAgames.AreaGAMES)
                .Where(CriteriaSet.And().In(CSGenioAgames.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgames model = new CSGenioAgames(user);
                model.ValCodgames = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTITEMC --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAitemc.FldCodcatar)
                .From(CSGenioAitemc.AreaITEMC)
                .Where(CriteriaSet.And().In(CSGenioAitemc.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAitemc model = new CSGenioAitemc(user);
                model.ValCodcatar = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTITEMP --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAitemp.FldCoditemp)
                .From(CSGenioAitemp.AreaITEMP)
                .Where(CriteriaSet.And().In(CSGenioAitemp.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAitemp model = new CSGenioAitemp(user);
                model.ValCoditemp = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLNHPD --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlnhpd.FldCodlnhpd)
                .From(CSGenioAlnhpd.AreaLNHPD)
                .Where(CriteriaSet.And().In(CSGenioAlnhpd.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlnhpd model = new CSGenioAlnhpd(user);
                model.ValCodlnhpd = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTOUTPT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAoutpt.FldCodoutpt)
                .From(CSGenioAoutpt.AreaOUTPT)
                .Where(CriteriaSet.And().In(CSGenioAoutpt.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAoutpt model = new CSGenioAoutpt(user);
                model.ValCodoutpt = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPROJE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAproje.FldCodproje)
                .From(CSGenioAproje.AreaPROJE)
                .Where(CriteriaSet.And().In(CSGenioAproje.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAproje model = new CSGenioAproje(user);
                model.ValCodproje = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPROPE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAprope.FldCodprope)
                .From(CSGenioAprope.AreaPROPE)
                .Where(CriteriaSet.And().In(CSGenioAprope.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAprope model = new CSGenioAprope(user);
                model.ValCodprope = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTREGIO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAregio.FldCodregia)
                .From(CSGenioAregio.AreaREGIO)
                .Where(CriteriaSet.And().In(CSGenioAregio.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAregio model = new CSGenioAregio(user);
                model.ValCodregia = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTABPR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtabpr.FldCodtabpr)
                .From(CSGenioAtabpr.AreaTABPR)
                .Where(CriteriaSet.And().In(CSGenioAtabpr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtabpr model = new CSGenioAtabpr(user);
                model.ValCodtabpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTTRADU --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtradu.FldCodtradu)
                .From(CSGenioAtradu.AreaTRADU)
                .Where(CriteriaSet.And().In(CSGenioAtradu.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtradu model = new CSGenioAtradu(user);
                model.ValCodtradu = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAGREG --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAagreg.FldCodaggre)
                .From(CSGenioAagreg.AreaAGREG)
                .Where(CriteriaSet.And().In(CSGenioAagreg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAagreg model = new CSGenioAagreg(user);
                model.ValCodaggre = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCMPKI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcmpki.FldCodcmpki)
                .From(CSGenioAcmpki.AreaCMPKI)
                .Where(CriteriaSet.And().In(CSGenioAcmpki.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcmpki model = new CSGenioAcmpki(user);
                model.ValCodcmpki = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTEntity --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAentit.FldCodentit)
                .From(CSGenioAentit.AreaENTIT)
                .Where(CriteriaSet.And().In(CSGenioAentit.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAentit model = new CSGenioAentit(user);
                model.ValCodentit = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFLIGH --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfligh.FldCodfligh)
                .From(CSGenioAfligh.AreaFLIGH)
                .Where(CriteriaSet.And().In(CSGenioAfligh.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfligh model = new CSGenioAfligh(user);
                model.ValCodfligh = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLNHAG --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlnhag.FldCodlnhag)
                .From(CSGenioAlnhag.AreaLNHAG)
                .Where(CriteriaSet.And().In(CSGenioAlnhag.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlnhag model = new CSGenioAlnhag(user);
                model.ValCodlnhag = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTOUTPU --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAoutpu.FldCodoutpu)
                .From(CSGenioAoutpu.AreaOUTPU)
                .Where(CriteriaSet.And().In(CSGenioAoutpu.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAoutpu model = new CSGenioAoutpu(user);
                model.ValCodoutpu = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPROCN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAprocn.FldCodprocn)
                .From(CSGenioAprocn.AreaPROCN)
                .Where(CriteriaSet.And().In(CSGenioAprocn.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAprocn model = new CSGenioAprocn(user);
                model.ValCodprocn = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPROPH --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAproph.FldCodproph)
                .From(CSGenioAproph.AreaPROPH)
                .Where(CriteriaSet.And().In(CSGenioAproph.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAproph model = new CSGenioAproph(user);
                model.ValCodproph = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPWREG --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApwreg.FldCodpwreg)
                .From(CSGenioApwreg.AreaPWREG)
                .Where(CriteriaSet.And().In(CSGenioApwreg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApwreg model = new CSGenioApwreg(user);
                model.ValCodpwreg = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDispatch --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdispa.FldCoddispa)
                .From(CSGenioAdispa.AreaDISPA)
                .Where(CriteriaSet.And().In(CSGenioAdispa.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdispa model = new CSGenioAdispa(user);
                model.ValCoddispa = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTEXPEN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAexpen.FldCoddespe)
                .From(CSGenioAexpen.AreaEXPEN)
                .Where(CriteriaSet.And().In(CSGenioAexpen.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAexpen model = new CSGenioAexpen(user);
                model.ValCoddespe = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFLTSC --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfltsc.FldCodfltsc)
                .From(CSGenioAfltsc.AreaFLTSC)
                .Where(CriteriaSet.And().In(CSGenioAfltsc.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfltsc model = new CSGenioAfltsc(user);
                model.ValCodfltsc = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLNHDE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlnhde.FldCodlnhde)
                .From(CSGenioAlnhde.AreaLNHDE)
                .Where(CriteriaSet.And().In(CSGenioAlnhde.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlnhde model = new CSGenioAlnhde(user);
                model.ValCodlnhde = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLocation --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlocat.FldCodlocat)
                .From(CSGenioAlocat.AreaLOCAT)
                .Where(CriteriaSet.And().In(CSGenioAlocat.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlocat model = new CSGenioAlocat(user);
                model.ValCodlocat = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTMessages --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmessa.FldCodmessa)
                .From(CSGenioAmessa.AreaMESSA)
                .Where(CriteriaSet.And().In(CSGenioAmessa.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmessa model = new CSGenioAmessa(user);
                model.ValCodmessa = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPessoas --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApesso.FldCodpesso)
                .From(CSGenioApesso.AreaPESSO)
                .Where(CriteriaSet.And().In(CSGenioApesso.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApesso model = new CSGenioApesso(user);
                model.ValCodpesso = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTReceipt --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArecei.FldCodrecei)
                .From(CSGenioArecei.AreaRECEI)
                .Where(CriteriaSet.And().In(CSGenioArecei.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArecei model = new CSGenioArecei(user);
                model.ValCodrecei = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAsset --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAasset.FldCodasset)
                .From(CSGenioAasset.AreaASSET)
                .Where(CriteriaSet.And().In(CSGenioAasset.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAasset model = new CSGenioAasset(user);
                model.ValCodasset = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTBRDPS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAbrdps.FldCodbrdps)
                .From(CSGenioAbrdps.AreaBRDPS)
                .Where(CriteriaSet.And().In(CSGenioAbrdps.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAbrdps model = new CSGenioAbrdps(user);
                model.ValCodbrdps = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTCONTA --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAconta.FldCodconta)
                .From(CSGenioAconta.AreaCONTA)
                .Where(CriteriaSet.And().In(CSGenioAconta.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAconta model = new CSGenioAconta(user);
                model.ValCodconta = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTESPPE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAesppe.FldCodesppe)
                .From(CSGenioAesppe.AreaESPPE)
                .Where(CriteriaSet.And().In(CSGenioAesppe.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAesppe model = new CSGenioAesppe(user);
                model.ValCodesppe = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTEVCAT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAevcat.FldCodprogr)
                .From(CSGenioAevcat.AreaEVCAT)
                .Where(CriteriaSet.And().In(CSGenioAevcat.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAevcat model = new CSGenioAevcat(user);
                model.ValCodprogr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTGRID --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgrid.FldCodgrid)
                .From(CSGenioAgrid.AreaGRID)
                .Where(CriteriaSet.And().In(CSGenioAgrid.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgrid model = new CSGenioAgrid(user);
                model.ValCodgrid = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTHPESS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAhpess.FldCodhpess)
                .From(CSGenioAhpess.AreaHPESS)
                .Where(CriteriaSet.And().In(CSGenioAhpess.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAhpess model = new CSGenioAhpess(user);
                model.ValCodhpess = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTINDOC --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAindoc.FldCoddentr)
                .From(CSGenioAindoc.AreaINDOC)
                .Where(CriteriaSet.And().In(CSGenioAindoc.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAindoc model = new CSGenioAindoc(user);
                model.ValCoddentr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLocationExtension --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlcext.FldCodlcext)
                .From(CSGenioAlcext.AreaLCEXT)
                .Where(CriteriaSet.And().In(CSGenioAlcext.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlcext model = new CSGenioAlcext(user);
                model.ValCodlcext = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLNHDF --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlnhdf.FldCodlnhdf)
                .From(CSGenioAlnhdf.AreaLNHDF)
                .Where(CriteriaSet.And().In(CSGenioAlnhdf.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlnhdf model = new CSGenioAlnhdf(user);
                model.ValCodlnhdf = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPROPR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApropr.FldCodpropr)
                .From(CSGenioApropr.AreaPROPR)
                .Where(CriteriaSet.And().In(CSGenioApropr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApropr model = new CSGenioApropr(user);
                model.ValCodpropr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAFINI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAafini.FldCodafini)
                .From(CSGenioAafini.AreaAFINI)
                .Where(CriteriaSet.And().In(CSGenioAafini.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAafini model = new CSGenioAafini(user);
                model.ValCodafini = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAssetManual --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAassma.FldCodassma)
                .From(CSGenioAassma.AreaASSMA)
                .Where(CriteriaSet.And().In(CSGenioAassma.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAassma model = new CSGenioAassma(user);
                model.ValCodassma = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAssetParameter --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAasspa.FldCodasspa)
                .From(CSGenioAasspa.AreaASSPA)
                .Where(CriteriaSet.And().In(CSGenioAasspa.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAasspa model = new CSGenioAasspa(user);
                model.ValCodasspa = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTATAGS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAatags.FldCodtags)
                .From(CSGenioAatags.AreaATAGS)
                .Where(CriteriaSet.And().In(CSGenioAatags.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAatags model = new CSGenioAatags(user);
                model.ValCodtags = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTAttachment --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAattac.FldCodattac)
                .From(CSGenioAattac.AreaATTAC)
                .Where(CriteriaSet.And().In(CSGenioAattac.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAattac model = new CSGenioAattac(user);
                model.ValCodattac = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTEQUIP --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAequip.FldCodequip)
                .From(CSGenioAequip.AreaEQUIP)
                .Where(CriteriaSet.And().In(CSGenioAequip.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAequip model = new CSGenioAequip(user);
                model.ValCodequip = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLDENT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAldent.FldCodldent)
                .From(CSGenioAldent.AreaLDENT)
                .Where(CriteriaSet.And().In(CSGenioAldent.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAldent model = new CSGenioAldent(user);
                model.ValCodldent = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTNOTIF --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAnotif.FldCodnotif)
                .From(CSGenioAnotif.AreaNOTIF)
                .Where(CriteriaSet.And().In(CSGenioAnotif.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAnotif model = new CSGenioAnotif(user);
                model.ValCodnotif = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTProduct --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAprodu.FldCodprodu)
                .From(CSGenioAprodu.AreaPRODU)
                .Where(CriteriaSet.And().In(CSGenioAprodu.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAprodu model = new CSGenioAprodu(user);
                model.ValCodprodu = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPWCOM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApwcom.FldCodpwcom)
                .From(CSGenioApwcom.AreaPWCOM)
                .Where(CriteriaSet.And().In(CSGenioApwcom.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApwcom model = new CSGenioApwcom(user);
                model.ValCodpwcom = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTANEXD --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAanexd.FldCodanexd)
                .From(CSGenioAanexd.AreaANEXD)
                .Where(CriteriaSet.And().In(CSGenioAanexd.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAanexd model = new CSGenioAanexd(user);
                model.ValCodanexd = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTDispatchLine --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAdilin.FldCoddilin)
                .From(CSGenioAdilin.AreaDILIN)
                .Where(CriteriaSet.And().In(CSGenioAdilin.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAdilin model = new CSGenioAdilin(user);
                model.ValCoddilin = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFLDS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAflds.FldCodflds)
                .From(CSGenioAflds.AreaFLDS)
                .Where(CriteriaSet.And().In(CSGenioAflds.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAflds model = new CSGenioAflds(user);
                model.ValCodflds = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTINSTA --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAinsta.FldCodinsta)
                .From(CSGenioAinsta.AreaINSTA)
                .Where(CriteriaSet.And().In(CSGenioAinsta.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAinsta model = new CSGenioAinsta(user);
                model.ValCodinsta = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTLENDI --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAlendi.FldCodlendi)
                .From(CSGenioAlendi.AreaLENDI)
                .Where(CriteriaSet.And().In(CSGenioAlendi.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAlendi model = new CSGenioAlendi(user);
                model.ValCodlendi = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTMOVIM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmovim.FldCodmovim)
                .From(CSGenioAmovim.AreaMOVIM)
                .Where(CriteriaSet.And().In(CSGenioAmovim.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmovim model = new CSGenioAmovim(user);
                model.ValCodmovim = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTPHOTO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAphoto.FldCodphoto)
                .From(CSGenioAphoto.AreaPHOTO)
                .Where(CriteriaSet.And().In(CSGenioAphoto.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAphoto model = new CSGenioAphoto(user);
                model.ValCodphoto = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTReceiptLine --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArelin.FldCoddilin)
                .From(CSGenioArelin.AreaRELIN)
                .Where(CriteriaSet.And().In(CSGenioArelin.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArelin model = new CSGenioArelin(user);
                model.ValCoddilin = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTREPAR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioArepar.FldCodrepar)
                .From(CSGenioArepar.AreaREPAR)
                .Where(CriteriaSet.And().In(CSGenioArepar.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioArepar model = new CSGenioArepar(user);
                model.ValCodrepar = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTVISIT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAvisit.FldCodvisit)
                .From(CSGenioAvisit.AreaVISIT)
                .Where(CriteriaSet.And().In(CSGenioAvisit.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAvisit model = new CSGenioAvisit(user);
                model.ValCodvisit = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- GQTFEECA --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfeeca.FldCodfeeca)
                .From(CSGenioAfeeca.AreaFEECA)
                .Where(CriteriaSet.And().In(CSGenioAfeeca.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfeeca model = new CSGenioAfeeca(user);
                model.ValCodfeeca = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- GQTmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTmem")
                .Where(CriteriaSet.And().In("GQTmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTcfg")
                .Where(CriteriaSet.And().In("GQTcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTlstusr")
                .Where(CriteriaSet.And().In("GQTlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTlstcol")
                .Where(CriteriaSet.And().In("GQTlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTlstren")
                .Where(CriteriaSet.And().In("GQTlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTusrwid")
                .Where(CriteriaSet.And().In("GQTusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTusrcfg")
                .Where(CriteriaSet.And().In("GQTusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTusrset")
                .Where(CriteriaSet.And().In("GQTusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTwkfact")
                .Where(CriteriaSet.And().In("GQTwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTwkfcon")
                .Where(CriteriaSet.And().In("GQTwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTwkflig")
                .Where(CriteriaSet.And().In("GQTwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTwkflow")
                .Where(CriteriaSet.And().In("GQTwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTnotifi")
                .Where(CriteriaSet.And().In("GQTnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTprmfrm")
                .Where(CriteriaSet.And().In("GQTprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTscrcrd")
                .Where(CriteriaSet.And().In("GQTscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTpostit")
                .Where(CriteriaSet.And().In("GQTpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTalerta")
                .Where(CriteriaSet.And().In("GQTalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTaltent")
                .Where(CriteriaSet.And().In("GQTaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTtalert")
                .Where(CriteriaSet.And().In("GQTtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTdelega")
                .Where(CriteriaSet.And().In("GQTdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTTABDINAMIC")
                .Where(CriteriaSet.And().In("GQTTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTaltran")
                .Where(CriteriaSet.And().In("GQTaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTworkflowtask")
                .Where(CriteriaSet.And().In("GQTworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- GQTworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("GQTworkflowprocess")
                .Where(CriteriaSet.And().In("GQTworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





    }
}
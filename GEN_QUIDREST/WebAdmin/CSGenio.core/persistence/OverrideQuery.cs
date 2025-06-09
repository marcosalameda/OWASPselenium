using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using System.Collections;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioServer.framework
{
    public class OverrideQuery
    {
        public static Listing APPDELEGALOGIN(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return sp.select("APPDELEGALOGIN"
                , Qlisting
                , condition.Equal(CSGenioAdelega.FldCodpswdw, user.Codpsw)
                          .NotEqual(CSGenioAdelega.FldRevoked, 1)
                          .GreaterOrEqual(SqlFunctions.Custom("Diferenca_entre_Datas", new ColumnReference(CSGenioAdelega.FldDateini), SqlFunctions.SystemDate(), "D"), 0)
                          .GreaterOrEqual(SqlFunctions.Custom("Diferenca_entre_Datas", SqlFunctions.SystemDate(), new ColumnReference(CSGenioAdelega.FldDateend), "D"), 0)
                , 50, false);
        }
		
		public static Listing APPAUTHORIZATIONLIST(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {

            Listing list = sp.select("APPAUTHORIZATIONLIST"
                , Qlisting
                , condition
                , -1,false);      

            Hashtable modules = new Hashtable();

            DataRowCollection rows = list.DataMatrix.Tables[0].Rows;
            foreach (DataRow r in rows)
            {
                var module = r.ItemArray[1];
                
                //Make sure that it doesn't give exception when multiple roles are assigned
                if (modules.ContainsKey(module))
                    continue;

                modules.Add(module, module);
            }
            if (!modules.ContainsKey("XRS"))
            {
                // must create a user authorization level
                if (Log.IsDebugEnabled) Log.Debug("Processa pedido INS. [id] APPAUTHORIZATIONLIST [aplicacao] pswuserauthlevels");

                //instanciação da area base
                CSGenioApswuserauthlevels area = Area.createArea("pswuserauthlevels", user, list.Module) as CSGenioApswuserauthlevels;
                area.ValNivel = 0;
                area.ValModulo = "XRS";
                area.ValSistema = "GQT";
                // Value da key PSW
                area.ValCodpsw = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                area.insertPseud(sp);
                rows.Add(area.ValCodua, area.ValModulo, area.ValNivel, area.ValCodpsw);
            }

            return list;
		}


		public delegate Listing DelegateTMLINE_TMDSAID (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTMLINE_TMDSAID m_TMLINE_TMDSAID;
        public static void RegisterMethodTMLINE_TMDSAID(DelegateTMLINE_TMDSAID method) { m_TMLINE_TMDSAID = method; }
        public static Listing TMLINE_TMDSAID(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TMLINE_TMDSAID(condition, user, sp, nrRecords, Qlisting);
        }

		public delegate Listing DelegateTMLINED_TMDSAID (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTMLINED_TMDSAID m_TMLINED_TMDSAID;
        public static void RegisterMethodTMLINED_TMDSAID(DelegateTMLINED_TMDSAID method) { m_TMLINED_TMDSAID = method; }
        public static Listing TMLINED_TMDSAID(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TMLINED_TMDSAID(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateTIMEQUIP_SECUNDAR (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTIMEQUIP_SECUNDAR m_TIMEQUIP_SECUNDAR;
        public static void RegisterMethodTIMEQUIP_SECUNDAR(DelegateTIMEQUIP_SECUNDAR method) { m_TIMEQUIP_SECUNDAR = method; }
        public static Listing TIMEQUIP_SECUNDAR(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TIMEQUIP_SECUNDAR(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateEQUIP_TLEQUIPA (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateEQUIP_TLEQUIPA m_EQUIP_TLEQUIPA;
        public static void RegisterMethodEQUIP_TLEQUIPA(DelegateEQUIP_TLEQUIPA method) { m_EQUIP_TLEQUIPA = method; }
        public static Listing EQUIP_TLEQUIPA(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_EQUIP_TLEQUIPA(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateTIMEQUIP_PRIMARY (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTIMEQUIP_PRIMARY m_TIMEQUIP_PRIMARY;
        public static void RegisterMethodTIMEQUIP_PRIMARY(DelegateTIMEQUIP_PRIMARY method) { m_TIMEQUIP_PRIMARY = method; }
        public static Listing TIMEQUIP_PRIMARY(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TIMEQUIP_PRIMARY(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateTMLINEM_TMDSAIM (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTMLINEM_TMDSAIM m_TMLINEM_TMDSAIM;
        public static void RegisterMethodTMLINEM_TMDSAIM(DelegateTMLINEM_TMDSAIM method) { m_TMLINEM_TMDSAIM = method; }
        public static Listing TMLINEM_TMDSAIM(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TMLINEM_TMDSAIM(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateTMLINEW_TMDSAIW (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTMLINEW_TMDSAIW m_TMLINEW_TMDSAIW;
        public static void RegisterMethodTMLINEW_TMDSAIW(DelegateTMLINEW_TMDSAIW method) { m_TMLINEW_TMDSAIW = method; }
        public static Listing TMLINEW_TMDSAIW(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TMLINEW_TMDSAIW(condition, user, sp, nrRecords, Qlisting);
        }
 
		public delegate Listing DelegateTMLINEY_TMDSAIY (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting);
        private static DelegateTMLINEY_TMDSAIY m_TMLINEY_TMDSAIY;
        public static void RegisterMethodTMLINEY_TMDSAIY(DelegateTMLINEY_TMDSAIY method) { m_TMLINEY_TMDSAIY = method; }
        public static Listing TMLINEY_TMDSAIY(CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            return m_TMLINEY_TMDSAIY(condition, user, sp, nrRecords, Qlisting);
        }
      
    }
}

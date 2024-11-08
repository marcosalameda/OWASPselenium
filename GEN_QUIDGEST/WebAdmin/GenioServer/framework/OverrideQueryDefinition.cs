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
using System.Linq;
// USE /[MANUAL GQT IMPORTS]/
// USE /[MANUAL GQT IMPORTS OverrideQuery]/

namespace GenioServer.framework
{
    public class OverrideQueryDeclaring
    {
  
   
   
     
   
   
    
	public static Listing TMLINE_TMDSAID (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("wareh.Codwareh");
            dt.Columns.Add("wareh.Data");
            dt.Columns.Add("wareh.Codigo");
			dt.Columns.Add("wareh.Registo1");
			dt.Columns.Add("wareh.Registo2");
			dt.Columns.Add("wareh.Registo3");
             dt.Columns.Add("wareh.IDPesquisa");
			dt.Columns.Add("wareh.AreaPesquisa");
			dt.Columns.Add("wareh.PKAreaPesquisa");
			dt.Columns.Add("wareh.FormApoio");
			dt.Columns.Add("wareh.AcessoForm");
			dt.Columns.Add("wareh.Preview");
			dt.Columns.Add("wareh.DocNaBD");
            dt.Columns.Add("wareh.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINETMDSAID", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINETMDSAID", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
                     .Like("Timeline", "Registo3", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();

                DataRow dr = dt.NewRow();
                dr["wareh.Codwareh"] = AreaPesquisa + Code;
                dr["wareh.Data"] = Data;
                dr["wareh.Codigo"] = Code;
				dr["wareh.Registo1"] = Registo1;
				dr["wareh.Registo2"] = Registo2;
				dr["wareh.Registo3"] = Registo3;
                 dr["wareh.IDPesquisa"] = IDPesquisa;
                dr["wareh.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["wareh.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["wareh.FormApoio"] = FormApoio;
				dr["wareh.AcessoForm"] = AcessoForm;
                dr["wareh.Preview"] = Preview;
				dr["wareh.DocNaBD"] = DocNaBD;
                dr["wareh.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
  
   
   
     
   
   
    
	public static Listing TMLINED_TMDSAID (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("wareh.Codwareh");
            dt.Columns.Add("wareh.Data");
            dt.Columns.Add("wareh.Codigo");
			dt.Columns.Add("wareh.Registo1");
			dt.Columns.Add("wareh.Registo2");
			dt.Columns.Add("wareh.Registo3");
             dt.Columns.Add("wareh.IDPesquisa");
			dt.Columns.Add("wareh.AreaPesquisa");
			dt.Columns.Add("wareh.PKAreaPesquisa");
			dt.Columns.Add("wareh.FormApoio");
			dt.Columns.Add("wareh.AcessoForm");
			dt.Columns.Add("wareh.Preview");
			dt.Columns.Add("wareh.DocNaBD");
            dt.Columns.Add("wareh.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEDTMDSAID", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEDTMDSAID", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
                     .Like("Timeline", "Registo3", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();

                DataRow dr = dt.NewRow();
                dr["wareh.Codwareh"] = AreaPesquisa + Code;
                dr["wareh.Data"] = Data;
                dr["wareh.Codigo"] = Code;
				dr["wareh.Registo1"] = Registo1;
				dr["wareh.Registo2"] = Registo2;
				dr["wareh.Registo3"] = Registo3;
                 dr["wareh.IDPesquisa"] = IDPesquisa;
                dr["wareh.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["wareh.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["wareh.FormApoio"] = FormApoio;
				dr["wareh.AcessoForm"] = AcessoForm;
                dr["wareh.Preview"] = Preview;
				dr["wareh.DocNaBD"] = DocNaBD;
                dr["wareh.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
   
    
	public static Listing TIMEQUIP_SECUNDAR (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("equip.Codequip");
            dt.Columns.Add("equip.Data");
            dt.Columns.Add("equip.Codigo");
			dt.Columns.Add("equip.Registo1");
			dt.Columns.Add("equip.Registo2");
			dt.Columns.Add("equip.Registo3");
			dt.Columns.Add("equip.Registo4");
             dt.Columns.Add("equip.IDPesquisa");
			dt.Columns.Add("equip.AreaPesquisa");
			dt.Columns.Add("equip.PKAreaPesquisa");
			dt.Columns.Add("equip.FormApoio");
			dt.Columns.Add("equip.AcessoForm");
			dt.Columns.Add("equip.Preview");
			dt.Columns.Add("equip.DocNaBD");
            dt.Columns.Add("equip.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTIMEQUIPSECUNDAR", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTIMEQUIPSECUNDAR", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
					.Like("Timeline", "Registo3", pesquisa)
                     .Like("Timeline", "Registo4", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
				string Registo4 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[13].ToString();

                DataRow dr = dt.NewRow();
                dr["equip.Codequip"] = AreaPesquisa + Code;
                dr["equip.Data"] = Data;
                dr["equip.Codigo"] = Code;
				dr["equip.Registo1"] = Registo1;
				dr["equip.Registo2"] = Registo2;
				dr["equip.Registo3"] = Registo3;
				dr["equip.Registo4"] = Registo4;
                 dr["equip.IDPesquisa"] = IDPesquisa;
                dr["equip.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["equip.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["equip.FormApoio"] = FormApoio;
				dr["equip.AcessoForm"] = AcessoForm;
                dr["equip.Preview"] = Preview;
				dr["equip.DocNaBD"] = DocNaBD;
                dr["equip.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
   
     
   
    
	public static Listing EQUIP_TLEQUIPA (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("equip.Codequip");
            dt.Columns.Add("equip.Data");
            dt.Columns.Add("equip.Codigo");
			dt.Columns.Add("equip.Registo1");
			dt.Columns.Add("equip.Registo2");
			dt.Columns.Add("equip.Registo3");
			dt.Columns.Add("equip.Registo4");
             dt.Columns.Add("equip.IDPesquisa");
			dt.Columns.Add("equip.AreaPesquisa");
			dt.Columns.Add("equip.PKAreaPesquisa");
			dt.Columns.Add("equip.FormApoio");
			dt.Columns.Add("equip.AcessoForm");
			dt.Columns.Add("equip.Preview");
			dt.Columns.Add("equip.DocNaBD");
            dt.Columns.Add("equip.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineEQUIPTLEQUIPA", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineEQUIPTLEQUIPA", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
					.Like("Timeline", "Registo3", pesquisa)
                     .Like("Timeline", "Registo4", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
				string Registo4 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[13].ToString();

                DataRow dr = dt.NewRow();
                dr["equip.Codequip"] = AreaPesquisa + Code;
                dr["equip.Data"] = Data;
                dr["equip.Codigo"] = Code;
				dr["equip.Registo1"] = Registo1;
				dr["equip.Registo2"] = Registo2;
				dr["equip.Registo3"] = Registo3;
				dr["equip.Registo4"] = Registo4;
                 dr["equip.IDPesquisa"] = IDPesquisa;
                dr["equip.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["equip.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["equip.FormApoio"] = FormApoio;
				dr["equip.AcessoForm"] = AcessoForm;
                dr["equip.Preview"] = Preview;
				dr["equip.DocNaBD"] = DocNaBD;
                dr["equip.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
   
    
	public static Listing TIMEQUIP_PRIMARY (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("equip.Codequip");
            dt.Columns.Add("equip.Data");
            dt.Columns.Add("equip.Codigo");
			dt.Columns.Add("equip.Registo1");
			dt.Columns.Add("equip.Registo2");
			dt.Columns.Add("equip.Registo3");
			dt.Columns.Add("equip.Registo4");
             dt.Columns.Add("equip.IDPesquisa");
			dt.Columns.Add("equip.AreaPesquisa");
			dt.Columns.Add("equip.PKAreaPesquisa");
			dt.Columns.Add("equip.FormApoio");
			dt.Columns.Add("equip.AcessoForm");
			dt.Columns.Add("equip.Preview");
			dt.Columns.Add("equip.DocNaBD");
            dt.Columns.Add("equip.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTIMEQUIPPRIMARY", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
					.Select("Timeline", "Registo4")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTIMEQUIPPRIMARY", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
					.Like("Timeline", "Registo3", pesquisa)
                     .Like("Timeline", "Registo4", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
				string Registo4 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[13].ToString();

                DataRow dr = dt.NewRow();
                dr["equip.Codequip"] = AreaPesquisa + Code;
                dr["equip.Data"] = Data;
                dr["equip.Codigo"] = Code;
				dr["equip.Registo1"] = Registo1;
				dr["equip.Registo2"] = Registo2;
				dr["equip.Registo3"] = Registo3;
				dr["equip.Registo4"] = Registo4;
                 dr["equip.IDPesquisa"] = IDPesquisa;
                dr["equip.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["equip.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["equip.FormApoio"] = FormApoio;
				dr["equip.AcessoForm"] = AcessoForm;
                dr["equip.Preview"] = Preview;
				dr["equip.DocNaBD"] = DocNaBD;
                dr["equip.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
    
	public static Listing TMLINEM_TMDSAIM (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("wareh.Codwareh");
            dt.Columns.Add("wareh.Data");
            dt.Columns.Add("wareh.Codigo");
			dt.Columns.Add("wareh.Registo1");
			dt.Columns.Add("wareh.Registo2");
			dt.Columns.Add("wareh.Registo3");
             dt.Columns.Add("wareh.IDPesquisa");
			dt.Columns.Add("wareh.AreaPesquisa");
			dt.Columns.Add("wareh.PKAreaPesquisa");
			dt.Columns.Add("wareh.FormApoio");
			dt.Columns.Add("wareh.AcessoForm");
			dt.Columns.Add("wareh.Preview");
			dt.Columns.Add("wareh.DocNaBD");
            dt.Columns.Add("wareh.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEMTMDSAIM", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEMTMDSAIM", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
                     .Like("Timeline", "Registo3", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();

                DataRow dr = dt.NewRow();
                dr["wareh.Codwareh"] = AreaPesquisa + Code;
                dr["wareh.Data"] = Data;
                dr["wareh.Codigo"] = Code;
				dr["wareh.Registo1"] = Registo1;
				dr["wareh.Registo2"] = Registo2;
				dr["wareh.Registo3"] = Registo3;
                 dr["wareh.IDPesquisa"] = IDPesquisa;
                dr["wareh.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["wareh.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["wareh.FormApoio"] = FormApoio;
				dr["wareh.AcessoForm"] = AcessoForm;
                dr["wareh.Preview"] = Preview;
				dr["wareh.DocNaBD"] = DocNaBD;
                dr["wareh.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
    
	public static Listing TMLINEW_TMDSAIW (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("wareh.Codwareh");
            dt.Columns.Add("wareh.Data");
            dt.Columns.Add("wareh.Codigo");
			dt.Columns.Add("wareh.Registo1");
			dt.Columns.Add("wareh.Registo2");
			dt.Columns.Add("wareh.Registo3");
             dt.Columns.Add("wareh.IDPesquisa");
			dt.Columns.Add("wareh.AreaPesquisa");
			dt.Columns.Add("wareh.PKAreaPesquisa");
			dt.Columns.Add("wareh.FormApoio");
			dt.Columns.Add("wareh.AcessoForm");
			dt.Columns.Add("wareh.Preview");
			dt.Columns.Add("wareh.DocNaBD");
            dt.Columns.Add("wareh.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEWTMDSAIW", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEWTMDSAIW", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
                     .Like("Timeline", "Registo3", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();

                DataRow dr = dt.NewRow();
                dr["wareh.Codwareh"] = AreaPesquisa + Code;
                dr["wareh.Data"] = Data;
                dr["wareh.Codigo"] = Code;
				dr["wareh.Registo1"] = Registo1;
				dr["wareh.Registo2"] = Registo2;
				dr["wareh.Registo3"] = Registo3;
                 dr["wareh.IDPesquisa"] = IDPesquisa;
                dr["wareh.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["wareh.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["wareh.FormApoio"] = FormApoio;
				dr["wareh.AcessoForm"] = AcessoForm;
                dr["wareh.Preview"] = Preview;
				dr["wareh.DocNaBD"] = DocNaBD;
                dr["wareh.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
   
   
   
    
	public static Listing TMLINEY_TMDSAIY (CriteriaSet condition, User user, PersistentSupport sp, int nrRecords, Listing Qlisting)
        {
            DataSet Resultado = new DataSet();

            DataTable Timeline = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("wareh.Codwareh");
            dt.Columns.Add("wareh.Data");
            dt.Columns.Add("wareh.Codigo");
			dt.Columns.Add("wareh.Registo1");
			dt.Columns.Add("wareh.Registo2");
			dt.Columns.Add("wareh.Registo3");
             dt.Columns.Add("wareh.IDPesquisa");
			dt.Columns.Add("wareh.AreaPesquisa");
			dt.Columns.Add("wareh.PKAreaPesquisa");
			dt.Columns.Add("wareh.FormApoio");
			dt.Columns.Add("wareh.AcessoForm");
			dt.Columns.Add("wareh.Preview");
			dt.Columns.Add("wareh.DocNaBD");
            dt.Columns.Add("wareh.ImgSource");

			string chavePedid = "", pesquisa = "";
            int count = condition.SubSets.Count;
            if (count == 1)
                chavePedid = condition.SubSets[0].Criterias[0].RightTerm.ToString();
            else
            {
                pesquisa = condition.SubSets[0].Criterias[0].RightTerm.ToString();
                chavePedid = condition.SubSets[1].Criterias[0].RightTerm.ToString();
            }  

			 if (GlobalFunctions.emptyC(pesquisa) == 1)
            {
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEYTMDSAIY", chavePedid), "Timeline");

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}
			else
			{
				SelectQuery TimelineQuery = new SelectQuery()
					.Select("Timeline","Date")
					.Select("Timeline", "Codigo")
					.Select("Timeline", "Registo1")
					.Select("Timeline", "Registo2")
					.Select("Timeline", "Registo3")
 					.Select("Timeline", "IDPesquisa")
					.Select("Timeline", "AreaPesquisa")
					.Select("Timeline", "PKAreaPesquisa")
					.Select("Timeline", "FormApoio")
					.Select("Timeline", "AcessoForm")
					.Select("Timeline", "Preview")
					.Select("Timeline", "DocNaBD")
					.Select("Timeline", "ImgSource")
					.From(SqlFunctions.Custom("TimelineTMLINEYTMDSAIY", chavePedid), "Timeline")
					.Where(CriteriaSet.Or()
					.Like("Timeline", "Registo1", pesquisa)
					.Like("Timeline", "Registo2", pesquisa)
                     .Like("Timeline", "Registo3", pesquisa));

				Timeline = sp.Execute(TimelineQuery).DbDataSet.Tables[0];
			}

            for (int j = 0; j < Timeline.Rows.Count; j++)
            {
				string Data = DBConversion.ToDateTime(Timeline.DataSet.Tables[0].Rows[j].ItemArray[0]).ToShortDateString();
                string Code  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[1].ToString();
				string Registo1 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[2].ToString();
				string Registo2 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[3].ToString();
				string Registo3 = Timeline.DataSet.Tables[0].Rows[j].ItemArray[4].ToString();
                 string IDPesquisa  = Timeline.DataSet.Tables[0].Rows[j].ItemArray[5].ToString();
                string AreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[6].ToString();
                string PKAreaPesquisa = Timeline.DataSet.Tables[0].Rows[j].ItemArray[7].ToString();
				string FormApoio = Timeline.DataSet.Tables[0].Rows[j].ItemArray[8].ToString();
				string AcessoForm = Timeline.DataSet.Tables[0].Rows[j].ItemArray[9].ToString();
				string Preview = Timeline.DataSet.Tables[0].Rows[j].ItemArray[10].ToString();
				string DocNaBD = Timeline.DataSet.Tables[0].Rows[j].ItemArray[11].ToString();
                string ImgIDI  = "images/" + Timeline.DataSet.Tables[0].Rows[j].ItemArray[12].ToString();

                DataRow dr = dt.NewRow();
                dr["wareh.Codwareh"] = AreaPesquisa + Code;
                dr["wareh.Data"] = Data;
                dr["wareh.Codigo"] = Code;
				dr["wareh.Registo1"] = Registo1;
				dr["wareh.Registo2"] = Registo2;
				dr["wareh.Registo3"] = Registo3;
                 dr["wareh.IDPesquisa"] = IDPesquisa;
                dr["wareh.AreaPesquisa"] = AreaPesquisa.Substring(3).ToLower();
                dr["wareh.PKAreaPesquisa"] = PKAreaPesquisa;
                dr["wareh.FormApoio"] = FormApoio;
				dr["wareh.AcessoForm"] = AcessoForm;
                dr["wareh.Preview"] = Preview;
				dr["wareh.DocNaBD"] = DocNaBD;
                dr["wareh.ImgSource"] = ImgIDI;
                dt.Rows.Add(dr);
            }

           Resultado.Tables.Add(dt);
           Qlisting.DataMatrix = Resultado;

           return Qlisting;
        }
  

        public static void Use()
        {
            OverrideQuery.RegisterMethodTMLINE_TMDSAID(TMLINE_TMDSAID);
            OverrideQuery.RegisterMethodTMLINED_TMDSAID(TMLINED_TMDSAID);
            OverrideQuery.RegisterMethodTIMEQUIP_SECUNDAR(TIMEQUIP_SECUNDAR);
            OverrideQuery.RegisterMethodEQUIP_TLEQUIPA(EQUIP_TLEQUIPA);
            OverrideQuery.RegisterMethodTIMEQUIP_PRIMARY(TIMEQUIP_PRIMARY);
            OverrideQuery.RegisterMethodTMLINEM_TMDSAIM(TMLINEM_TMDSAIM);
            OverrideQuery.RegisterMethodTMLINEW_TMDSAIW(TMLINEW_TMDSAIW);
            OverrideQuery.RegisterMethodTMLINEY_TMDSAIY(TMLINEY_TMDSAIY);
        }
    }
}

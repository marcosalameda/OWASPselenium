using CSGenio.framework;
using CSGenio.persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;

namespace CSGenio.business
{
	public abstract class ManualQuery
	{
		protected String m_query;
		protected String m_id;
		protected IDictionary<String, ParameterQuery> m_parameters;
		protected String m_tiporesultado;
		protected String m_separadorcol;
		protected String m_separadorrow;
        protected String m_ignorarresultadosvazios;

	    public String Id
	    {
	        get { return m_id; }
		}
        public String Query
        {
            get { return m_query; }
            set { m_query = value; }
        }

		public String TipoResultado
        {
            get { return m_tiporesultado; }
            set { m_tiporesultado = value; }
        }

        public String SeparadorColuna
        {
            get { return m_separadorcol; }
            set { m_separadorcol = value; }
        }

        public String SeparadorLinha
        {
            get { return m_separadorrow; }
            set { m_separadorrow = value; }
        }

        public String IgnorarResultadosVazios
        {
            get { return m_ignorarresultadosvazios; }
            set { m_ignorarresultadosvazios = value; }
        }

   		abstract public DataMatrix Run(PersistentSupport sp);
        abstract public DataMatrix Run(IDictionary<String, ParameterQuery> parameters, PersistentSupport sp);

        protected virtual DataMatrix ExecuteQuery(PersistentSupport sp) {
            return sp.executeQuery(m_query, m_parameters);
        }

        public void setParams(Hashtable dados)
        {
            foreach (String id in m_parameters.Keys)
            { 
                ParameterQuery param = m_parameters[id];
                String dado = param.TabelaBase;
                
                if(dados.ContainsKey(dado))
				{
                    if (!String.IsNullOrEmpty(dados[dado].ToString()))
                    {
                        param.Value = dados[dado];
                        continue;
                    }
				}
                    
                dado = param.TabelaBase + "." + param.Field;

                if (dados.ContainsKey(dado))
				{
                    if (!String.IsNullOrEmpty(dados[dado].ToString()))
                    {
                        param.Value = dados[dado];
                        continue;
                    }
				}

                dado = param.Field;

                if (dados.ContainsKey(dado))
				{
                    if (!String.IsNullOrEmpty(dados[dado].ToString()))
                    {
                        param.Value = dados[dado];
                        continue;
                    }
				}
            }
        }
	}

    public class ParameterQuery
    {
        protected String m_id;
        protected String m_tabelabase;
        protected String m_campo;
        protected object m_valor;

        public ParameterQuery(String id)
        {
        	this.m_id = id;
        }

        public String Id
        {
            get { return m_id; }
        }

        public String TabelaBase
        {
            get { return m_tabelabase; }
            set { m_tabelabase = value; }
        }

        public String Field
        {
            get { return m_campo; }
            set { m_campo = value; }
        }

        public object Value
        {
            get { return m_valor; }
            set { m_valor = value; }
        }    
    }

	class Q_equipordevolv : ManualQuery
	{

		public Q_equipordevolv()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_EQUIPORDEVOLV_QDG_#";
			this.m_query = @"SELECT CODLENDI
      ,[CODPESS1]
      ,[CODEQUIP]
      ,[CODPESS2]
      ,[LENDINNR]
      ,[START]
      ,[END]
      ,[RETURNDT]
      ,[RETURNED]
  FROM [GQT0].[dbo].[GQTLENDI] where [RETURNED]=1";
		}


		private Q_equipordevolv SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_equipordevolv().SetParams().ExecuteQuery(sp);
		}
	}
	class Q_contacorrente : ManualQuery
	{

		public Q_contacorrente()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_CONTACORRENTE_QDG_#";
			this.m_query = @"WITH tudo (DATE, CODITEM, codentra, CODOUTPU, QNTY, type, referenc)
AS
(
SELECT 
[GQTLDENT].[DHENTRA] DATE, 
[GQTITEM].[CODITEM] CODITEM, 
[GQTLDENT].[CODLDENT] codentra,
NULL CODOUTPU, 
[GQTLDENT].[QTDENTRA] QNTY,
'Entrada' type, 
[GQTINDOC].[DOCUMENR]
FROM [GQTLDENT] 
INNER JOIN [GQTINDOC] ON [GQTLDENT].[CODDENTR] = [GQTINDOC].[CODDENTR]
INNER JOIN [GQTITEM] ON [GQTLDENT].[CODITEM] = [GQTITEM].[CODITEM]
UNION
SELECT 
[GQTOUTPU].[EXITDT] DATE, 
[GQTITEM].[CODITEM] CODITEM, 
NULL codentra,
[GQTOUTPU].[CODOUTPU] CODOUTPU, 
-[GQTOUTPU].[EXITQNTY] QNTY,
'Saída' type, 
[GQTINDOC].[DOCUMENR] 
FROM [GQTOUTPU] 
INNER JOIN [GQTINDOC] ON [GQTOUTPU].[CODOUTPU] = [GQTINDOC].[CODDENTR]
INNER JOIN [GQTITEM] ON [GQTOUTPU].[CODITEM] = [GQTITEM].[CODITEM]
) 
, saidas (NORDER, DATE, CODITEM, codentra, CODOUTPU, QNTY, type, referenc)
AS (
SELECT
ROW_NUMBER() OVER (PARTITION BY CODITEM ORDER BY DATE) NORDER, DATE, CODITEM, codentra, CODOUTPU, QNTY, type, referenc
FROM TUDO
)
, contas (NORDER, DATE, type, CODITEM, codentra, CODOUTPU, QNTY, BALANCE,  referenc)
AS 
( 
	SELECT s.NORDER, s.DATE, s.type, s.CODITEM, s.codentra, s.CODOUTPU, s.QNTY, sum(t.QNTY) BALANCE, s.referenc
	FROM saidas s 
	INNER JOIN saidas t ON t.CODITEM = s.CODITEM AND t.NORDER <= s.NORDER
	GROUP BY s.NORDER, s.DATE, s.type, s.CODITEM, s.codentra, s.CODOUTPU, s.QNTY, s.referenc
)
-- Define the outer query by referencing columns from both CTEs.
SELECT  NEWID() CODCCORR, 
CAST(NORDER AS FLOAT) NORDER, 
CAST(DATE AS datetime) DATE,
CAST(type AS VARCHAR(10)) type, 
CAST(CODITEM AS UNIQUEIDENTIFIER) CODITEM, 
CAST(CODENTRA AS UNIQUEIDENTIFIER) CODDENTR, 
CAST(CODOUTPU AS UNIQUEIDENTIFIER) CODOUTPU, 
CAST(QNTY AS FLOAT) QNTY,
CAST(BALANCE AS FLOAT) BALANCE, 
CAST(REFERENC AS FLOAT) REFERENC, 
0 ZZSTATE
FROM contas";
		}


		private Q_contacorrente SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_contacorrente().SetParams().ExecuteQuery(sp);
		}
	}
	class Q_sr_artigo : ManualQuery
	{

		public Q_sr_artigo()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_SR_ARTIGO_____QDG_#";
			this.m_query = @"WITH tudo (data, codartig, codentra, codsaida, qtd, tipo, referenc)
AS
(
SELECT 
[GQTLDENT].[DHENTRA] data, 
[GQTITEM].[CODITEM] codartig, 
[GQTLDENT].[CODLDENT] codentra,
NULL codsaida, 
[GQTLDENT].[QTDENTRA] qtd,
'Entrada' tipo, 
[GQTINDOC] .[DOCUMENR]
FROM [GQTLDENT] 
INNER JOIN [GQTINDOC]  ON [GQTLDENT].[CODDENTR] = [GQTINDOC] .[CODDENTR]
INNER JOIN [GQTITEM] ON [GQTLDENT].[CODITEM] = [GQTITEM].[CODITEM]
UNION
SELECT 
[GQTOUTPU].[EXITDT] data, 
[GQTITEM].[CODITEM] codartig, 
NULL codentra,
[GQTOUTPU].[CODOUTPU] codsaida, 
-[GQTOUTPU].[EXITQNTY] qtd,
'Saída' tipo, 
[GQTOUTPT].[DOCUMENR] 
FROM [GQTOUTPU] 
INNER JOIN [GQTOUTPT] ON [GQTOUTPU].[CODOUTPU] = [GQTOUTPT].[CODOUTPT]
INNER JOIN [GQTITEM] ON [GQTOUTPU].[CODITEM] = [GQTITEM].[CODITEM]
) 
, saidas (ordem, data, codartig, codentra, codsaida, qtd, tipo, referenc)
AS (
SELECT
ROW_NUMBER() OVER (PARTITION BY codartig ORDER BY data) ordem, data, codartig, codentra, codsaida, qtd, tipo, referenc
FROM TUDO
)
, contas (ordem, data, tipo, codartig, codentra, codsaida, qtd, saldo,  referenc)
AS 
( 
	SELECT s.ordem, s.data, s.tipo, s.codartig, s.codentra, s.codsaida, s.qtd, sum(t.qtd) saldo, s.referenc
	FROM saidas s 
	INNER JOIN saidas t ON t.codartig = s.codartig AND t.ordem <= s.ordem
	GROUP BY s.ordem, s.data, s.tipo, s.codartig, s.codentra, s.codsaida, s.qtd, s.referenc
)
-- Define the outer query by referencing columns from both CTEs.
SELECT  NEWID() CODCCORR, 
CAST(ORDEM AS FLOAT) ORDEM, 
CAST(DATA AS datetime) DATA,
CAST(TIPO AS VARCHAR(10)) TIPO, 
CAST(CODARTIG AS UNIQUEIDENTIFIER) CODARTIG, 
CAST(CODENTRA AS UNIQUEIDENTIFIER) CODDENTR, 
CAST(CODSAIDA AS UNIQUEIDENTIFIER) CODDSAID, 
CAST(QTD AS FLOAT) QTD,
CAST(SALDO AS FLOAT) SALDO, 
CAST(REFERENC AS FLOAT) REFERENC, 
0 ZZSTATE
FROM contas";
		}


		private Q_sr_artigo SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_sr_artigo().SetParams().ExecuteQuery(sp);
		}
	}
	class Q_stock : ManualQuery
	{

		public Q_stock()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_STOCK_________QDG_#";
			this.m_query = @"WITH GLOBAL (date, codprodu, codrecei, coddispa, quantity, type, referenc)
AS
(
SELECT 
[GQTRECEIPTLINE].[INSTANT] date, 
[GQTPRODUCT].[codprodu] codprodu, 
[GQTRECEIPTLINE].[CODRECEI] codrecei,
NULL coddispa, 
[GQTRECEIPTLINE].[RECEIVED] quantity,
'Input' type, 
[GQTRECEIPT].[NUMBER]
FROM [GQTRECEIPTLINE] 
INNER JOIN [GQTRECEIPT] ON [GQTRECEIPTLINE].[CODRECEI] = [GQTRECEIPT].[CODRECEI]
INNER JOIN [GQTPRODUCT] ON [GQTRECEIPTLINE].[CODPRODU] = [GQTPRODUCT].[CODPRODU]
UNION
SELECT 
[GQTDISPATCHLINE].[INSTANT] date, 
[GQTPRODUCT].[CODPRODU] codprodu, 
NULL codrecei,
[GQTDISPATCHLINE].[CODDILIN] coddispa, 
-[GQTDISPATCHLINE].[DELIVERE] quantity,
'Output' type, 
[GQTDISPATCH].[DISPANR] 
FROM [GQTDISPATCHLINE] 
INNER JOIN [GQTDISPATCH] ON [GQTDISPATCHLINE].[CODDISPA] = [GQTDISPATCH].[CODDISPA]
INNER JOIN [GQTPRODUCT] ON [GQTDISPATCHLINE].[CODPRODU] = [GQTPRODUCT].[CODPRODU]
) 
, outputs (sequence, date, codprodu, codrecei, coddispa, quantity, type, referenc)
AS (
SELECT
ROW_NUMBER() OVER (PARTITION BY codprodu ORDER BY date) sequence, date, codprodu, codrecei, coddispa, quantity, type, referenc
FROM GLOBAL
)
, counts (sequence, date, type, codprodu, codrecei, coddispa, quantity, balance,  referenc)
AS 
( 
	SELECT s.sequence, s.date, s.type, s.codprodu, s.codrecei, s.coddispa, s.quantity, sum(t.quantity) balance, s.referenc
	FROM outputs s 
	INNER JOIN outputs t ON t.codprodu = s.codprodu AND t.sequence <= s.sequence
	GROUP BY s.sequence, s.date, s.type, s.codprodu, s.codrecei, s.coddispa, s.quantity, s.referenc
)
-- Define the outer query by referencing columns from both CTEs.
SELECT  NEWID() CODSTOCK, 
CAST(sequence AS FLOAT) SEQUENCE, 
CAST(date AS datetime) DATE,
CAST(type AS VARCHAR(10)) TYPE, 
CAST(codprodu AS UNIQUEIDENTIFIER) CODPRODU, 
CAST(codrecei AS UNIQUEIDENTIFIER) CODRECEI, 
CAST(coddispa AS UNIQUEIDENTIFIER) CODDISPA, 
CAST(quantity AS FLOAT) QUANTITY,
CAST(balance AS FLOAT) BALANCE, 
CAST(REFERENC AS FLOAT) REFERENC, 
0 ZZSTATE
FROM counts";
		}


		private Q_stock SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_stock().SetParams().ExecuteQuery(sp);
		}
	}
	class Q_dispatchalert : ManualQuery
	{

		public Q_dispatchalert()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_DISPATCHALERT_QDG_#";
			this.m_query = @"SELECT [CODDISPA]
      ,[DISPADT]
      ,[DISPANR]
      ,[CODENTIT]
      ,[PREPARED]
	  ,T1.[CODPERSO]
	  ,T2.NAME
  FROM [GQTDISPATCH] T1
  inner join [GQTPERSON] T2 ON T1.CODPERSO=T2.CODPERSO 
  WHERE [ISPREPAR]=1
--only send email if it hasn't been sent before 
  AND ([DISPANR] not in (SELECT[DOCUM_NR] FROM [GQTMESSAGES] WHERE MAILSENT = 1))";
		}


		private Q_dispatchalert SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_dispatchalert().SetParams().ExecuteQuery(sp);
		}
	}
	class Q_emptysearchcountry : ManualQuery
	{

		public Q_emptysearchcountry()
		{
			this.m_parameters = new Dictionary<String, ParameterQuery>();
			this.m_id = "#_QDG_EMPTYSEARCHCOUNTRY_QDG_#";
			this.m_query = @"select CAST('00000000-0000-0000-0000-000000000001' as UNIQUEIDENTIFIER) as CODSEARCH, CAST(NULL as UNIQUEIDENTIFIER) as CODPAIS, CAST(NULL as UNIQUEIDENTIFIER) as CODREGIA, '' as HKEY, 0 as ZZSTATE";
		}


		private Q_emptysearchcountry SetParams()
		{
			return this;
		}

		public override DataMatrix Run(PersistentSupport sp)
		{
			return this.SetParams().ExecuteQuery(sp);
		}

		public override DataMatrix Run(IDictionary<String, ParameterQuery> parameters,PersistentSupport sp)
		{
			return new Q_emptysearchcountry().SetParams().ExecuteQuery(sp);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;

using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.core.persistence;
using GenioServer.security;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT IMPORTS]/
// USE /[MANUAL GQT IMPORTS GlobalFunctions]/

namespace CSGenio.business
{
	/// <summary>
	/// Summary description for GlobalFunctions.
	/// </summary>
	public sealed partial class GlobalFunctions
	{
		/// <summary>
		/// Initializes all the manual functions.
		/// </summary>
		private static void initTodasFuncoes()
		{
			todasFuncoes = new Hashtable(17, (float)0.5);
			todasFuncoes.Add("password_alterar", 0);
			todasFuncoes.Add("password_verificaAntiga", 1);
			todasFuncoes.Add("validarAssinatura", 2);
			todasFuncoes.Add("devolverCamposAssinatura", 3);
			todasFuncoes.Add("escreverAssinatura", 4);
			todasFuncoes.Add("password_gerar", 5);
			todasFuncoes.Add("CriarDocumQweb", 6);
			todasFuncoes.Add("GetUserProfile", 7);
			//funcoes Csharp
			todasFuncoes.Add("Idade_X", 8);
			todasFuncoes.Add("Idade", 9);
			todasFuncoes.Add("DayOfWeek", 10);
			todasFuncoes.Add("TimeNow", 11);
			todasFuncoes.Add("GetGeoFromLatLng", 12);
			// Cargas
			todasFuncoes.Add("carga_Manuals", 13);
			todasFuncoes.Add("carga_Parameters", 14);
			todasFuncoes.Add("carga_CONJUNTO", 15);
			todasFuncoes.Add("carga_unico", 16);
		}

		#region Funções

		/// <summary>
		/// Cálculo da idade
		/// </summary>
		/// <param name="dDtNasc">Data de nascimento</param>
		/// <param name="dData">Data a calcular a idade</param>
		public decimal Idade(DateTime? dDtNasc, DateTime? dData)
		{
//BEGIN_FUNCTION:453ea83f-9d2e-4569-b7d4-d75f1203cdda
        // se alguma das datas não é válida, retorna 0
	if (emptyD(dDtNasc) == 0) return 0;
	if (emptyD(dData) == 0) return 0;

            DateTime _dDtNasc = dDtNasc.Value;
            DateTime _dData = dData.Value;


            int d, m, a;
	d = _dData.Day; m = _dData.Month; a = _dData.Year;
	decimal idade = a - _dDtNasc.Year;
	if (m < _dDtNasc.Month || m == _dDtNasc.Month && d < _dDtNasc.Day) idade--;
	return idade;
//END_FUNCTION
		}

		/// <summary>
		/// Returns the weekday number of a given date
		///  0 - Sunday
		///  1 - Monday
		///  2 - Tuesday
		///  3 - Wednesday
		///  4 - Thursday
		///  5 - Friday
		///  6 - Saturday
		/// -1 - Invalid
		/// </summary>
		/// <param name="dt">Date to know the day of the week</param>
		public decimal DayOfWeek(DateTime? dt)
		{
//BEGIN_FUNCTION:6ccc609d-6af4-44df-bab1-0156e1268a7f
if ( emptyD(dt)==0 )
{
     return Convert.ToDecimal(dt.GetValueOrDefault().DayOfWeek);
}
else
{
     return Convert.ToDecimal(-1);
}
//END_FUNCTION
		}

		/// <summary>
		/// When invoked it gets the current time on this computer
		/// </summary>
		public string TimeNow()
		{
//BEGIN_FUNCTION:08a6ae08-5bb9-4271-a44e-70a02fe06fdc
return DateTime.Now.ToString("HH:mm");
//END_FUNCTION
		}

		/// <summary>
		/// GetGeoFromLatLng
		/// </summary>
		/// <param name="lat">Latitudes range from -90 to 90.</param>
		/// <param name="lng">Longitudes range from -180 to 180.</param>
		public string GetGeoFromLatLng(decimal lat, decimal lng)
		{
			try
			{
				SelectQuery query = new SelectQuery()
					.Select(new SqlFunction(SqlFunctionType.Custom, 
						"GetGeoFromLatLng"
						, lat,lng
						), "x");
				var result = sp.ExecuteScalar(query);
				return DBConversion.ToGeography(result);
			}
			catch (Exception e)
			{
				throw new BusinessException(null, "GlobalFunctions.string GetGeoFromLatLng", "Error on execution: " + e.Message, e);
			}
		}

		#endregion

		#region MANCS

//Platform: CS | Type: FUNCCS | Module: GQT | Parameter: IDADE_X | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:4024b219-1607-4a2c-b41e-14b3cf4c96b3
public decimal Idade_X(DateTime dDtNasc, DateTime dData)
{
	// se alguma das datas não é válida, retorna 0
	if (emptyD(dDtNasc) == 0) return 0;
	if (emptyD(dData) == 0) return 0;
	int d, m, a;
	d = dData.Day; m = dData.Month; a = dData.Year;
	decimal idade = a - dDtNasc.Year;
	if (m < dDtNasc.Month || m == dDtNasc.Month && d < dDtNasc.Day) idade--;
	return idade;
}
//END_MANUALCODE



		#endregion

		private static readonly List<string> m_allManualFuntionsNames = new List<string>()
		{
			"Idade_X",
			"Idade",
			"DayOfWeek",
			"TimeNow",
			"GetGeoFromLatLng"
		};

		public static List<string> AllManualFuntionsNames
		{
			get
			{
				return m_allManualFuntionsNames;
			}
		}

		/// <summary>
		/// Check if function can be executed from the outside (from the client-side)
		/// </summary>
		/// <param name="functionName"></param>
		/// <returns></returns>
		public static bool CheckAllowedFunctions(string functionName)
		{
			return m_allManualFuntionsNames.Contains(functionName);
		}
	}
}

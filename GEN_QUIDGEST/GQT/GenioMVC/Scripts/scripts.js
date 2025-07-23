/* ===================================================
* scripts.js v1.0.0
* http://www.quidgest.com
* ===================================================
* Copyright 2012 Quidgest, S.A.
*
* All custom scripts will be placed here.
* ========================================================== */

/**************************
*  Funções do user  *
**************************/
// USE /[MANUAL GQT SCRIPTS_JS]/


//*************** User functions ***************
function Idade(dDtNasc, dData)
{
	/// <summary>
	/// Cálculo da idade
	/// </summary>
	/// <param name="dDtNasc">Data de nascimento</param>
	/// <param name="dData">Data a calcular a idade</param>
return ExecuteServerFunction('Idade', [dDtNasc, dData]);
}
function DayOfWeek(dt)
{
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
/* eslint-disable indent */
//BEGIN_FUNCTION:0046fb16-3f8a-4a8c-9b0a-ab584e81a745
	if (dt instanceof Date)
		return dt.getDay();
	return -1;
//END_FUNCTION
// eslint-disable-next-line
/* eslint-enable indent */
}
function TimeNow()
{
	/// <summary>
	/// When invoked it gets the current time on this computer
	/// </summary>
/* eslint-disable indent */
//BEGIN_FUNCTION:200d736c-8e5c-4006-8880-40a26bc61649
	const date = new Date();
	return `${date.getHours()}:${date.getMinutes()}`;
//END_FUNCTION
// eslint-disable-next-line
/* eslint-enable indent */
}
function GetGeoFromLatLng(lat, lng)
{
	/// <summary>
	/// GetGeoFromLatLng
	/// </summary>
	/// <param name="lat">Latitudes range from -90 to 90.</param>
	/// <param name="lng">Longitudes range from -180 to 180.</param>
return ExecuteServerFunction('GetGeoFromLatLng', [lat, lng]);
}




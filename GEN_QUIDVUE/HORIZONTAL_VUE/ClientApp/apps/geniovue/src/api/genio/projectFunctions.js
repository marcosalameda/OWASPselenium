/* eslint-disable no-unused-vars */
import { useTracingDataStore } from '@quidgest/clientapp/stores'

import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
/* eslint-enable no-unused-vars */

/*
 * ====================================================
 * projectFuntions.js v1.0.0
 * http://www.quidgest.com
 * ====================================================
 * Copyright 2026 Quidgest, S.A.
 *
 * All project functions will be placed here.
 * ====================================================
 */

//*************** User functions ***************
function Idade(dDtNasc, dData)
{
	/// <summary>
	/// Cálculo da idade
	/// </summary>
	/// <param name="dDtNasc">Data de nascimento</param>
	/// <param name="dData">Data a calcular a idade</param>
	return netAPI.executeServerFunction('Idade', [dDtNasc, dData]);
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
	return netAPI.executeServerFunction('GetGeoFromLatLng', [lat, lng]);
}

export default {
	Idade,
	DayOfWeek,
	TimeNow,
	GetGeoFromLatLng,
}

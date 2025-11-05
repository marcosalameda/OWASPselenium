//*************** Funções hardcoded *****************
function password_verificaNova(passnova1, passnova2) {
    if (passnova1 == passnova2)
        return passnova1
    else
        alert(MsgSet[66]);
    return MsgSet[66]
}

function EncryptPass(password, mod, exp) {
    try {
        setMaxDigits(259);
        var key = new RSAKeyPair(exp, "", mod);
        var res = encryptedString(key, password);
        return res;
    }
    catch (error) {
        return password;
    }
}

function FormatoExport(texto, result, txtbot1, txtbot2, id) {
    if (result == 1)
        ExecCmd("", "Execute(" + id + ",GetExcel," + txtbot1);
    else
        ExecCmd("", "Execute(" + id + ",GetExcel," + txtbot2);
}

function ConfirmRevoke() {
    if (confirm(MsgSet[67]))
        ExecCmd("", "ExecRotina(DELEGAREVOKE");
}

function filtraCodigoPostal(codigoPostal) {
    // MA 20120323 Verificação do preenchimento da parte opcional do código postal
    var codigoPostalFinal = codigoPostal;
    var j = codigoPostal.indexOf("-___");
    // se não foi preenchido o final, trunca a parte final
    if (j != -1) {
        codigoPostalFinal = codigoPostal.substr(0, j);
    }
    return codigoPostalFinal;
}

function assinar(textoParaAssinar) {
    var CAPICOM_STORE_OPEN_READ_ONLY = 0;
    var CAPICOM_CURRENT_USER_STORE = 2;

    if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {

        try {
            // Cria os activeX (precisa das bibliotecas da capicom)
            // Pode-se fazer o download aqui http://www.microsoft.com/downloads/details.aspx?FamilyID=860EE43A-A843-462F-ABB5-FF88EA5896F6&displaylang=en
            var cert = new ActiveXObject("CAPICOM.Certificate");
            var mystore = new ActiveXObject("CAPICOM.Store");

            //Abre os certificados existentes na maquina
            mystore.Open(CAPICOM_CURRENT_USER_STORE, "My", CAPICOM_STORE_OPEN_READ_ONLY);
            cert = mystore.Certificates.Item(1);

            //Selecciona o certificado
            var selected = mystore.Certificates.Select("Escolha o certificado", true);

            //Assinar o texto
            var signer = new ActiveXObject("CAPICOM.Signer");
            signer.Certificate = selected.Item(1);

            var SignedData = new ActiveXObject("CAPICOM.SignedData");
            SignedData.Content = textoParaAssinar;
            var serialNumber = selected.Item(1).SerialNumber;
            var emissor = selected.Item(1).IssuerName;
            ExecCmd("", "SetHistorial(serialNumber," + serialNumber + ",EQ");
            ExecCmd("", "SetHistorial(emissorADigital,«" + emissor + "»,EQ");

            //Assina e devolve a assinatura
            return SignedData.Sign(signer, true, 0);
        } catch (e) {

            alert(MsgSet[68]);
            return 0;
        }

    } else {
        if (confirm(MsgSet[69])) {

            try {
                var assinatura = crypto.signText(textoParaAssinar, "ask");

                if (assinatura.match("error") == "error")
                    return 0;

                else return assinatura;

            } catch (e) {
                alert(e.message);
            }

            return 0;

        } else return 0;
    }
}

//*************** Funções manuais *****************
function AbrirDbEditSombra(form)
{
}
function GetNivelAcessoDescr(nivel)
{
	var modulo = qApi.GetModulo();
	var modnivel = modulo + nivel;
	var descr="";
	switch (modnivel)
	{
		case "0": descr = "Unauthorized"; break;
		case "1": descr = "Query"; break;
		case "REG1": descr = "Query"; break;
		case "TRN1": descr = "Query"; break;
		case "TBS1": descr = "Query"; break;
		case "IMO1": descr = "Query"; break;
		case "GQT1": descr = "Query"; break;
		case "PTN1": descr = "Query"; break;
		case "STY1": descr = "Query"; break;
		case "2": descr = "Vendedor"; break;
		case "GQT2": descr = "Vendedor"; break;
		case "3": descr = "Officer"; break;
		case "TRN3": descr = "Officer"; break;
		case "4": descr = "Agente"; break;
		case "TRN4": descr = "Agente"; break;
		case "20": descr = "Manager"; break;
		case "WMS20": descr = "Manager"; break;
		case "IMO20": descr = "Manager"; break;
		case "GQT20": descr = "Manager"; break;
		case "99": descr = "Administrator"; break;
		case "IMO99": descr = "Administrator"; break;
		case "REG99": descr = "Administrator"; break;
		case "TRN99": descr = "Administrator"; break;
		case "PTN99": descr = "Administrator"; break;
		case "TBS99": descr = "Administrator"; break;
		case "GQT99": descr = "Administrator"; break;
		case "WMS99": descr = "Administrator"; break;
		case "XRS99": descr = "Administrator"; break;
		case "STY99": descr = "Administrator"; break;
	}
	return GetUserMessage(descr);
}
function Sigla()
{
return "LEGACY";
}
function OpenTapiForm(classe, pk) {
}

//*************** User functions ***************
function Idade(dDtNasc, dData)
{
	/// <summary>
	/// Cálculo da idade
	/// </summary>
	/// <param name="dDtNasc">Data de nascimento</param>
	/// <param name="dData">Data a calcular a idade</param>
return api.ExecServerFunction('Idade', [dDtNasc, dData], ['D', 'D'], 'N');
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
return api.ExecServerFunction('GetGeoFromLatLng', [lat, lng], ['N', 'N'], 'A');
}

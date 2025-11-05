using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// List of communication blocks
/// </summary>
public class QcomBlk
{
    [JsonProperty("STAT")]
    public string Stat;
    [JsonProperty("ONLINE")]
    public string Online;
    [JsonProperty("LANG")]
    public string Lang;
    [JsonProperty("SES")]
    public string Ses;
    [JsonProperty("QCOMLIST")]
    public List<Qcom> QcomList;
}

/// <summary>
/// One comunication message
/// </summary>
public class Qcom
{
    [JsonProperty("APP")]
    public string App;
    [JsonProperty("IDENT")]
    public string Ident;
    [JsonProperty("FUNC")]
    public string Func;
    [JsonProperty("COND")]
    public string Cond;
    [JsonProperty("ORD")]
    public string Ord;
    [JsonProperty("CMPS")]
    public string[] Cmps;
    [JsonProperty("DADOS")]
    public List<string[]> Dados;
    [JsonProperty("OPT")]
    public string Opt;
    [JsonProperty("MSG")]
    public string Msg;
    [JsonProperty("STAT")]
    public string Stat;
    [JsonProperty("MOD")]
    public string Mod;
    [JsonProperty("FICH")]
    public string Fich;
    [JsonProperty("YEAR")]
    public string Year;
}

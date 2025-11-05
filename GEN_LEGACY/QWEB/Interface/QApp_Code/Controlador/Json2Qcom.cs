using Newtonsoft.Json;

/// <summary>
/// Summary description for Json2Qcom
/// </summary>
public static class Json2Qcom
{
    public static string Serialize(QcomBlk msg)
    {
        return JsonConvert.SerializeObject(msg);
    }

    public static QcomBlk Deserialize(string msg)
    {
        return JsonConvert.DeserializeObject<QcomBlk>(msg);
    }
}

/// <summary>
/// Turn the JsonFile into a "JsonFull" which can now be easily accessed in c# with every parameter readable
/// </summary>
[System.Serializable]
public class JsonData
{
    public JsonWheel[] data;
    public string key;
}
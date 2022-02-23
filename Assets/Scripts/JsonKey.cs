/// <summary>
/// Turn the JsonFile into a "JsonKey" which can now be easily accessed in c# with every parameter readable
/// </summary>
[System.Serializable]
public class JsonKey
{
    public string key;

    public JsonKey()
    {
        key = "";
    }
    
    public JsonKey(string _key)
    {
        key = _key;
    }
}
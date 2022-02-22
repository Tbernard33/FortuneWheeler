using UnityEngine;

/// <summary>
/// Turn the JsonFile into a "JsonWheel" wich can now be easily accessed in c# with every parameter readable
/// </summary>
[System.Serializable]
public class JsonWheel
{
    public int index;
    public int euros;
    public bool isJackpot;

    public static JsonWheel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JsonWheel>(jsonString);
    }

    public JsonWheel()
    {
        index = 0;
        euros = 0;
        isJackpot = false;
    }
}

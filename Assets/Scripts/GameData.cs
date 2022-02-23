using UnityEngine;

/// <summary>
/// Game data static class to store and shara data between classes.
/// Is very helpfull to avoid singletons when not needed
/// </summary>
public static class GameData
{
    private static PostManager m_PostManager = null;
    
    private static JsonData m_Data;
    private static JsonResult m_Result;
    
    public static void AddPostManager(PostManager _Post)
    {
        if (!m_PostManager || m_PostManager != _Post)
            m_PostManager = _Post;
    }
    
    public static void WriteData(JsonData _data)
    {
        m_Data = _data;
    }
    
    public static void WriteResult(JsonResult _result)
    {
        m_Result = _result;
    }
    
    public static JsonData Data => m_Data;
        
    public static JsonResult Result => m_Result;
    
    public static PostManager PostManager
    {
        get
        {
            if (m_PostManager == null)
            {
                GameObject go = new GameObject("PostManager");
                go.AddComponent<PostManager>();
                m_PostManager = go.GetComponent<PostManager>();
            }
            return m_PostManager;
        }
    }
}

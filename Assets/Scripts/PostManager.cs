using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Manage post request for data and result
/// </summary>
public class PostManager : MonoBehaviour
{
    string m_UrlData = "https://8ghzo9aw5h.execute-api.eu-west-3.amazonaws.com/prod/getData";
    string m_UrlResult = "https://8ghzo9aw5h.execute-api.eu-west-3.amazonaws.com/prod/getResult";

    private void Start()
    {
        GameData.AddPostManager(this);
    }

    /// <summary>
    /// Getter to start the coroutines and get data from server
    /// </summary>
    public void GetDataAndResult()
    {
        StartCoroutine(GetDataCoroutine());
    }
    
     /// <summary>
     /// Get data from the server using a post method
     /// </summary>
     /// <returns></returns>
    IEnumerator GetDataCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("Null", "0");

        using (UnityWebRequest www = UnityWebRequest.Post(m_UrlData, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Data Status Code: " + www.error);
            }
            else
            {
                GameData.WriteData(JsonUtility.FromJson<JsonData>(www.downloadHandler.text));
                StartCoroutine(GetResultCoroutine());
            }
        }
    }

    /// <summary>
    /// Get results from the server using a post method and the key from GetData
    /// </summary>
    /// <returns></returns>
    IEnumerator GetResultCoroutine()
    {
        JsonKey jsonKey = new JsonKey(GameData.Data.key);
        
        UnityWebRequest www = new UnityWebRequest(m_UrlResult, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(jsonKey));
        www.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        
        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Result Status Code: " + www.error);
        }
        else
        {
            GameData.WriteResult(JsonUtility.FromJson<JsonResult>(www.downloadHandler.text));
        }
    }

}

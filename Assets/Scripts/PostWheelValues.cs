using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Get the possible values of the wheel
/// </summary>
public class PostWheelValues : MonoBehaviour
{
    string m_Url = "https://8ghzo9aw5h.execute-api.eu-west-3.amazonaws.com/prod/getData";
    private JsonWheel[] m_WheelValuesToGet;
    
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("Null", "0");

        using (UnityWebRequest www = UnityWebRequest.Post(m_Url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete! with : " + www.downloadHandler.text);
            }
        }
    }
}

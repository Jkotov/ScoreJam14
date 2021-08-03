using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendResult : MonoBehaviour
{
    [SerializeField] private GameObject nameText;
    [SerializeField] private int minNameLength;
    [SerializeField] private string url = "https://infamy.dev/highscore/add?id=Pathmaker&name=";
    [SerializeField] private GameObject timer;
    private string _time;
    private bool _sent = false;
    
    public void Send()
    {
        string playerName = nameText.GetComponent<Text>().text;
        _time = timer.GetComponent<Text>().text;
        if (!_sent && playerName.Length > minNameLength)
        {
            _sent = true;
            url += WebUtility.UrlEncode(playerName) + "&score=" + WebUtility.UrlEncode(_time);
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            webRequest.SendWebRequest();
            
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}

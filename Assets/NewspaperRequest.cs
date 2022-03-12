using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NewspaperRequest : MonoBehaviour
{
    public Responce newsAllData;
    public ItemList prefab;
    public Transform point;
    public GameObject inputField;
    //public string ObjectsText;
    void Start()
    {
        StartCoroutine(GetData());


    }
    private IEnumerator GetData()
    {
        //Debug.Log(ObjectsText);
        UnityWebRequest request = new UnityWebRequest("https://newsapi.org/v2/everything?q=tesla&from=2022-02-12&sortBy=publishedAt&apiKey=6e490f023c1c48febf81c1f335f95444")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Connection error!");
            yield break;
        }
        newsAllData = JsonUtility.FromJson<Responce>(request.downloadHandler.text);

        for (int i = 0; i < newsAllData.articles.Count; i++)
        {

            ItemList button = Instantiate(prefab, point);
            button.SetItem(newsAllData.articles[i]);

        }

    }

    // public void SearchData()
    // {
    //      InputField txt_Input = GameObject.Find("SearchBox").GetComponent<InputField>();
    //       ObjectsText = txt_Input.text;

    //      StartCoroutine(GetData());
    // }
}



[Serializable]
public class Source
{
    public string id;
    public string name;
}

[Serializable]
public class Article
{
    public Source source;
    public string author;
    public string title;
    public string description;
    public string url;
    public string urlToImage;
    public DateTime publishedAt;
    public string content;
    public Texture imgTextute;
}

[Serializable]
public class Responce
{
    public string status;
    public int totalResults;
    public List<Article> articles;
}

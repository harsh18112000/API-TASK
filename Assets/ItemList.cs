using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ItemList : MonoBehaviour
{
    public Text mainText;
    public RawImage rawImageData;
    public Texture imageTexture;
    public Texture imageTextureStore;

    public Article articleData;
    public Text titledata;
    public Text discriptionData;

    public TempDataStore tempDataStore;

    public string title1 = "Test";
    public string conatin1;
    private GameObject mainCanvas;
    private GameObject containCanvas;

    void Start()
    {
        mainCanvas = GameObject.Find("Canvas");
        containCanvas = GameObject.Find("AllContainCanvas");
        tempDataStore = GameObject.Find("CanvasHandler").GetComponent<TempDataStore>();

    }

    public void SetItem(Article data)
    {
        articleData = data;
        mainText.text = articleData.title;
        title1 = articleData.title;
        //Debug.Log(articleData.content);
        StartCoroutine(GetTexture());


    }
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(articleData.urlToImage);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImageData.texture = myTexture;
            imageTextureStore = myTexture;
        }
    }

    public void Onclick()
    {


        mainCanvas.SetActive(false);
        tempDataStore.TempDataAll(articleData, imageTextureStore);
    }


}

using UnityEngine;
using UnityEngine.UI;

public class TempDataStore : MonoBehaviour
{
    public GameObject tempCanvas;
    public Text titleText;
    public Text containText;
    public Text describsion;

    private Texture2D myTexture;
    public RawImage rawImageTexture;
    public Article alldata;
    // public GameObject mainScreen;

    public string title;
    public void TempDataAll(Article tempData, Texture imgtexture)
    {
        //myTexture =imgtexture; 
        tempCanvas.SetActive(true);
        alldata = tempData;

        //Debug.Log(alldata.title);

        // Debug.Log(alldata.title);

        titleText.text = alldata.title;
        containText.text = alldata.description;
        rawImageTexture.texture = imgtexture;
        describsion.text = alldata.content;
    }
}

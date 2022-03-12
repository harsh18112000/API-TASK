using UnityEngine;
using UnityEngine.UI;

public class AnotherScript : MonoBehaviour
{
    [SerializeField] private Text mainAnotherText;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject anotherPanel;

    public void OnClickData(string anotherText)
    {
        mainPanel.SetActive(false);
        anotherPanel.SetActive(true);
        mainAnotherText.text = anotherText;
    }
}

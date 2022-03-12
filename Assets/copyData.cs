using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copyData : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text MainText;
    [SerializeField] private AnotherScript anotherScript;

    private void Start()
    {
        button.onClick.AddListener(delegate { anotherScript.OnClickData(MainText.text); });
    }
}


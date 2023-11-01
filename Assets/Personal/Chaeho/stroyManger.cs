using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class stroyManger : MonoBehaviour
{
    public string[] line = new string[10];
    int nowLine = 0;
    bool lineEnd=true;
    public Text lineText;

    private void Update()
    {
        lineText.text = line[nowLine];
        if(Input.GetKeyDown(KeyCode.Space))
        {
            nowLine++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jusamovestg2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x-1,
                Input.mousePosition.y+1, -Camera.main.transform.position.z));
        transform.position = point;

        if (GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 == 0)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 0;
            GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 255;
            GetComponent<SpriteRenderer>().color = color;
        }
    }
}

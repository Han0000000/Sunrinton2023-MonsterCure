using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove_bsh : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject pl;
    float dum;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        dum = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //if (GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 == 0)
        //{
            transform.position = new Vector3(transform.position.x - (transform.position.x - pl.transform.position.x) / 10, transform.position.y - (transform.position.y - pl.transform.position.y - 2) / 10, -10);
            //GetComponent<Camera>().orthographicSize += (dum-GetComponent<Camera>().orthographicSize)/10;
        //}
        //else
        ///{
        //    GetComponent<Camera>().orthographicSize += ((dum-2)- GetComponent<Camera>().orthographicSize) / 10;
        //}
    }
}

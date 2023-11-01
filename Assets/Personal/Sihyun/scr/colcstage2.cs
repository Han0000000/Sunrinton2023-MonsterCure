using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colcstage2 : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKey(KeyCode.E) && collision.tag == "Monster" && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGround && GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 == 0)
        {
            print("a");
            if (collision.GetComponent<monmovestage2>().sangtae > 2)
            {
                PlayerController.isStun = true;
                PlayerController.stun_time = 1.5f;
            }
            else
            {

                GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2 = 3;


                collision.transform.Find("pointstg2").gameObject.SetActive(true);
                collision.transform.Find("pointstg2 1").gameObject.SetActive(true);
                collision.transform.Find("pointstg2 2").gameObject.SetActive(true);
                collision.transform.Find("pointstg2 3").gameObject.SetActive(true);
                Color color = collision.transform.Find("pointstg2").GetComponent<SpriteRenderer>().color;
                color.a = 255;
                collision.transform.Find("pointstg2 1").GetComponent<SpriteRenderer>().color = color;
                color = collision.transform.Find("pointstg2 1").GetComponent<SpriteRenderer>().color;
                color.a = 255;
                collision.transform.Find("pointstg2 2").GetComponent<SpriteRenderer>().color = color;
                color = collision.transform.Find("pointstg2 2").GetComponent<SpriteRenderer>().color;
                color.a = 255;
                collision.transform.Find("pointstg2 3").GetComponent<SpriteRenderer>().color = color;
                color = collision.transform.Find("pointstg2 3").GetComponent<SpriteRenderer>().color;
                color.a = 255;
                collision.transform.Find("pointstg2").GetComponent<SpriteRenderer>().color = color;
                collision.GetComponent<monmovestage2>().ancatch = 1;
                GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 = 1;
            }
            
        }
    }
}
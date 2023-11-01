using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3_Catch : MonoBehaviour
{
    public GameObject paritcle_heal;
    public GameObject black_screen;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Catch();          
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Catch();
            }
        }
    }

    void Catch()
    {
        Stage3_Enemy.isMove = false;
        paritcle_heal.SetActive(true);
        black_screen.SetActive(true);
        Invoke("End", 1.5f);

    }

    void End()
    {
        SceneManager.LoadScene("Ending");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int page = 1;
    public GameObject btn_next;
    public GameObject btn_before;

    public GameObject first_page;
    public GameObject second_page;
    public GameObject third_page;
    private void Start()
    {
        Page();
    }
    public void Btn_Next()
    {
        page++;
        Next_ani();
    }

    public void Btn_before()
    {
        page--;
        Before_ani();
    }

    public void Next_ani()
    {
        if(page == 2)
        {
            first_page.GetComponent<Animator>().SetTrigger("Tr");
            Debug.Log("firstPage사라지기");
        }
        else if(page == 3) second_page.GetComponent<Animator>().SetTrigger("Tr");

        Invoke("Page", 1.7f);
    }

    public void Before_ani()
    {
        if (page == 1)
        {
            second_page.GetComponent<Animator>().SetTrigger("Tr2");
            Debug.Log("firstPage사라지기");
        }
        if (page == 2)
        {
            third_page.GetComponent<Animator>().SetTrigger("Tr2");
            Debug.Log("secondpage나타나기");
        }

        Invoke("Page", 1.7f);
    }

    public void Update()
    {
        if (page >= 3) btn_next.SetActive(false);
        else btn_next.SetActive(true);

        if (page <= 1) btn_before.SetActive(false);
        else btn_before.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    public void Page()
    {
        if (page == 1)
        {
            first_page.SetActive(true);
            second_page.SetActive(false);
            third_page.SetActive(false);
        }
        else if (page == 2)
        {
            first_page.SetActive(false);
            second_page.SetActive(true);
            third_page.SetActive(false);
        }
        else if (page == 3)
        {
            first_page.SetActive(false);
            second_page.SetActive(false);
            third_page.SetActive(true);
        }
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage1_GameManger : MonoBehaviour
{
    public int cured_Monster1 = 0;
    public bool isNextPanel = false;

    private void Update()
    {
        if (cured_Monster1 >= 3 && !isNextPanel)
        {
            isNextPanel = true;
            //nextPanel.SetActive(true);
        }

        if (isNextPanel)
        {
            SceneManager.LoadScene("test");
        }
    }
}


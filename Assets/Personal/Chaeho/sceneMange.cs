using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMange : MonoBehaviour
{
    public void clickStart()
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void clickExit()
    {
        Application.Quit();
    }
}

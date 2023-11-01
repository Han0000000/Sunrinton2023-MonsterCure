using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeOver : MonoBehaviour
{
    public float time;
    public float cur_time;

    public Text txt_time;
    string currentSceneName;
    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    public void Update()
    {
        cur_time += Time.deltaTime;
        if(time < cur_time)
        {
            Debug.Log("게임오버");
            SceneManager.LoadScene(currentSceneName);
        }

        txt_time.text = "남은시간 : " + Mathf.Round(time - cur_time).ToString();
    }
}

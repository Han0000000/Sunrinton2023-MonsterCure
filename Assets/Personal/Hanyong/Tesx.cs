using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tesx : MonoBehaviour
{
    public Text Message;
    public int message_count = 0;
    private string m_text = "나는,";
    public int i;
    void Start()
    {
        StartCoroutine(Typing2());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            message_count++;
            Typing();
            StartCoroutine(Typing2());
        }
    }

    IEnumerator Typing2()
    {
        for (i = 0; i <= m_text.Length; i++)
        {
            Message.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.08f);
        }
    }

    void Typing()
    {
        i = 0;
        if (message_count == 1) m_text = "나는,";
        else if (message_count == 2) m_text = "수의사다.";
        else if (message_count == 3) m_text = "근데 아주 특별한 수의사";
        else if (message_count == 4) m_text = ".......";
        else if (message_count == 5) m_text = "흔히 사람들의 \"괴물\"이라 부르는 생명체를";
        else if (message_count == 6) m_text = "치료하는 수의사..";
        else if (message_count == 7) m_text = "오늘도 나는";
        else if (message_count == 8) m_text = "이 괴물들을 치료하러 갈것이다.";
        else if (message_count == 9) m_text = "[ 몬스터들을 치료하는 키는 E입니다 ]";
        else if (message_count > 9) SceneManager.LoadScene("Stage1");

    }
}

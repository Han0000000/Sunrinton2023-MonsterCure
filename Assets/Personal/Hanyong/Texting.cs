using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texting : MonoBehaviour
{
    public Text Message;
    public int message_count = 0;
    private string m_text = "그렇게 모든 몬스터들의 건강을 치료하였다";
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
        if (message_count == 1) m_text = "그렇게 모든 몬스터들의 건강을 치료하였다";

    }
}

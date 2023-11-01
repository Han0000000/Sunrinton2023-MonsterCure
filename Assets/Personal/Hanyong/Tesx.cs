using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tesx : MonoBehaviour
{
    public Text Message;
    public int message_count = 0;
    private string m_text = "����,";
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
        if (message_count == 1) m_text = "����,";
        else if (message_count == 2) m_text = "���ǻ��.";
        else if (message_count == 3) m_text = "�ٵ� ���� Ư���� ���ǻ�";
        else if (message_count == 4) m_text = ".......";
        else if (message_count == 5) m_text = "���� ������� \"����\"�̶� �θ��� ����ü��";
        else if (message_count == 6) m_text = "ġ���ϴ� ���ǻ�..";
        else if (message_count == 7) m_text = "���õ� ����";
        else if (message_count == 8) m_text = "�� �������� ġ���Ϸ� �����̴�.";
        else if (message_count == 9) m_text = "[ ���͵��� ġ���ϴ� Ű�� E�Դϴ� ]";
        else if (message_count > 9) SceneManager.LoadScene("Stage1");

    }
}

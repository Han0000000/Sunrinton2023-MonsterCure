using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    bool IsSkillW = true;
    bool IsSkillQ = true;

    public GameObject skillW;
    public GameObject skillQ;

    public GameObject skillW_effect;
    public GameObject skillQ_effect;

   

    public GameObject player;

    private void Update()
    {
        if (IsSkillW) skillW.SetActive(true);
        else skillW.SetActive(false);

        if (IsSkillQ) skillQ.SetActive(true);
        else skillQ.SetActive(false);

        if(Input.GetKeyUp(KeyCode.Q) && IsSkillQ)
        {
            SkillQ_use();
        }

        if (Input.GetKeyUp(KeyCode.W) && IsSkillW)
        {
            SkillW_use();
        }
    }

    void SkillQ_use()
    {
        IsSkillQ = false;
        player.GetComponent<PlayerController>().speed += 4;
        skillQ_effect.SetActive(true);
        Invoke("SKillQ_end", 5);
    }

    void SKillQ_end()
    {
        player.GetComponent<PlayerController>().speed -= 4;
        skillQ_effect.SetActive(false);
    }

    void SkillW_use()
    {
        IsSkillW = false;
        player.GetComponent<PlayerController>().jumpForce += 4;
        skillW_effect.SetActive(true);
    }

    void SKillW_end()
    {
        player.GetComponent<PlayerController>().jumpForce -= 4;
        skillW_effect.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_time : MonoBehaviour
{
    public float time;
    void OnEnable()
    {
        Invoke("Object_false", time);
    }

    void Object_false()
    {
        gameObject.SetActive(false);
    }
}

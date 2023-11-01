using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum Type
    {
        stage1, 
        stage2,
        stage3
    }
    public enum State
    {
        사나운, 
        상처입은,
        슬픈,
        치료된
    }
    public State state;
    public Type type;
    public float speed;


    private void Update()
    {
        /*
         // state사용할때사용하는 방법
        if(state == State.상처입은) ~이라면
         */
    }
}

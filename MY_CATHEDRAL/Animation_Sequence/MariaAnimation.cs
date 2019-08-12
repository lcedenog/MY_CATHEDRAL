using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaAnimation : MonoBehaviour
     
{
    private Animator Anim;
    void Start()
    {
    Anim = GetComponent<Animator>();
        Anim.speed = 0f;
    }

    public  void AnimUp()
    {
        Anim.Play("mariasube",-1,0f);
        Anim.speed = 1f;
    }

    public void AnimRotate()
    {
        Anim.Play("mariarotaaa", -1, 0f);
        Anim.speed = 1f;
    }





}

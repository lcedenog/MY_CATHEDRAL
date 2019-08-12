using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarcisaAnimacion : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0f;
    }

    public void AnimUpNarcisa()
    {
        Anim.Play("narcisa", -1, 0f);
        Anim.speed = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jesusanimation : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0f;
    }

    public void RotateAnimJesus()
    {
        Anim.Play("jesus", -1, 0f);
        Anim.speed = 1f;
    }
}

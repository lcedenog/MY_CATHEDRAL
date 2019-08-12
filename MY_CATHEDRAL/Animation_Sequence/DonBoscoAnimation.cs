using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonBoscoAnimation : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0f;
    }

    public void AnimDonBosco()
    {
        Anim.Play("donbosco", -1, 0f);
        Anim.speed = 1f;
    }
}

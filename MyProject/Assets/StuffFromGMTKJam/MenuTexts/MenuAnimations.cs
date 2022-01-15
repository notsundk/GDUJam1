using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public Animator anim;

    public void PlayAnim(string name)
    {
        anim.Play(name);
    }

}

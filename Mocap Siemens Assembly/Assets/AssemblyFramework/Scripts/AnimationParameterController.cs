using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameterController : MonoBehaviour {

    public Animator anim;

    public void ActivateParameter(string name)
    {
        anim.SetBool(name, true);
    }
}

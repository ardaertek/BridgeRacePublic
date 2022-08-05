using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void isRunning(bool value)
    {
        _animator.SetBool("isRunning",value);
    }
    public void isVictory(bool value)
    {
        _animator.SetBool("isVictory", true);
    }


}

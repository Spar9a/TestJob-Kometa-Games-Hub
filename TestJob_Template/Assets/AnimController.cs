using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator _animator;

    private bool Wind = false;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("withoutWind", -1, Random.Range(0.0f, 1.0f));
    }

    public void WindTriger()
    {
        Wind = !Wind;
        _animator.SetBool("Wind", Wind);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiAnimationEvent : MonoBehaviour
{

    private Yeti _yeti;

    public void Start()
    {
        _yeti = transform.parent.GetComponent<Yeti>();
    }

    public void Fire()
    {
        Debug.Log("Yeti SHould fire");
        _yeti.Attack();
    }
}

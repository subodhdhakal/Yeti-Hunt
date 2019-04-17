using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : Enemy
{
    private void Start()
    {
        Attack();
    }

    public override void Update()
    {
        Debug.Log("Yeti Updating.....");
    }
}

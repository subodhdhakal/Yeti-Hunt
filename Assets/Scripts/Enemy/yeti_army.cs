using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeti_army : Enemy
{
    private void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        Debug.Log("Yeti Army attack");
    }

    public override void Update()
    {
        Debug.Log("Yeti army udapting.....");
    }
}

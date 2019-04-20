using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti_Army : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

    }

    public void Damage()
    {

    }
}

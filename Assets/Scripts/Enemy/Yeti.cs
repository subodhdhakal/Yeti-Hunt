﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : Enemy, IDamageable
{
    public int Health { get; set; }
    

    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public void Damage()
    {
        Debug.Log("Damage!");
        Health--;

        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
   
}

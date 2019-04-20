using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti_Army : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public void Damage()
    {
        Debug.Log("Small Yeti Damage called");
        anim.SetTrigger("hurt");
        Health--;

        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}

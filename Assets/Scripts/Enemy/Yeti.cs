using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : Enemy, IDamageable
{
    public GameObject SnowBallEffect;

    public float Health { get; set; }
    

    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public void Damage()
    {
        //Debug.Log("Big Yeti Damage!");

        Health--;
        anim.SetTrigger("hurt");
        //isHurt = true;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            StartCoroutine(NeedObjectDestroy());
        }
    }
   
    public void Attack()
    {
        //Instantiate the SnowBall Effect
        Instantiate(SnowBallEffect, transform.position, Quaternion.identity);

    }

    IEnumerator NeedObjectDestroy()
    {
        yield return new WaitForSeconds(1.5f); //wait 2 sec
        //Destroy(this.gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti_Army : Enemy, IDamageable
{
    public float Health { get; set; }

    //TO identify the type 1 or 2 yeti spawn points
    public int type = 0;


    public override void Init()
    {
        base.Init();
        Health = base.health; //Gets health from the Enemy class

    }

    public void Damage()
    {
        // Debug.Log("Small Yeti Damage called");
        if (isDead)
            return;

        anim.SetTrigger("hurt");
        SoundManagerScript.PlaySound(SoundManagerScript.Sound.stab);
        SoundManagerScript.PlaySound(SoundManagerScript.Sound.YetiHurt);

        Health--;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            SoundManagerScript.PlaySound(SoundManagerScript.Sound.YetiDie);

            StartCoroutine(NeedObjectDestroy());
        }
    }

    IEnumerator NeedObjectDestroy()
    {
        yield return new WaitForSeconds(1.5f); //wait 2 sec
        Instantiate(diamondPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        if (type == 1)
            EnemyDeployer.Instance.counter1--;
        else
            EnemyDeployer.Instance.counter2--;
    }
}

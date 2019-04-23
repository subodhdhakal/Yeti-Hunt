using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti_Army : Enemy, IDamageable
{
    public float Health { get; set; }


    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip hurtSound;
    [SerializeField]
    AudioClip stabSound;

    [SerializeField] [Range(0, 1)]
    float soundVolume = 0.75f;

    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public void Damage()
    {
       // Debug.Log("Small Yeti Damage called");
        anim.SetTrigger("hurt");
        AudioSource.PlayClipAtPoint(stabSound, this.gameObject.transform.position);
        AudioSource.PlayClipAtPoint(hurtSound, this.gameObject.transform.position);

        Health--;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            StartCoroutine(NeedObjectDestroy());
        }
    }

    IEnumerator NeedObjectDestroy()
    {
        yield return new WaitForSeconds(1.5f); //wait 2 sec
        Destroy(this.gameObject);
    }
}

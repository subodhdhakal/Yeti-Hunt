using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yeti : Enemy, IDamageable
{
    public GameObject SnowBallEffect;

    //Yeti Health Bar
    public float Health { get; set; }
    public Slider healthbar;
    [SerializeField]
    private float MaxHealth = 5;
    //Audio or Sound Effects
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip hurtSound;
    [SerializeField]
    AudioClip stabSound;
    [SerializeField] [Range(0, 1)]
    float soundVolume = 0.75f;

    void Start()
    {
        Health = MaxHealth;

        healthbar.value = CalculateHealth();

        base.Init();
    }

    public void Damage()
    {
        if (isDead)
            return;

        Debug.Log("Big Yeti Damage!");

        //Health--;
        anim.SetTrigger("hurt");
        //isHurt = true;
        SoundManagerScript.PlaySound(SoundManagerScript.Sound.stab);
        SoundManagerScript.PlaySound(SoundManagerScript.Sound.YetiHurt);

        float damageValue = 0.7f;
        Health -= damageValue;
        healthbar.value = CalculateHealth();

        if (Health <= 0)
        {
            isDead = true;
            anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            StartCoroutine(NeedObjectDestroy());
        }
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    public void Attack()
    {
        //Instantiate the SnowBall Effect
        Instantiate(SnowBallEffect, transform.position, Quaternion.identity);

    }

    IEnumerator NeedObjectDestroy()
    {
        yield return new WaitForSeconds(3.0f); //wait 2 sec
        Destroy(this.gameObject);
        UIManager.Instance.DisplayGameEndScreen("You win");
    }
}



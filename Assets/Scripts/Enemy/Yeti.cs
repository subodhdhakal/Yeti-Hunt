using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yeti : Enemy, IDamageable
{

    //Yeti Health Bar
    public float Health { get; set; }
    public Slider healthbar;
    [SerializeField]
    private float MaxHealth = 5;

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
            SoundManagerScript.PlaySound(SoundManagerScript.Sound.YetiDie);
            StartCoroutine(NeedObjectDestroy());
        }
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    public void Attack()
    {

    }

    IEnumerator NeedObjectDestroy()
    {
        yield return new WaitForSeconds(3.0f); //wait 2 sec
        Destroy(this.gameObject);
        UIManager.Instance.DisplayGameEndScreen("YOU WIN\n\n\nDiamonds Collected: " + player.getDiamond());
    }
}



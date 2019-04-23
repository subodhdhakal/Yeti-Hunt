using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yeti : Enemy, IDamageable
{
    public GameObject SnowBallEffect;

    //Yeti Health Bar
    public float Health { get; set; } = 5.0f;
    public Slider healthbar;
    [SerializeField]
    private float MaxHealth = 5.0f;
    //Audio or Sound Effects
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip hurtSound;
    [SerializeField]
    AudioClip stabSound;
    [SerializeField] [Range(0, 1)]
    float soundVolume = 0.75f;

    public void Damage()
    {
        //Debug.Log("Big Yeti Damage!");

        //Health--;
        anim.SetTrigger("hurt");
        //isHurt = true;
        AudioSource.PlayClipAtPoint(stabSound, this.gameObject.transform.position);
        AudioSource.PlayClipAtPoint(hurtSound, this.gameObject.transform.position);

        float damageValue = 0.7f;
        Health -= damageValue;
        healthbar.value = CalculateHealth();

        if (Health <= 0)
        {
            isDead = true;
            anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            StartCoroutine(NeedObjectDestroy());
            SceneManager.LoadScene("YouWin", LoadSceneMode.Additive);
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
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}



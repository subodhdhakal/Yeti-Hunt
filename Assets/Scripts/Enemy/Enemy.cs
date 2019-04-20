using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected float attackingDistance; //distance to start attacking

    protected bool facingLeft = true;
    protected bool isDead = false;
    protected int initialHealth;

    //protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;

    //handle to player object
    protected Player player;
   
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        initialHealth = health;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (!isDead)
        {
            if (player != null)
            {
                Movement();
                ValidatePosition();
            }
        }
    }

    public virtual void Movement()
    {
        flip();

        //distance between player and enemy
        float distance = Mathf.Abs(transform.localPosition.x - player.transform.localPosition.x);

        //location of player for enemy to move towards
        Vector3 playerpos = new Vector3(player.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

        //if player is in the zone
        if (distance >= attackingDistance)
        {
            anim.SetBool("InCombat", false);
            if (playerpos.x > pointA.position.x && playerpos.x < pointB.position.x)
            {
                //walk toward player
                transform.position = Vector3.MoveTowards(transform.localPosition, playerpos, (speed) * Time.deltaTime);
                anim.SetBool("Walk", true);
            }
            else
            {
                //idle
                anim.SetBool("Walk", false);
            }
        }
        else
        {
            //idle and attack
            anim.SetBool("Walk", false);
            anim.SetBool("InCombat", true);
        }

    }

    protected void ValidatePosition()
    {
        if (transform.position.x < pointA.position.x)
            transform.position = new Vector3(pointB.position.x - 1, transform.position.y, transform.position.z);
        else if (transform.position.x > pointB.position.x)
            transform.position = new Vector3(pointA.position.x + 1, transform.position.y, transform.position.z);
    }

    protected void flip()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0)
        {
            //face right
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            facingLeft = false;
        }
        else if (direction.x < 0)
        {
            //face left
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
            facingLeft = true;
        }
    }

    public virtual void Damage()
    {
        //anim.SetTrigger("Hit");

        //soundManagerScript.PlaySound("enemyHit");
        anim.SetBool("InCombat", true);
    }
}

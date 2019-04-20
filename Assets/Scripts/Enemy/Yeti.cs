using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : Enemy, IDamageable
{
    public int Health { get; set; }
    

    public override void Init()
    {
        base.Init();

    }

    public void Damage()
    {

    }
    //private bool _switch;
    //private Animator _anim;
    //private void Start()
    //{
    //    _anim = GetComponentInChildren<Animator>();
    //}

    //public override void Update()
    //{
    //if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
    //    {
    //        return;
    //    }

    //    Movement();
    //}

    //void Movement()
    //{
    //    if (transform.position == pointA.position)
    //    {
    //        _switch = false;
    //        _anim.SetTrigger("Idle");
    //    }
    //    else if (transform.position == pointB.position)
    //    {
    //        _switch = true;
    //        _anim.SetTrigger("Idle");
    //    }

    //    if (_switch == false)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

    //    }
    //    else if (_switch == true)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

    //    }
    //}
}

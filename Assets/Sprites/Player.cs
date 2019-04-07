using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigid;
    private Animator _anim;

    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private LayerMask ground_layer;
    private bool need_jump_reset = false;
    // Start is called before the first frame update

    void Start()
    {
        _rigid = this.GetComponent<Rigidbody2D>();
        _anim = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //isGrounded();  //Check using Raycast if the player is grounded to avoid air-jump.
        if (CrossPlatformInputManager.GetButton("A") && isGrounded() == true)
        {
            attack();
        }

        if (CrossPlatformInputManager.GetButton("S") && isGrounded() == true)
        {
            attack2();
        }
    }

    void Movement()
    {
        float moveSpeed = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if ((moveSpeed < 0 && transform.localScale.x < 0) || (moveSpeed > 0 && transform.localScale.x > 0))
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);

        _rigid.velocity = new Vector2(moveSpeed * speed, _rigid.velocity.y);
        _anim.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

        if (CrossPlatformInputManager.GetButton("Jump") && isGrounded() == true)
        {
            _anim.SetTrigger("jump");
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            StartCoroutine(NeedJumpResetRoutine());
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, ground_layer.value);
        //(1 << 8) layermask is 32-bit int array. To make layermask = 8(ground layer) , we need to bit-shift 1

        //Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green); //Raycast Line Drawe

        if (hit.collider != null)
        {
            Debug.Log("hit:" + hit.collider.name); //Raycast collision check

            if (need_jump_reset == false)   // if not jumping - player is on ground
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator NeedJumpResetRoutine()
    {
        need_jump_reset = true;
        yield return new WaitForSeconds(0.1f); //wait 10th of second
        need_jump_reset = false;
    }

    void attack()
    {
        _anim.SetTrigger("Attack");
        Debug.Log("Attack Animation has been played");
    }

    void attack2()
    { 
        _anim.SetTrigger("Attack2");
        Debug.Log("Attack 1 Animation has been played");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigid;
    private Animator _anim;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private bool on_ground = false;
    [SerializeField]
    private LayerMask ground_layer;
    private bool need_jump_reset = false;
    // Start is called before the first frame update
    void Start()
    {
         _rigid = this.GetComponent<Rigidbody2D>();
        _anim= this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
        isGrounded();  //Check using Raycast if the player is grounded to avoid air-jump.
    }

    void Movement()
    {
        float moveSpeed = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if ((moveSpeed < 0 && transform.localScale.x < 0) || (moveSpeed > 0 && transform.localScale.x > 0))
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);

        _rigid.velocity = new Vector2(moveSpeed * speed, _rigid.velocity.y);
        _anim.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

        if (CrossPlatformInputManager.GetButton("Jump") && on_ground == true)
        {
            _anim.SetTrigger("jump");
            JumpAnimationRoutine();
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            

            on_ground = false;
            need_jump_reset = true;
            StartCoroutine(NeedJumpResetRoutine());
        }
    }

    void isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, ground_layer.value);
        //(1 << 8) layermask is 32-bit int array. To make layermask = 8(ground layer) , we need to bit-shift 1

        //Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green); //Raycast Line Drawe

        if (hit.collider != null)
        {
            Debug.Log("hit:" + hit.collider.name); //Raycast collision check

            if (need_jump_reset == false)
                on_ground = true;
        }
    }

    IEnumerator NeedJumpResetRoutine()
    {
        yield return new WaitForSeconds(0.1f); //wait 10th of second
        need_jump_reset = false;
    }

    IEnumerator JumpAnimationRoutine()
    {
        
        yield return new WaitForSeconds(0.30f);
    }
}
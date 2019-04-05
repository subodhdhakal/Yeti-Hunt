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
 
    // Start is called before the first frame update
    void Start()
    {
         _rigid = this.GetComponent<Rigidbody2D>();
        _anim= this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }
    
    private void run()
    {
        float moveSpeed = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if ((moveSpeed < 0 && transform.localScale.x < 0) || (moveSpeed > 0 && transform.localScale.x > 0))
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y, transform.localScale.z);

        _rigid.velocity = new Vector2(moveSpeed * speed, _rigid.velocity.y);
        _anim.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));

    }

}
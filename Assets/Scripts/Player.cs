using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D _rig;
    Animator _player;
 
    // Start is called before the first frame update
    void Start()
    {
         _rig = GetComponent<Rigidbody2D>();
        _player = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        run();
    }
    
    private void run()
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector2 playervelocity = new Vector2(controlThrow, _rig.velocity.y);
            _rig.velocity = playervelocity;
        }
    }
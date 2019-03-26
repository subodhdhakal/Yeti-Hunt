using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D _rig;
    private Animator _player;
 
    // Start is called before the first frame update
    void Start()
    {
         _rig = this.GetComponent<Rigidbody2D>();
        _player= this.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        run();
    }
    
    private void run()
        {
        if (Input.GetKeyDown("a"))
            _player.SetTrigger("run");
        }
    }
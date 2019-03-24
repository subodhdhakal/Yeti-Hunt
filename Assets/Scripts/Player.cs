using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public string run_trigger;
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
            if(Input.GetKey("left"))
            {
                _player.SetTrigger(run_trigger);
            }
        

    }
}

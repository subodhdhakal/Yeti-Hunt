using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public float timeCounter = 0f;
    public float speed;
    public float width;
    public float height;
    public float depth;
    public Transform lookAtTarget;
    public bool lookAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
       // speed = 5;
     //   width = 20;
      //  height = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        //float x = Mathf.Cos(timeCounter);
        //float y = Mathf.Sin(timeCounter);
        float z = 0;
        //transform.RotateAround(Vector3., Vector2.right, 10f * Time.deltaTime);
        //transform.RotateAroundLocal(Vector3.zero, 10f * Time.deltaTime);
        transform.position = new Vector3(Mathf.Cos(timeCounter)*width, Mathf.Sin(timeCounter)*height, z+depth) + lookAtTarget.position;
        if (lookAtPlayer == true)
        {
            transform.LookAt(lookAtTarget);
        }
      //  transform.LookAt(Vector2.zero);
    }
}

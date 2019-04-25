using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    public Transform pos;

    public void Start()
    {
        this.transform.position = new Vector2(this.transform.position.x, pos.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.diamonds += gems;
                Destroy(this.gameObject);
            }
        }
           
    }
}

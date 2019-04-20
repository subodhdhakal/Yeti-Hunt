using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerInstantiationPoint;
    bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning)
            StartCoroutine(SpawnPlayerRoutine());
    }

    IEnumerator SpawnPlayerRoutine()
    {
        isSpawning = true;
        Debug.Log("Spawning in 5 seconds...");
        Instantiate(player, playerInstantiationPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(7.0f);
        isSpawning = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeployer : MonoBehaviour
{
    private static EnemyDeployer _instance;

    public static EnemyDeployer Instance
    {
        get
        {
            if (_instance == null)
            {
                //UIManager is null
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        deployed1 = false;
        deployed2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!deployed1 & counter1 < 2)
            StartCoroutine(deployEnemy(1));
        if (!deployed2 & counter2 < 2)
            StartCoroutine(deployEnemy(2));
    }

    public GameObject enemy1;
    public GameObject enemy2;
    public int counter1=0;
    public int counter2=0;
    public bool deployed1;
    public bool deployed2;
    [SerializeField]
    private int maxCount = 1;
    public Transform point1;
    public Transform point2;


    IEnumerator deployEnemy(int type)
    {
        if (type == 1)
            deployed1 = true;
        else
            deployed2 = true;

        float waitTime = Random.Range(5f, 10f);
        yield return new WaitForSeconds(waitTime);
        if (type == 1)
        {
            Instantiate(enemy1, point1.position, Quaternion.identity);
            counter1++;
            deployed1 = false;
        }
        else
        {
            Instantiate(enemy2, point2.position, Quaternion.identity);
            counter2++;
            deployed2 = false;
        }
    }

    
}

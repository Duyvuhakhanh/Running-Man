using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScpript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScpript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle ()
    {
        if (playerControllerScpript.gameOver == false)
        {
            Instantiate(obstaclePrefabs[Random.RandomRange(0, obstaclePrefabs.Length)], spawnPos, gameObject.transform.rotation);
        }
        
    }
}

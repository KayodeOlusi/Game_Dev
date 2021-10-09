using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Reference a game object
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Reference an object's script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        // InvokeRepeating is used to call/invoke a method overtime on intervals
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (playerControllerScript.gameOver == false) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }   
    }
}

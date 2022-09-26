using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(30,0,0);
    private float startDelay = 2;
    private float repeatInterval = 1.5f;
    private PlayerControl playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
            if (playerControllerScript.IsGameOver != true)
            Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
    }
}

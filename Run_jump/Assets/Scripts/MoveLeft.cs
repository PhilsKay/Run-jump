using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20.0f;
    private PlayerControl playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.IsGameOver != true)
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}

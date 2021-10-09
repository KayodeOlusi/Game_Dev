using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Reference the enemy Rigidbody
        enemyRb = GetComponent<Rigidbody>();

        //Reference the player object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 variable to calculate the length between the enemy and player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Movement of enemy towards the player
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    public float speed = 5.0f;
    private Rigidbody playerRb;
    public bool hasPowerUp = false;
    private float powerUpStrength = 15.0f;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        // Find the "Focal Point" Game Object
        focalPoint = GameObject.Find("Focal Point");

        // Get Rigidbody Component of player
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);

        // The powerup indicator position = player position
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);

            // make the Powerup indicator active
            powerUpIndicator.gameObject.SetActive(true);

            // Call the Method
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    // A method for doing something outside the update method
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;

        // make the Powerup indicator inactive
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // Get the Rigidbody component of the enemy
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            //Get the position we want to push the enemy to
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("The Player just collided with" + collision.gameObject.name + "and is set to" + hasPowerUp);
        }
    }
}

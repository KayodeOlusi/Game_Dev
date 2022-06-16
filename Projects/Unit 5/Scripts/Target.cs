using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minForce = 12;
    private float maxForce = 16;
    private float torqueRange = 10;
    private float xrandomPos = 4;
    private float yMinRanPos = -6;
    private float yMaxRanPos = -2;
    public int pointScore;
    public ParticleSystem explosivePar;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomPos();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosivePar, transform.position, explosivePar.transform.rotation);
            gameManager.UpdateScore(pointScore);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    Vector3 RandomPos()
    {
        // Get random position
        return new Vector3(Random.Range(-xrandomPos, xrandomPos), Random.Range(yMinRanPos, yMaxRanPos));
    }
}

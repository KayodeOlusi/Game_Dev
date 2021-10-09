using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Get the current/default position of the background
        startPos = transform.position;
        // Get the Components width and divide by 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;    
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the position at the x-axis after game has started is less than the default position
        if ( transform.position.x < startPos.x - 50 ) {
            transform.position = startPos;
        }
    }
}

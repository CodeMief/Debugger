using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    [SerializeField] Vector3 startPoint, endPoint;
    [SerializeField] Transform topPos, bottomPos;

    // Movement speed in units per second.
    [SerializeField] public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = topPos.position;
        endPoint = bottomPos.position;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPoint, endPoint);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);
    }

    private void CheckPosition()
    {
        if (transform.position == endPoint)
        {
            Vector3 temp = endPoint;
            endPoint = startPoint; 
            startPoint = temp;
            startTime = Time.time;
        }
    }
}

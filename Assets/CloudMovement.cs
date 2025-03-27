using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 3;
    public float deadZone = -40;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy when off-screen 
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            Debug.Log("Cloud Deleted");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Rigidbody projectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.right * 10);
        }
    }
}

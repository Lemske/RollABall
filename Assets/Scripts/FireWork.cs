using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public float speed = 0;
    public float height = 10;
    public ParticleSystem explosion;

    private Vector3 movement;
    private Rigidbody rb;
    void Start()
    {
        movement = new Vector3(0.0f, 1.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * speed);
        if (transform.position.y > height)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * -speed;
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -15)
            Destroy(gameObject);
    }


}

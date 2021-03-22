using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public float moveSpeed=3f;
    bool MoveRight = true;
    public float range = 5f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > range)
            MoveRight = false;
        if (transform.position.x < -range)
            MoveRight = true;
        if (MoveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(1f, 1f);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(-1f,1f);
        }

    }
}

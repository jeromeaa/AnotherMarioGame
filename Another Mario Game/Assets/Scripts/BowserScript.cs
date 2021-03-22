using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserScript : MonoBehaviour
{
    float moveSpeed = 3f;
    bool MoveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7f)
            MoveRight = false;
        if (transform.position.x < -7f)
            MoveRight = true;
        if (MoveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
}

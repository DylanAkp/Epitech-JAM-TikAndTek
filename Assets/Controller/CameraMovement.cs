using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 0.5f;

    private Rigidbody2D rb;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime > 3.0f)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}

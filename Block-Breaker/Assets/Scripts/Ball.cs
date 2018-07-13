using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Paddle paddle;
    bool hasStarted = false;
    Vector3 paddleToBallVector;
    Rigidbody2D rigidbody;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                rigidbody.velocity = new Vector2(Random.Range(0.1f, 3f), 10f);
                hasStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rigidbody.velocity += tweak; 

        if (hasStarted)
        {
            audio.Play();
        }

    }
}

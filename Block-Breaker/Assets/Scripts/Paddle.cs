using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

	private void Start()
	{
        ball = FindObjectOfType<Ball>();
	}

	void Update () {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void MoveWithMouse () {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.8f, 15.2f);
        transform.position = paddlePos;
    }

    void AutoPlay () {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float ballPosition = ball.transform.position.x;
        paddlePos.x = Mathf.Clamp(ballPosition, 1f, 15f);
        transform.position = paddlePos;;
    }
}

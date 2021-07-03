using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private PaddleMovement Paddle;
	private Vector3 PaddleToBall;
	private Rigidbody2D rigidbody2D;
	private bool MouseClicked = false;
	private Vector2 BallVelocity;
	public float BallSpeed;
	private AudioSource AudioSource;

	void Start () {
		AudioSource = gameObject.GetComponent<AudioSource> ();
		Paddle = GameObject.FindObjectOfType<PaddleMovement>();
		GetPaddleBallDiff();
		BallVelocity = new Vector2 (Random.Range(-6f,6f), BallSpeed);
	}
	
	void Update () {
		BallStickToPaddle ();
		LaunchBall ();
	}

	void OnCollisionEnter2D(){
		if (MouseClicked) {
			AudioSource.Play();
		}
	}

	void GetPaddleBallDiff(){ //gets the relative vector distance between ball and paddle
		PaddleToBall = transform.position - Paddle.transform.position;
	}

	void BallStickToPaddle(){ //transform of the ball is the transform of the paddle plus the relative distance
		if (MouseClicked == false) {
			transform.position = Paddle.transform.position + PaddleToBall;
		}
	}

	void LaunchBall(){
		if (Input.GetMouseButtonDown (0) && MouseClicked == false) {
			rigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
			rigidbody2D.velocity = BallVelocity;
			MouseClicked = true;
		}
	}
}

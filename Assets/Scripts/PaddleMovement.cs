using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
	private float MousePosition;
	private Vector3 PaddlePosition;
	public bool autoPlay = false;
	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		if (!autoPlay) {
			MovePaddle ();
		} 
		else {
			AutoPlay ();
		}
	}

	void MovePaddle(){
		MousePosition = (Input.mousePosition.x / Screen.width * 16) - 8; //mouse position in pixels devided by the screen width to give blocks minus 8 to give center.
		PaddlePosition= new Vector3 (Mathf.Clamp(MousePosition, -5.66f, 5.66f), transform.position.y, 0);
		transform.position = PaddlePosition;
	}

	void AutoPlay(){
		Vector3 ballPosition = ball.transform.position;
		PaddlePosition= new Vector3 (Mathf.Clamp(ballPosition.x, -5.66f, 5.66f), transform.position.y, 0);
		transform.position = PaddlePosition;
	}
}

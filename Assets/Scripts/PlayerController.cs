using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private CharacterController controller;
	public float speed;
	private float verticalSpeed = 0.0f ;
	private Vector3 moveVector;
	private float gravity = 12.0f;
	private float animationDuration = 3.0f;
	private bool isDead = false;
	private float startTime;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		moveVector = Vector3.zero;
		if (controller.isGrounded) {
			verticalSpeed = -0.5f;
		} else {
			verticalSpeed -= gravity;
		}
		moveVector.x = Input.GetAxisRaw ("Horizontal")*speed;
		moveVector.y = verticalSpeed;
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);

	}
	public void SetSpeed(float modifier){
		speed = 5 + modifier;
	}
	void OnControllerColliderHit(ControllerColliderHit Hit){
		if (Hit.point.z > transform.position.z + controller.radius)
			Death ();
	}
	void Death()
	{
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}
}

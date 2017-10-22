using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float walkSpeed;
	public float runSpeed;
	float move;
	float runMovement;
	float jumpMovement;
	float crouchMovement;
	Rigidbody myRB;
	Animator myAM;
	Quaternion playerAngle;
	bool facingRight;
	void Start () {
		myRB = GetComponent<Rigidbody> ();
		myAM = GetComponent<Animator> ();
	}
	void Update()
	{
		getInput();
	//	float rotAngle=180;
	//	transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.up);
	//	Debug.Log(rotAngle);
		//Quaternion targetRotation = Quaternion.identity;
		//transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningRate * Time.deltaTime);
        //rigidbody.WakeUp();
	}
	void getInput()
	{
		move = Input.GetAxisRaw("Horizontal");
		runMovement = Input.GetAxisRaw("Run");
		jumpMovement = Input.GetAxisRaw("Jump");
		crouchMovement = Input.GetAxisRaw("Crouch");
		myAM.SetFloat("speed",Mathf.Abs(move));
		myAM.SetFloat("sprint", runMovement);
		myAM.SetFloat("jump", jumpMovement);
		myAM.SetFloat("crouch", crouchMovement);
		playerAngle=transform.localRotation;
	}
		void FixedUpdate () {
		if (runMovement > 0) 
			movePlayer(runSpeed);
		else 
			movePlayer(walkSpeed);	
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	void movePlayer(float speed)
	{
		if(playerAngle.y<0.9)
			myRB.velocity = new Vector3(move * speed, myRB.velocity.y, 0);
		else if(playerAngle.y>0.9)
			myRB.velocity = new Vector3(0, myRB.velocity.y, -(move * speed));
	}
	void Turn()
	{	
 
	}
	void Flip() {	
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.z *= -1;
		transform.localScale = scale;
	}
}

//if (!facingRight)
        //     degree += 90f;
        // if (facingRight)
        // 	degree -= 90f;
        // angle = Mathf.LerpAngle(transform.rotation.y, degree, Time.deltaTime);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime);
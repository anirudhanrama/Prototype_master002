using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnController : MonoBehaviour {
	public event Action OnCollider;
	public GameObject player;
	public Camera camera;
	public float rotAngle=180f;
	void OnTriggerEnter()
	{
		//OnCollider();
		player.transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.up);
		Debug.Log("Triggered!");
	}
	void OnTriggerExit()
	{
		if(rotAngle==180)
			rotAngle=90;
		else
			rotAngle=180;
	}	
}
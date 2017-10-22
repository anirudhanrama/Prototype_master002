using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public Transform target;
	public float smoothing=5;
	public GameObject player;
	Vector3 offset;
	void Start () {
		offset = transform.position - target.position;
	}
	void FixedUpdate () {
		if (player.transform.localRotation.y < 0.9) {
			Vector3 targetCameraPosition = target.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
			transform.LookAt (target);
		} else if(player.transform.localRotation.y > 0.9){
			offset.x = -40;
			offset.y = 20;
			offset.z = 0;
			Vector3 targetCameraPosition = target.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
			transform.LookAt (target);
		}
	}
}

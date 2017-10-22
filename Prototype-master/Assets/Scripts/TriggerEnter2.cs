using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter2 : MonoBehaviour {

	public Camera camera;
	public GameObject gameobject;
	
	public void OnTriggerStay()
	{
		if (Input.GetAxis("Horizontal")<0) {
			if (camera.fieldOfView < 60) {
				camera.fieldOfView = camera.fieldOfView + 0.1f;
			} 
		}
		else if (Input.GetAxis("Horizontal")>0){
			if (camera.fieldOfView > 45) {
				camera.fieldOfView = camera.fieldOfView - 0.1f;
			} 
		}
	}
	void OnTriggerExit()
	{
		StartCoroutine(ExitCameraAdjust());	
	}
	IEnumerator ExitCameraAdjust()
	{
		if (Input.GetAxis("Horizontal")<0)
			while(camera.fieldOfView<60){
				camera.fieldOfView +=0.1f;
				yield return null;
			}
	}
}
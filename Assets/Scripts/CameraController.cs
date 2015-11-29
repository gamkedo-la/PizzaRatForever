using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public PizzaRatController player;
	
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position; 
		
	}
	
	// LateUpdate is called once per frame, after all other items have been processed
	void LateUpdate () {

		if(player != null)
		{
			Vector3 cameraGoalPos;
			float driftK;
			if(player.isDead) {
				driftK = 0.8f;
				float orbitPaceMult = 0.2f;
				float camOrbitRange = 28.0f;
				float camOrbitHeightPerc = 0.7f;
				cameraGoalPos = player.transform.position + offset * camOrbitHeightPerc
				+ Vector3.right * Mathf.Cos(Time.time * orbitPaceMult) * camOrbitRange
					+ Vector3.forward * Mathf.Sin(Time.time * orbitPaceMult) * camOrbitRange;
			} else {
				driftK = 0.9f;
				cameraGoalPos =player.transform.position + offset;
			}
			transform.position = driftK * transform.position +
				(1.0f-driftK) * cameraGoalPos;

			if(player.isDead) {
				transform.LookAt(player.transform.position);
			}
		}
	}
}

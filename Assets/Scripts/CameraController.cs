using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position; 
		
	}
	
	// LateUpdate is called once per frame, after all other items have been processed
	void LateUpdate () {
		
		transform.position = player.transform.position + offset; //moves the camera around, keeping it the correct distance from the player
		
	}
}

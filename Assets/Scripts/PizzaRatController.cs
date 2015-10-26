using UnityEngine;
using System.Collections;

public class PizzaRatController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>(); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//move PizzaRat when buttons are pressed
	void FixedUpdate(){

		float moveForward = Input.GetAxis("Vertical") * movementSpeed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		
		transform.Rotate (0, rotation, 0);
		transform.Translate(-moveForward, 0, 0);
		
	}
}

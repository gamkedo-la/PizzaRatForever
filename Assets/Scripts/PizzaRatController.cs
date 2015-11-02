using UnityEngine;
using System.Collections;

public class PizzaRatController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;

	public GameObject grabPoint;
	public GameObject pizza;
	
	private Rigidbody rb;
	private Vector3 originalGrabPoint;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>(); 
	
	}


	//move PizzaRat when buttons are pressed
	void FixedUpdate(){

		//originalGrabPoint = grabPoint.transform.localPosition; //saving grabPoint's original position for snap-back
		
		float moveForward = Input.GetAxis("Vertical") * movementSpeed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		
		transform.Rotate (0, rotation, 0);
		transform.Translate(-moveForward, 0, 0);

		if (Input.GetButtonDown ("Fire3")){

			grabPizza();
			
		}


		if (Input.GetButtonUp("Fire3"))
		{

			ungrabPizza(); //if grab button not down, snap back to original spot

		}
		
	}

	//extend GrabPoint in order to grab onto pizza
	void grabPizza(){

		Debug.Log ("Pizza Grabbed!");
		grabPoint.transform.position = grabPoint.transform.position + (transform.right * -1.0f);

		print (rb.velocity);

		//pizza.GetComponent<Rigidbody>().AddForce(rb.velocity);

	}

	//simply reverse the grab
	void ungrabPizza(){
		
		Debug.Log ("Pizza unGrabbed!");
		grabPoint.transform.position = grabPoint.transform.position + (transform.right * 1.0f);  
		
	}


}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PizzaRatController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;
	public float pizzaForceMultiplier;

	public GameObject grabPoint;
	public GameObject pizza;

	public static Text debugTextOut;
	
	private Rigidbody rb;
	private Vector3 originalGrabPoint;
	private bool dragging;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>(); 
		dragging = false;

		debugTextOut = GameObject.Find ("DebugText").GetComponent<Text>();
	
	}


	//move PizzaRat when buttons are pressed
	void FixedUpdate(){

		//originalGrabPoint = grabPoint.transform.localPosition; //saving grabPoint's original position for snap-back
		
		float moveForward = Input.GetAxis("Vertical") * movementSpeed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		if(dragging) {
			dragPizza();
			if(moveForward > 0.0f) { // disallow pushing of pizza, that's cheating!
				moveForward = 0.0f;
			} else {
				moveForward *= 0.15f; // decrease reverse speed when dragging
			}
		}
		
		transform.Rotate (0, rotation, 0);
		transform.Translate(0, 0, moveForward);

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

		grabPoint.transform.position = grabPoint.transform.position + (transform.forward * 1.0f);

		if (detectPizza())
		{
			// Debug.Log("pizza has been located!");
			//dragPizza();

			dragging = true;
			grabPoint.transform.parent = pizza.transform; //attach grabPoint to pizza

		}
		else
		{
			// Debug.Log ("pizza not located!");
		}
			

		//pizza.GetComponent<Rigidbody>().AddForce(rb.velocity);

	}

	void dragPizza(){

		Vector3 pizzaVector = (transform.position - pizza.transform.position) * pizzaForceMultiplier; //first, find the right direction to drag
		// Debug.Log (pizzaVector);

		pizza.GetComponent<Rigidbody>().AddForceAtPosition(pizzaVector, grabPoint.transform.position); //then apply the force to the grabbed part of the pizza

	}

	bool detectPizza(){

		Collider[] hitColliders = Physics.OverlapSphere(grabPoint.transform.position, 1.0f);

		bool found = false;

		foreach (Collider col in hitColliders)
		{
			if (col.gameObject.CompareTag("Pizza"))
			{
				found = true;
			}

		}

		return found;

	}

	//simply reverse the grab
	void ungrabPizza(){

		dragging = false;
		// Debug.Log ("Pizza unGrabbed!");

		grabPoint.transform.parent = transform; // retract to mouse
		grabPoint.transform.position = transform.position + transform.forward;  


		//grabPoint.transform.position = grabPoint.transform.position + (transform.forward * -1.0f);  
		
	}


}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PizzaRatController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;
	public float pizzaForceMultiplier;

	// audio properties
	public AudioClip yesPizzaSound;
	private AudioSource yesPizzaAudio;
	private bool yesHasPlayed = false;

	public bool isDead;

	public GameObject grabPoint;
	private GameObject pizza = null;

	private Rigidbody rb;
	private Vector3 originalGrabPoint;
	private bool dragging;

	public void Die() {
		if(isDead) {
			return;
		}
		Vector3 flatScale = transform.localScale;
		flatScale.y = 0.1f;
		transform.localScale = flatScale;
		isDead = true;
		ungrabPizza();
		// todo also here: play sound effect for rat dying
	}

	// Use this for initialization
	void Start () {

		isDead = false;

		rb = GetComponent<Rigidbody>(); 

		dragging = false;
		// get audio components
		yesPizzaAudio = GetComponent<AudioSource>();
	
	}


	//move PizzaRat when buttons are pressed
	void FixedUpdate(){
		if(isDead) {
			return;
		}

		// less harsh than squashing the rat from being out of bounds
		GameController.instance.forceInBounds(this.gameObject);

		//originalGrabPoint = grabPoint.transform.localPosition; //saving grabPoint's original position for snap-back
		
		float moveForward = Input.GetAxis("Vertical") * movementSpeed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		if(dragging && pizza != null) {
			if(!yesHasPlayed) { // bool so it plays only once
				yesPizzaAudio.clip = yesPizzaSound;
				yesPizzaAudio.Play();
				yesHasPlayed = true;
			}
			dragPizza();
			if(moveForward > 0.0f) { // disallow pushing of pizza, that's cheating!
				moveForward = 0.0f;
			} else {
				moveForward *= 0.15f; // decrease reverse speed when dragging
			}
		}
		
		transform.Rotate (0, rotation, 0);
		transform.Translate(0, 0, moveForward);

		if (pizza != null){
			if (Input.GetButtonDown ("Fire3")){
				grabPizza();

			}
	
			if (Input.GetButtonUp("Fire3")){
				ungrabPizza(); //if grab button not down, snap back to original spot
				yesHasPlayed = false;
				yesPizzaAudio.Stop ();
			}
		
		}



	}

	public void AssignPizza(GameObject pizzaRef){
		
		pizza = pizzaRef;
		
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

		//Debug.Log ("words");

		Vector3 pizzaVector = (transform.position - pizza.transform.position) * pizzaForceMultiplier; //first, find the right direction to drag
		// Debug.Log (pizzaVector);

		if(pizza != null){
			pizza.GetComponent<Rigidbody>().AddForceAtPosition(pizzaVector, grabPoint.transform.position); //then apply the force to the grabbed part of the pizza
		}
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
	public void ungrabPizza(){

		dragging = false;
		yesPizzaAudio.Stop();
		// Debug.Log ("Pizza unGrabbed!");

		grabPoint.transform.parent = transform; // retract to mouse
		grabPoint.transform.position = transform.position + transform.forward;  


		//grabPoint.transform.position = grabPoint.transform.position + (transform.forward * -1.0f);  
		
	}


}

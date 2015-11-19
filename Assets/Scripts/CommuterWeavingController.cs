using UnityEngine;
using System.Collections;

public class CommuterWeavingController : MonoBehaviour {

	public GameObject shoePrefabL;
	public GameObject shoePrefabR;
	public float shoeDropPauseTime = 2.0f;
	public float weaveMagnitude = 1.0f;

	//public Camera camera;
	private bool leftFoot;

	//bool to weave back and forth
	private bool weaveLeft;
	private float ourRotation;


	// Use this for initialization
	void Start () {

		//Camera camera = GetComponent<Camera>();

//		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 5.0f)); //left side of the screen, midway up, at camera's height
//		transform.position = p;
		Destroy(gameObject, 22.0f);

		ourRotation = transform.rotation.y;

		InvokeRepeating("DropShoe", 2.0f, shoeDropPauseTime);
		InvokeRepeating("WeaveCommuter", 1.9f, shoeDropPauseTime);

		leftFoot = true;
		weaveLeft = true;

	}
		
	// Update is called once per frame
	void Update () {

		walkCommuter();
	
	}


	void FixedUpdate () {




	}

	//the commuter walks forward, dropping shoes appropriately
	void walkCommuter(){

		
		transform.position += transform.forward * 6 * Time.deltaTime;

	}

	// commuter turns back and forth, increasing the magnitude each time
	void WeaveCommuter(){
		if (weaveLeft){
			transform.Rotate(Vector3.up, ourRotation);
		}
		else{
			transform.Rotate(Vector3.up, -ourRotation);
		}
		ourRotation += weaveMagnitude; // increase weave magnitude (variation)
		weaveLeft = !weaveLeft; // switch direction
	}




	void DropShoe (){

		GameObject shoe = Instantiate((leftFoot ? shoePrefabL : shoePrefabR),
		                              transform.position + transform.right * 1.5f * (leftFoot ? 1.0f : -1.0f), transform.rotation) as GameObject;
		leftFoot = !leftFoot; //switch feet

	}
}

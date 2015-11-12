using UnityEngine;
using System.Collections;

public class CommuterController : MonoBehaviour {

	public GameObject shoePrefab;
	public float shoeDropPauseTime = 2.0f;
	//public Camera camera;

	private bool leftFoot;

	// Use this for initialization
	void Start () {

		//Camera camera = GetComponent<Camera>();

//		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 5.0f)); //left side of the screen, midway up, at camera's height
//		transform.position = p;


		InvokeRepeating("DropShoe", 2.0f, shoeDropPauseTime);

		leftFoot = true;

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

	void DropShoe (){

		GameObject shoe = Instantiate(shoePrefab,transform.position + transform.right * 1.5f * (leftFoot ? 1.0f : -1.0f), transform.rotation) as GameObject;
		leftFoot = !leftFoot; //switch feet

	}
}

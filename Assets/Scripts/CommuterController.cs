using UnityEngine;
using System.Collections;

public class CommuterController : MonoBehaviour {

	public GameObject shoePrefab;
	public float shoeDropPauseTime = 2.0f;
	//public Camera camera;



	// Use this for initialization
	void Start () {

		//Camera camera = GetComponent<Camera>();

//		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 5.0f)); //left side of the screen, midway up, at camera's height
//		transform.position = p;

		pickCommuterDirection();
		pickCommuterStartingSpot();

		InvokeRepeating("DropShoe", 2.0f, shoeDropPauseTime);

	}

	//decide whether the commuter will enter from the left, right, top, or bottom edge of the screen
	void pickCommuterDirection(){





	}

	//decide where along the edge of the screen a commuter will start walking
	void pickCommuterStartingSpot(){







	}





	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate () {

		walkCommuter();


	}

	//the commuter walks forward, dropping shoes appropriately
	void walkCommuter(){




	}

	void DropShoe (){

		GameObject shoe = Instantiate(shoePrefab) as GameObject;
		shoe.transform.position = transform.position; 


	}
}

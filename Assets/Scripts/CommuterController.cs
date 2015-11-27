using UnityEngine;
using System.Collections;

public class CommuterController : MonoBehaviour {

	public GameObject shoePrefabL;
	public GameObject shoePrefabR;
	public float shoeDropPauseTime = 2.0f;
	

	private bool leftFoot;

	// Use this for initialization
	void Start () {

		//Camera camera = GetComponent<Camera>();

//		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 5.0f)); //left side of the screen, midway up, at camera's height
//		transform.position = p;
		Destroy(gameObject, 22.0f);

		InvokeRepeating("DropShoe", 2.0f, shoeDropPauseTime);

		leftFoot = true;
	

	}
		
	// Update is called once per frame
	void Update () {

		walkCommuter();

		if (GameController.instance.inBoundsCheck(this.gameObject) == false)
		{
			
			Destroy(this.gameObject); //commuter has walked out of bounds
			
		}
	
	
	}
	


	void FixedUpdate () {




	}

	//the commuter walks forward, dropping shoes appropriately
	void walkCommuter(){

		
		transform.position += transform.forward * 6 * Time.deltaTime;

	}

	void DropShoe (){

		GameObject shoe = Instantiate((leftFoot ? shoePrefabL : shoePrefabR),
		                              transform.position + transform.right * 1.5f * (leftFoot ? 1.0f : -1.0f), transform.rotation) as GameObject;
		leftFoot = !leftFoot; //switch feet

	}
}

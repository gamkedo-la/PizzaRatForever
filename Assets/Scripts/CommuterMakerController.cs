using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommuterMakerController : MonoBehaviour {

	public GameObject subwayFloor;
	public GameObject[] commuter; // types of commuters
	public int numCommuterTypes; // length of commuter array
	public int type;
	//public GameObject[] commuterType;

	public float floorWidth;
	public float floorHeight;

	public string commuterDirection;

	public float shortestWait = 10.0f;
	public float longestWait = 20.0f;

	// Use this for initialization
	void Start () {
	
		//figure out where the edges of the floor are.
		floorWidth = subwayFloor.transform.localScale.x / 2;
		floorHeight = subwayFloor.transform.localScale.y / 2;

		numCommuterTypes = commuter.Length;

		StartCoroutine (teleportAndSpawn());
		
	}

	IEnumerator teleportAndSpawn(){
		while (true){

			float shortestAdjustedWait = shortestWait / GameController.instance.level;
			float longestAdjustedWait = longestWait / GameController.instance.level;
		
			yield return new WaitForSeconds(Random.Range (shortestAdjustedWait, longestAdjustedWait));

			//pick left, right, top, or bottom edge of the floor.
			pickCommuterSide();
			
			//pick a starting position along the floor's edge
			pickCommuterPosition();

			type = Random.Range (0, (commuter.Length));
			//commuter = commuterType[type];
			GameObject newCommuter = Instantiate(commuter[type], transform.position, transform.rotation) as GameObject;

		}
	}

	void pickCommuterSide(){

		int side = Random.Range (0, 4);

		switch (side){
		
		//left side, facing right
		case 0: 
			transform.position = new Vector3(-floorWidth, transform.position.y, 0);
			commuterDirection = "right";
			transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.up); //about-face
			break;
		//right side, facing left
		case 1:
			transform.position = new Vector3(floorWidth, transform.position.y, 0);
			commuterDirection = "left";
			transform.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up); //about-face
			break;
		//top side, facing down
		case 2:
			transform.position = new Vector3(0, transform.position.y, floorHeight); 
			commuterDirection = "down";
			transform.rotation = Quaternion.AngleAxis(180.0f, Vector3.up); //about-face
			break;
		//bottom side, facing up
		case 3:
			transform.position = new Vector3(0, transform.position.y, -floorHeight);
			commuterDirection = "up";
			transform.rotation = Quaternion.AngleAxis(0.0f, Vector3.up); //about-face
			break;
		default:
			Debug.Log ("something broke.");
			commuterDirection = "up";
			break;

		}

		// Debug.Log (commuterDirection);



	}

	void pickCommuterPosition(){

		//walking horizontally
		if (commuterDirection == "left" || commuterDirection == "right"){

			float randomVertPos = Random.Range(-floorHeight, floorHeight);
			transform.position = new Vector3(transform.position.x, transform.position.y, randomVertPos); //move up or down along the edge of the floor

		}
		//walking vertically
		else{

			float randomHorPos = Random.Range(-floorWidth, floorWidth);
			transform.position = new Vector3(randomHorPos, transform.position.y, transform.position.z); //move right or left along the edge of the floor
		}


	}

	void FixedUpdate(){



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

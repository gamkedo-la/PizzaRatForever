using UnityEngine;
using System.Collections;

public class CommuterMakerController : MonoBehaviour {

	public GameObject subwayFloor;
	public GameObject commuter;

	public float floorWidth;
	public float floorHeight;

	public string commuterDirection;



	// Use this for initialization
	void Start () {
	
		//figure out where the edges of the floor are.
		floorWidth = subwayFloor.transform.localScale.x / 2;
		floorHeight = subwayFloor.transform.localScale.z / 2;

		StartCoroutine (teleportAndSpawn());
	}

	IEnumerator teleportAndSpawn(){
		while (true){
		
			yield return new WaitForSeconds(Random.Range (1.3f, 2.4f));

			//pick left, right, top, or bottom edge of the floor.
			pickCommuterSide();
			
			//pick a starting position along the floor's edge
			pickCommuterPosition();

			GameObject newCommuter = Instantiate(commuter, transform.position, transform.rotation) as GameObject;

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

		Debug.Log (commuterDirection);



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

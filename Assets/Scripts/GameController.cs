using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public PizzaRatController pizzaRat;
	public GameObject pizzaPrefab;
	public GameObject subwayFloor;

	public float pizzaPlacementRadius = 10.0f; //how far should the pizza be away from the rat?

	public float floorWidth;
	public float floorHeight;

	public Text scoreTextOut;

	private int score = 0;


	// Use this for initialization
	void Start () {

		if (instance){
			Destroy(instance);
		}

		scoreTextOut.text = "Score: 0";

		instance = this;

		//figure out where the edges of the floor are.
		floorWidth = subwayFloor.transform.localScale.x / 2;
		floorHeight = subwayFloor.transform.localScale.y / 2;


		PlacePizza();

	}

	public void ScorePizza(){

		score++;
		scoreTextOut.text = "Score: " + score;
		pizzaRat.grabPoint.transform.parent = pizzaRat.transform;
		PlacePizza();

	}



	void PlacePizza(){

		Vector3 newPosition = RandomSpot();

		GameObject newPizza = Instantiate(pizzaPrefab) as GameObject;

		newPizza.transform.position = newPosition;
		pizzaRat.AssignPizza(newPizza);


	}

	//return a random location on the subway floor that is not within a certain radius from the rat
	Vector3 RandomSpot(){

		bool acceptable = false;
		Vector3 newPos = new Vector3();

		while(!acceptable){

			float randomX = Random.Range (-floorWidth, floorWidth);
			float randomZ = Random.Range (-floorHeight, floorHeight);

			newPos = new Vector3(randomX, pizzaRat.transform.position.y+0.5f,randomZ);

			//check distance from pizzaRat
			if (Vector3.Distance(newPos, pizzaRat.transform.position) >= pizzaPlacementRadius){
				Debug.Log(Vector3.Distance(newPos, pizzaRat.transform.position));
				acceptable = true;
			}


		}
	
		return newPos;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
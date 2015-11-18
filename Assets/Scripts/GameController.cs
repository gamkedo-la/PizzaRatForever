using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public PizzaRatController pizzaRat;
	public GameObject pizzaPrefab;
	public GameObject subwayFloor;

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

		Debug.Log (floorWidth);
		Debug.Log (floorHeight);

		PlacePizza();

	}

	public void ScorePizza(){

		score++;
		scoreTextOut.text = "Score: " + score;
		PlacePizza();

	}



	void PlacePizza(){

		//bool acceptablePosition = false;

		//try the pizza in a different spot

		//GameObject newPizza = Instantiate(pizza) as GameObject;

		//Debug.Log (RandomSpot());

		Vector3 newPosition = RandomSpot();

		GameObject newPizza = Instantiate(pizzaPrefab) as GameObject;

		newPizza.transform.position = newPosition;
		pizzaRat.AssignPizza(newPizza);


	}

	//return a random location on the subway floor
	Vector3 RandomSpot(){

		//Debug.Log ("words");
		float randomX = Random.Range (-floorWidth, floorWidth);
		float randomZ = Random.Range (-floorHeight, floorHeight);

		Vector3 newPos = new Vector3(randomX, pizzaRat.transform.position.y+0.5f,randomZ);
		return newPos;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
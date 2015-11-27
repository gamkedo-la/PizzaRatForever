using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public PizzaRatController pizzaRat;
	public GameObject pizzaPrefab;
	public GameObject subwayFloor;

	public float pizzaPlacementRadius = 20.0f; //how far should the pizza be away from the rat?

	public float floorWidth;
	public float floorHeight;
	public float floorSizeIncrease = 10.0f;

	public Text scoreTextOut;
	public Text levelTextOut;
	public Text splashTextOut;
	public GameObject gameOverButton;

	private int score = 0;
	public int level = 1; //controls game difficulty
	private int pepperonis;


	// Use this for initialization
	void Start () {

		if (instance){
			Destroy(instance);
		}

		scoreTextOut.text = "Score: 0";
		levelTextOut.text = "Level: 1";
		splashTextOut.text = "";
		gameOverButton.SetActive(false);

		instance = this;

		FloorSizeCheck();

		PlacePizza();

	}

	public void RestartGame(){

		Application.LoadLevel(Application.loadedLevelName);

	}

	public bool inBoundsCheck(GameObject obj){

		bool inBounds = false;

		if ((obj.transform.position.x <= floorWidth && obj.transform.position.x >= -floorWidth) && (obj.transform.position.z <= floorHeight && obj.transform.position.z >= -floorHeight)){

			inBounds = true;

		}

		return inBounds;

	}
	

	public void ScorePizza(){

		score++;
		scoreTextOut.text = "Score: " + score;
		LevelUpCheck();
		pizzaRat.ungrabPizza();
		PlacePizza();

	}

	public void GameOver(){

		splashTextOut.text = "Game Over!";
		Destroy (pizzaRat.gameObject); //kill the rat
		gameOverButton.SetActive(true);

	}

	//only post if Splash Message is currently empty
	IEnumerator LevelUpAnnounce(){

		string levelUpWording = "Level Up!";

		if (splashTextOut.text == ""){

			splashTextOut.text = levelUpWording;
			yield return new WaitForSeconds(2.0f);

			if (splashTextOut.text == levelUpWording){

				splashTextOut.text = "";

			}

		}


	}

	void LevelUpCheck(){

		if (score % 3 == 0){
			level++;
			levelTextOut.text = "Level: " + level;
			StartCoroutine(LevelUpAnnounce());
			StretchSubwayFloor();
			pizzaPlacementRadius += 5.0f;
		}


	}

	void FloorSizeCheck(){

		//figure out where the edges of the floor are.
		floorWidth = subwayFloor.transform.localScale.x / 2;
		floorHeight = subwayFloor.transform.localScale.y / 2;

	}

	void StretchSubwayFloor(){

		subwayFloor.transform.localScale += new Vector3(floorSizeIncrease, 0.0f, floorSizeIncrease); //make subway floor 10 units bigger 
		FloorSizeCheck(); //update floor size variables
	}



	void PlacePizza(){

		Vector3 newPosition = RandomSpot();

		GameObject newPizza = Instantiate(pizzaPrefab) as GameObject;
		pepperonis = 3; //each new slice gets 3 pepperonis

		newPizza.transform.position = newPosition;
		pizzaRat.AssignPizza(newPizza);


	}

	public void PizzaSteppedOn(){

		pepperonis--;
		if (pepperonis == 0){
			GameOver();
		}

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
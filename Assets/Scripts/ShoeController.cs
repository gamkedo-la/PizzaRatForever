using UnityEngine;
using System.Collections;

public class ShoeController : MonoBehaviour {

	public float shoeKillTime = 1.0f;

	bool landedAlready = false;

	// Use this for initialization
	void Start () {

		Destroy(gameObject, 5.0f); //self-destruct just in case
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){

		if(landedAlready) { // don't kill player or pizza after landed
			return;
		}

		if (col.gameObject.CompareTag("Player")){
			GameController.instance.GameOver();
		}
		else if (col.gameObject.CompareTag("Pizza")){

			 Debug.Log ("Pizza stepped on!");
			//GameController.instance.PizzaSteppedOn();
			PepperoniManager pmScript = col.gameObject.GetComponent<PepperoniManager>();
			bool gameOver = pmScript.RemovePepperoni();

			if (gameOver){
				GameController.instance.GameOver();
			}

		}
		else{
			landedAlready = true;
			Invoke ("KillShoe", shoeKillTime);

		}
	
	}

	void KillShoe(){

		Destroy (this.gameObject);

	}
}
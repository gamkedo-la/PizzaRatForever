using UnityEngine;
using System.Collections;

public class PizzaScoreable : MonoBehaviour {

	void Start() {

	}


	void Update() {
		GameController.instance.forceInBounds(this.gameObject);


	}

	void OnTriggerEnter(Collider other){

		GameController.instance.ScorePizza();
		Debug.Log ("Goal");

		Destroy(gameObject); //will destroy pizza, which the script is on.

	}

}

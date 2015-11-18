using UnityEngine;
using System.Collections;

public class PizzaScoreable : MonoBehaviour {


	void OnTriggerEnter(Collider other){

		GameController.instance.ScorePizza();
		Debug.Log ("Goal");
		Destroy(gameObject); //will destroy pizza, which the script is on.


	}

}

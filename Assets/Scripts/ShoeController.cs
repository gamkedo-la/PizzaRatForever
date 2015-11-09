using UnityEngine;
using System.Collections;

public class ShoeController : MonoBehaviour {

	public float shoeKillTime = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){

		if (col.gameObject.CompareTag("Player")){

			Debug.Log ("Rat squashed!");

		}
		else if (col.gameObject.CompareTag("Pizza")){

			Debug.Log ("Pizza stepped on!");

		}
		else{

			Invoke ("KillShoe", shoeKillTime);

		}
	
	}

	void KillShoe(){

		Destroy (this.gameObject);

	}
}
using UnityEngine;
using System.Collections;

public class TitleFunctions : MonoBehaviour {

	public GameObject mainCanvas;
	public GameObject creditsCanvas;

	public void Start(){

		mainCanvas.SetActive(true);
		creditsCanvas.SetActive(false);

	}

	public void ToggleCredits(){

		creditsCanvas.SetActive(mainCanvas.activeSelf);
		mainCanvas.SetActive(mainCanvas.activeSelf==false); //invert

	}

	public void StartGame(){

		Application.LoadLevel("Level 1");

	}
}

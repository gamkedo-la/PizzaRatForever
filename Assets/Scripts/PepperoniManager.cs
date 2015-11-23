using UnityEngine;
using System.Collections;

public class PepperoniManager : MonoBehaviour {

	public GameObject [] peps;
	private int pepsLeft;

	void Start(){

		pepsLeft = peps.Length;

	}

	public bool RemovePepperoni(){

		if (pepsLeft <= 0){

			return true;

		}

		pepsLeft--;
		peps[pepsLeft].SetActive(false); //there is a pepsleft 0

		return false;

	}

}

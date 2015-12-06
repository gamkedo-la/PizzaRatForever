using UnityEngine;
using System.Collections;

public class CommuterWeavingController : CommuterController {

	public float weaveMagnitude = 1.0f;
	public float weaveMagnitudeVaryPerStep = 1.0f;
	public float weaveMagnitudeMax = 1.0f;

	//bool to weave back and forth
	private bool weaveLeft;

	// Use this for initialization
	void Start () {
		BaseStart ();
		InvokeRepeating("WeaveCommuter", shoeDropPauseTime-0.1f, shoeDropPauseTime);
		weaveLeft = true;
	}
		
	// commuter turns back and forth, increasing the magnitude each time
	void WeaveCommuter(){
		if (weaveLeft){
			transform.Rotate(Vector3.up, weaveMagnitude);
		}
		else{
			transform.Rotate(Vector3.up, -weaveMagnitude);
		}
		weaveMagnitude += weaveMagnitudeVaryPerStep; // increase weave magnitude (variation)
		if(weaveMagnitude > weaveMagnitudeMax) {
			weaveMagnitude = weaveMagnitudeMax;
		} else if(weaveMagnitude < -weaveMagnitudeMax) {
			weaveMagnitude = -weaveMagnitudeMax;
		}
		if(Random.Range(0,100)<30) {
			weaveLeft = !weaveLeft; // switch direction
		}
	}
}

using UnityEngine;
using System.Collections;

public class CommuterController : MonoBehaviour {

	public GameObject shoePrefabHeels;

	public GameObject shoePrefabL;
	public GameObject shoePrefabR;

	public GameObject shoePrefabKidSneakerL;
	public GameObject shoePrefabKidSneakerR;

	protected float shoeDropPauseTime = 2.0f;

	public enum ShoeKind {Boots,Heels,KidSneakers,ShoeTypeCount};

	private ShoeKind shoeType;

	protected bool leftFoot;

	// Use this for initialization
	void Start () {
		BaseStart ();
	}

	public void BaseStart () {
		shoeType = (ShoeKind)Random.Range(0,(int)(ShoeKind.ShoeTypeCount));

		//Camera camera = GetComponent<Camera>();

//		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 5.0f)); //left side of the screen, midway up, at camera's height
//		transform.position = p;
		Destroy(gameObject, 28.0f);

		if(shoeType == ShoeKind.Boots) {
			shoeDropPauseTime = 2.0f;
		} else if(shoeType == ShoeKind.KidSneakers) {
			shoeDropPauseTime = 1.5f;
		} else {
			shoeDropPauseTime = 1.8f;
		}

		InvokeRepeating("DropShoe", shoeDropPauseTime, shoeDropPauseTime);

		leftFoot = true;
	

	}
		
	// Update is called once per frame
	void Update () {

		walkCommuter();

		if (GameController.instance.inBoundsCheck(this.gameObject) == false)
		{
			
			Destroy(this.gameObject); //commuter has walked out of bounds
			
		}
	
	
	}
	


	void FixedUpdate () {




	}

	//the commuter walks forward, dropping shoes appropriately
	void walkCommuter(){
		float stepRange;
		
		if(shoeType == ShoeKind.Boots) {
			stepRange = 6;
		} else if(shoeType == ShoeKind.KidSneakers) {
			stepRange = 4.7f;
		} else {
			stepRange = 5.3f;
		}

		transform.position += transform.forward * stepRange * Time.deltaTime;
	}

	void DropShoe (){
		GameObject shoe;
		float stepWidth;

		if(shoeType == ShoeKind.Boots) {
			shoe = (leftFoot ? shoePrefabL : shoePrefabR);
			stepWidth = 2.9f;
		} else if(shoeType == ShoeKind.KidSneakers) {
			shoe = (leftFoot ? shoePrefabKidSneakerL : shoePrefabKidSneakerR);
			stepWidth = 1.45f;
		} else {
			shoe = shoePrefabHeels;
			stepWidth = 1.95f;
		}
		Instantiate(shoe, transform.position + transform.right * stepWidth * (leftFoot ? -1.0f : 1.0f), transform.rotation);
		leftFoot = !leftFoot; //switch feet
	}
}

using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {



	//create transform and currentpostion variables for movement and position
	//of the background sprites
	private Transform _transform;

	GameObject ninja;
	bool direction;
	float X;
	//variable to get size of the background sprites
	SpriteRenderer render;


	// Use this for initialization
	void Start () {
		ninja = GameObject.FindWithTag ("ninja");
		_transform = gameObject.GetComponent<Transform> ();
		// Get the render component for size of the gameobject
		render = gameObject.GetComponent<SpriteRenderer>();
		//get camera height length(the width of the camera is height*2)
		float camera = Camera.main.orthographicSize;
		direction = ninja.GetComponent<SpriteRenderer> ().flipX;
	}


	void Update () {



	}

	//when background became invisible
	void OnBecameInvisible()
	{
		
		//get the background x coordinate
		float width = render.bounds.size.x;
		//calculate current position
		var backgrndPosition = gameObject.transform.position;
		//calculate new position;
		if(!direction)
		X = backgrndPosition.x + width*2;
	
		if(direction)
			X = backgrndPosition.x - width*2;

		//move the background to new position when invisible
		gameObject.transform.position =new Vector2(X,9.2f);
	}
}

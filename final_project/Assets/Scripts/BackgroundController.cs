using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {



	//create transform and y postion variables for movement and position
	//of the background sprites
	private Transform _transform;
	float yPos;


//	variable to get size of the background sprites
	SpriteRenderer render;


	// Use this for initialization
	void Start () {

		_transform = gameObject.GetComponent<Transform> ();
		yPos = _transform.position.y;
//		// Get the render component for size of the gameobject
        render = gameObject.GetComponent<SpriteRenderer>();


	}
		

	//when background became invisible
	void OnBecameInvisible()
	{
		//get the background x coordinate
		float width = render.bounds.size.x;
		//calculate current position
		var backgrndPosition = gameObject.transform.position;
		//calculate new position;
		float X = backgrndPosition.x + width*2;

		//move the background to new position when invisible
		gameObject.transform.position =new Vector2(X,yPos);
	}
}

using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {

	//speed variable for crazy_bullet
	[SerializeField]
	private float speed;

	//a fireball gameobject to connect to the crazy_bullet
//	public GameObject fireball;

	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
	}

	// Update is called once per frame
	void Update () {
		_currentPosition = _transform.position;

		//move up
		if (Input.GetKey (KeyCode.UpArrow))
			_currentPosition += new Vector2 (0,speed);

		//move down
		if (Input.GetKey (KeyCode.DownArrow))
			_currentPosition -= new Vector2 (0,speed);

		//move left
		if (Input.GetKey (KeyCode.LeftArrow))
			_currentPosition -= new Vector2 (speed,0);

		//move right
		if (Input.GetKey (KeyCode.RightArrow))
			_currentPosition += new Vector2 (speed,0);


		//check bounds of screen
//		checkBounds ();
		_transform.position = _currentPosition;

//		if (Input.GetKeyDown("space")) {
//			// Create a new fireball at “transform.position”
//			// Which is the current position of the crazy_bullet
//			Instantiate(fireball, transform.position, Quaternion.identity);
//		}

	}
//	//check the bounds for Crazy_bullet
//	private void checkBounds(){
//		//get the height of the crazy_bullet
//		var renderer = gameObject.GetComponent<SpriteRenderer>();
//		float heightCrazyBullet = renderer.bounds.size.y;
//
//
//
//		//if position is bigger than camera view-half of the height of CB(otherwise the half of CB will be out of screen)
//		//for the top boundry
//		if (_currentPosition.y > Camera.main.orthographicSize-heightCrazyBullet/2.0f) {
//			_currentPosition.y = Camera.main.orthographicSize-heightCrazyBullet/2.0f;
//		}
//
//		//for the bottom boundry (grass height added -->1.4f)
//		if (_currentPosition.y < -Camera.main.orthographicSize+heightCrazyBullet/2.0f+1.4f) {
//			_currentPosition.y = -Camera.main.orthographicSize+heightCrazyBullet/2.0f+1.4f;
//		}
//
//		//for the right  boundry
//		if (_currentPosition.x > 12.9f) {
//			_currentPosition.x = 12.9f;
//		}
//
//		//for the left boundry
//		if (_currentPosition.x < -12.9f) {
//			_currentPosition.x = -12.9f;
//		}
//
//	}
}

using UnityEngine;
using System.Collections;

public class EnemyPlatformController : MonoBehaviour {
	public GameObject platform;



	Transform _transform,platTrans;
	float platX,platWidth,maxX,minX;
	//create rigid body component for enemies
	private Rigidbody2D rigidbodyEnemy;
	bool direction;
	SpriteRenderer platRen,_renderer;

	// Use this for initialization
	void Start () {
		// Get the rigidbody component
		if (rigidbodyEnemy == null) rigidbodyEnemy = GetComponent<Rigidbody2D>();
		platTrans = platform.GetComponent<Transform> ();
		platRen = platform.GetComponent<SpriteRenderer> ();
		_renderer=GetComponent<SpriteRenderer> ();
		_transform = gameObject.GetComponent<Transform> ();
		direction = true;
		platWidth = platRen.bounds.size.x;
		maxX = platTrans.position.x + platWidth / 2-_renderer.bounds.size.x/2;
		minX=platTrans.position.x -platWidth / 2+_renderer.bounds.size.x/2;


		float randomX= Random.Range (minX, maxX);
		_transform.position = new Vector2 (randomX,_transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (_transform.position.x < maxX && direction) {
			rigidbodyEnemy.velocity = new Vector2(GetComponent<EnemyController>().speed,0);

		} else {
			direction = false;
			_renderer.flipX = false;
		}


		if (_transform.position.x > minX && !direction) {
			rigidbodyEnemy.velocity = new Vector2(-GetComponent<EnemyController>().speed,0);

		} else {
			direction = true;
			_renderer.flipX = true;
		}

	}
}

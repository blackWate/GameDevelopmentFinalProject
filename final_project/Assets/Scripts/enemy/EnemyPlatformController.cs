//*Source            :EnemyPlatformController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Ngoc Hieu Trinh
//*Date last Modified:Dec 15, 2016
//*Description       :Place the enemy on the selected platform randomly
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/enemy


using UnityEngine;
using System.Collections;

public class EnemyPlatformController : MonoBehaviour {

	//select platform for enemy
	public GameObject platform;
	//get platform location
	Transform _transform,platTrans;
	float platX,platWidth,maxX,minX;
	//create rigid body component for enemies
	private Rigidbody2D rigidbodyEnemy;

	bool direction;
	//get platform and enemy size values
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
		//width of the platform
		platWidth = platRen.bounds.size.x;
		//min and max x values of the platform
		maxX = platTrans.position.x + platWidth / 2-_renderer.bounds.size.x/2;
		minX=platTrans.position.x -platWidth / 2+_renderer.bounds.size.x/2;

		//random number to place the enemy randomly on the platform
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

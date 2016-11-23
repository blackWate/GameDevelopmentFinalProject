using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject platform;

	public float speed;

	Transform _transform,platTrans;
	float platX,platWidth,maxX,minX;

	bool direction;
	SpriteRenderer platRen,_renderer;

	Animator ani;

	//create rigid body component for enemies
	private Rigidbody2D rigidbodyEnemy;

	//audioclip which plays when objects collieded
	public AudioClip hitsound;

	//source for audioclip
	AudioSource audioEnemy;

	//Gameobjects for "live" objects on the scene
	private GameObject[] lives;

	//points for connected enemies,obstacles or coin,
	[SerializeField]
	private int  point;

	//Gameobjects for "live" objects on the scene
	private GameObject[] scene;



	// Use this for initialization
	void Start () {

		// Get the rigidbody component
		if (rigidbodyEnemy == null) rigidbodyEnemy = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator> ();

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
	void Update () {

		if (_transform.position.x < maxX && direction) {
			rigidbodyEnemy.velocity = new Vector2(speed,0);

		} else {
			direction = false;
			_renderer.flipX = false;
		}


		if (_transform.position.x > minX && !direction) {
			rigidbodyEnemy.velocity = new Vector2(-speed,0);

		} else {
			direction = true;
			_renderer.flipX = true;
		}
	
	}

	void  OnTriggerEnter2D (Collider2D gObj)
	{
		// Get the name of the object that collided with the enemy
		//get the name of the fireball or crazy_bullet
		string name = gObj.gameObject.name;
		//get the name/s of enemies,obstacles or coin
		string enemyName = gameObject.name;

		if (name == "ninja_blade(Clone)") {

			// Destroy itself (the enemy) and the fireball but obstacles and coins
//			if (enemyName == "coin(Clone)" || enemyName == "spike(Clone)" || enemyName == "spike_monster_A(Clone)" || enemyName == "spike_monster_B(Clone)") {
//				//do nothing
//
//			} else //in case of collison with the birds
//			{

			//play hit sound which is connected to the bird
//				audioEnemy.PlayOneShot (hitsound);
			//delay object destroy for a while to complete of the playing sound
			//Destroy fireball
			Object.Destroy (gObj.gameObject, 0.15f);
			//destroy enemy(birds)
			Destroy (gameObject, 2.0f);
			gameObject.GetComponent<EnemyController> ().speed = 0;

			ani.SetTrigger ("destroy");
			//add points which is given to the bird
//				Player.Instance.Points+=point;

		}

		// If the enemy,obstcale or coin collided with the carzy_bullet
		if (name == "ninja") {

			// If the crazy_bullet collided with the obstacles
//			if (enemyName == "spike(Clone)"||enemyName == "spike_monster_A(Clone)"||enemyName == "spike_monster_B(Clone)") {
//				//play hit sound for spikes
//				audioEnemy.PlayOneShot (hitsound);
//				//go to method lifeCounter  to check the number of lives that carzy_bullet has
//				lifeCounter (obj.gameObject);
//
//
//			}
//			else
//			{
			//if carzy_bullet hits coin
			if (enemyName == "coin(Clone)") {
				//play related hit sound
				audioEnemy.PlayOneShot (hitsound);
				Object.Destroy (gameObject, 0.2f);
				//add the points given to the coins
//				Player.Instance.Points += point;
			} else {
				//if crazy_bullet collides with birds
				//play hit sound for birds
//				audioEnemy.PlayOneShot (hitsound);
				//delay object destroy for a while to complete of the playing sound
				Object.Destroy (gameObject, 0.15f);
				//go to method lifeCounter  to check the number of lives that carzy_bullet has
//				lifeCounter (obj.gameObject);


			}

//			}
//
//		}


		}

	}
}

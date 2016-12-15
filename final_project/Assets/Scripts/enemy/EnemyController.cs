using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {



	public float speed;

	//create rigid body component for enemies
	private Rigidbody2D rigidbodyEnemy;

	//audioclip which plays when objects collieded
	public AudioClip hitsound;

	//source for audioclip
	AudioSource audioEnemy;

	//Gameobjects for "live" objects on the scene
//	private GameObject[] lives;

	//points related to enemies,obstacles or coin,
	[SerializeField]
	private int  point;

	//Gameobjects for "live" objects on the scene
	private GameObject[] scene;

	//to control the lives
	HealthController health;
	//animation for collisions
	Animator ani;

	// Use this for initialization
	void Start () {

		// Get the rigidbody component
		 rigidbodyEnemy = GetComponent<Rigidbody2D>();
		ani = GetComponent<Animator> ();
		audioEnemy = GetComponent<AudioSource> ();
		health = GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate(){


		//give speed monsters
		rigidbodyEnemy.velocity = new Vector2(speed,0);


	}

	void  OnTriggerEnter2D (Collider2D gObj)
	{
		// Get the name of the object that collided with the enemy
		string name = gObj.gameObject.name;
		//get the name/s of enemies,obstacles or coin
		string enemyName = gameObject.name;

		if (name == "ninja_blade(Clone)") {

			// Destroy itself (the enemy) and the fireball but obstacles and coins
			if (gameObject.tag == "rewards") {
				//do nothing

			} else { //in case of collison with the enemies
				//play hit sound which is connected to the bird
				audioEnemy.PlayOneShot (hitsound);
				//delay object destroy for a while to complete of the playing sound
				//Destroy weapon
				Object.Destroy (gObj.gameObject, 0.15f);
				//destroy enemy(monsters)
				Destroy (gameObject, 2.0f);
				//play explosion animation

				ani.SetTrigger ("destroy");
				gameObject.GetComponent<EnemyController> ().speed = 0;
				//add points which is value of  the monster
				Player.Instance.Points += point;
			}

		}


		// If the enemy or rewards collided with ninja
		if (name == "ninja") {

				
//			 If ninja collided with the monsters
			if (gameObject.tag == "enemy") {
				//play hit sound for spikes
				audioEnemy.PlayOneShot (hitsound);
				//go to method lifeCounter  to check the number of lives 
				health.removeLife();


			} else {
//			if ninja hits the rewards
				if (gameObject.tag == "rewards") {
					//play related hit sound
					audioEnemy.PlayOneShot (hitsound);
					Object.Destroy (gameObject, 0.2f);
					//	add the points given to the related reward
					Player.Instance.Points += point;
				} else {
					//if ninja collides with monsters
					//play hit sound for enemies
				audioEnemy.PlayOneShot (hitsound);
					//delay object destroy for a while to complete of the playing sound
					Object.Destroy (gameObject, 0.15f);
					//remove the life
					health.removeLife();


				}


			}

		}




	}



}

using UnityEngine;
using System.Collections;

public class EnemyBombController : MonoBehaviour {

	//speed variable of the fireball
	[SerializeField]
	private float distance;



	[SerializeField]
	private GameObject weapon;



	[SerializeField]
	bool fired;

	private Rigidbody2D weaponRigidbody; 

	Transform _ninjaTrans,transform;




	// method called once when the fireball is created
	void  Start (){
		fired = false;
		_ninjaTrans=Camera.main.transform.parent;

//		_weaponTrans = weapon.GetComponent<Transform> ();
		 
		transform = GetComponent<Transform> ();


//Get the rigidbody component of the weapon
		// Get the rigidbody component
		weaponRigidbody =weapon.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){



		// Make the bullet move right


		if (Mathf.Abs (_ninjaTrans.transform.position.x - transform.position.x) <distance && !fired )
			dropBomb ();
		  


	}
	// method called when the fireball goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the bullet
		Destroy(gameObject);
	}
	void dropBomb(){
		// _targetTrans.position.x;

		//drops a bomp at the position of the enemy
//		print("bomb fired");
		Instantiate(weapon, transform.position, Quaternion.identity);
		fired = true;
	}



}

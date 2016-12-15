//*Source            :EnemyBombController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :it controls the dropping time and distance  of the bomb by calculating the distance
//* between monster bird and ninja
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/weapons

using UnityEngine;
using System.Collections;

public class EnemyBombController : MonoBehaviour {

	//distance between monster bird and ninja
	[SerializeField]
	private float distance;

	//the bomb game object
	[SerializeField]
	private GameObject weapon;

	//bomb fired or not
	[SerializeField]
	bool fired;

	private Rigidbody2D weaponRigidbody; 

	Transform _ninjaTrans,transform;

	GameObject ninja;


	// method called once when the fireball is created
	void  Start (){
		fired = false;
		//get location of the ninja
		ninja = GameObject.FindGameObjectWithTag ("ninja");
		_ninjaTrans=ninja.GetComponent<Transform>();
		//get location of the game object	 
		transform = GetComponent<Transform> ();


//Get the rigidbody component of the weapon
		// Get the rigidbody component
		weaponRigidbody =weapon.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){



		// Make the bomb move
		if(gameObject!=null||weapon!=null)
		if (Mathf.Abs (_ninjaTrans.transform.position.x - transform.position.x) <distance && !fired )
			dropBomb ();
		  


	}

	void dropBomb(){

		//drops a bomp at the position of the ninja
		Instantiate(weapon, transform.position, Quaternion.identity);
		fired = true;
	}



}

//*Source            :NinjaBladeController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :it controls the weapon of the ninja
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/weapons

using UnityEngine;
using System.Collections;

public class NinjaBladeController : MonoBehaviour {

	//speed variable of the ninjablade
	public float speed;



	private Rigidbody2D rigidbodyComponent;
	// method called once when the ninjablade is created
	void  Start (){

		// Get the rigidbody component
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();


	}
	void FixedUpdate(){

	

		rigidbodyComponent.velocity = new Vector2(speed,0);


	}
	// method called when the fireball goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the bullet
		Destroy(gameObject);
	}
}

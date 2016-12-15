//*Source            :BombController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :it controls the speed of the bomb and collision with the ninja
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/weapons


using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

	[SerializeField]
	private float xForce;
	[SerializeField]
	private float yForce;
	//explosion game object will be created after ninja got hit by bomb
	public GameObject Explosion;


	private Rigidbody2D rigidbodyComponent;
	// method called once when the fireball is created
	void  Start (){

		// Get the rigidbody component
		 rigidbodyComponent = GetComponent<Rigidbody2D>();


	}
	void FixedUpdate(){

		// Make the bomb move
		rigidbodyComponent.AddForce(new Vector2(xForce,yForce));

	}
	// method called when the bomb goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the bomb
		Destroy(gameObject);
	}
	//when the bomb collided
	void OnTriggerEnter2D(Collider2D obj){
		//if collided gameobject is ninja
		if (obj.gameObject.name == "ninja") {
			//create a explosion
			GameObject exp = (GameObject)Instantiate (Explosion);
			//at the position of the bomb
			exp.GetComponent<Transform> ().position = transform.position;
			//destroy the bomb
			Destroy(gameObject);
			//remove one of the lives of the ninja
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().removeLife();
		}
		

	}
}

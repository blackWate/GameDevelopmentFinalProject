using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

	[SerializeField]
	private float xForce;
	[SerializeField]
	private float yForce;

	public GameObject Explosion;


	private Rigidbody2D rigidbodyComponent;
	// method called once when the fireball is created
	void  Start (){

		// Get the rigidbody component
		 rigidbodyComponent = GetComponent<Rigidbody2D>();


	}
	void FixedUpdate(){

		// Make the bullet move right
		rigidbodyComponent.AddForce(new Vector2(xForce,yForce));

	}
	// method called when the fireball goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the bullet
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.name == "ninja") {
			GameObject exp = (GameObject)Instantiate (Explosion);
			exp.GetComponent<Transform> ().position = transform.position;
			print ("hit ninja");
			Destroy(gameObject);
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().removeLife();
		}
		

	}
}

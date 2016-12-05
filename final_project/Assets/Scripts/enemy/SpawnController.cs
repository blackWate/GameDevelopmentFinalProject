using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject[] enemy;

//	private Transform _transform;
	private Vector2 spawnPoint;
	private SpriteRenderer rend;

	// Variable to know how fast we should create new enemies or obstc
//	public float spawnTime ;
//	PlatformCheck platCheck;
//	bool check;
	void  Start (){
//		check = false;

//		_transform = GetComponent<Transform> ();
//		_rend = GetComponent<SpriteRenderer> ();
		// Call the 'addEnemy' function in 0 second
		// Then every 'spawnTime' seconds
//		InvokeRepeating("addEnemy", 0, spawnTime);
	}

//	// method to spawn an enemy
//	void  addEnemy (){
//		// Get the renderer component of the spawn object
//		if(rend==null)
//			rend =gameObject.GetComponent<SpriteRenderer>();
//
//		// Position of the left edge of the spawn object
//		// position of the center-half the width
//		float y1= transform.position.y - rend.bounds.size.y/2;
//
//		// Same for the right edge
//		float y2= transform.position.y + rend.bounds.size.y/2;
//
//		// Randomly pick a point within the spawn object
//		spawnPoint= new Vector2(transform.position.x,Random.Range(y1, y2));
//
//		//select random enemy from enemy  or obstacle list
//		int index = Random.Range (0, enemy.Length);
//
//		// Create an enemy at the 'spawnPoint' position
//		Instantiate(enemy[index], spawnPoint, Quaternion.identity);
//	}
	void Update(){
//		check = gObj.gameObject.GetComponent<PlatformCheck> ().IsEnemy;
	}
	void  OnTriggerEnter2D (Collider2D gObj)
	{
//		print(gObj.gameObject.name+"\n"+gObj.gameObject.tag);
//		Transform _platTrans;
//		SpriteRenderer _paltRend;


//		bool check =platCheck.IsEnemy;


//		print (platCheck);
		if (gObj.gameObject.tag == "platform") {
			bool platCheck=gObj.gameObject.GetComponent<PlatformCheck>().IsEnemy;
//			print (platCheck);
			if(!platCheck){


				float width = gObj.GetComponent<SpriteRenderer> ().bounds.size.x;
				float height = gObj.GetComponent<SpriteRenderer> ().bounds.size.y;
				float xPos = gObj.GetComponent<Transform> ().position.x;
				float yPos = gObj.GetComponent<Transform> ().position.y;

				//select random enemy from enemy  or obstacle list
				int index = Random.Range (0, enemy.Length);

				rend = enemy [index].GetComponent<SpriteRenderer> ();

				float maxX = xPos + width / 2 - rend.bounds.size.x / 2;
				float minX = xPos - width / 2 + rend.bounds.size.x / 2;
				float enYPos = yPos + height / 2 + rend.bounds.size.y / 2;


				float randomX = Random.Range (minX, maxX);
//			_transform.position = new Vector2 (randomX,enYPos);

				// Randomly pick a point within the spawn object
				spawnPoint = new Vector2 (randomX, enYPos);

			enemy [index].GetComponent<EnemyPlatformController> ().platform = gObj.gameObject;


				// Create an enemy at the 'spawnPoint' position
				Instantiate (enemy [index], spawnPoint, Quaternion.identity);
				
			}
			}



	}
}

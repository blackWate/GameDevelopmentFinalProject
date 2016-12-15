//*Source            :RandomEnemyController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Ngoc Hieu Trinh
//*Date last Modified:Dec 15, 2016
//*Description       :place enemies on the platform when spawn collides with a platform 
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/enemy
using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	//list of the enemies to create
	public GameObject[] enemy;

//	private Transform _transform;
	private Vector2 spawnPoint;
	private SpriteRenderer rend;

	void  OnTriggerEnter2D (Collider2D gObj)
	{



		// if collided object is a platform
		if (gObj.gameObject.tag == "platform") {
			//check if gameObject is enemy
			bool platCheck=gObj.gameObject.GetComponent<PlatformCheck>().IsEnemy;
			//if it is enemy
			if(!platCheck){

				//get size of the object and position values
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

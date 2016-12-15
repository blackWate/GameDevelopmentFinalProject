//*Source            :RandomEnemyController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Ngoc Hieu Trinh
//*Date last Modified:Dec 15, 2016
//*Description       :Spawn controller create random enemy from selected enemies list
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/enemy



using UnityEngine;
using System.Collections;

public class RandomEnemyController : MonoBehaviour {
	//enemy list to be created
	public GameObject[] enemy;
	//for location of enemy
	private Transform _transform;
	//for enemy creating point
	private Vector2 spawnPoint;
	//for the size of the enemy
	private SpriteRenderer rend;
	// Variable to know how fast we should create new enemies or obstc
	public float spawnTime ;

	void  Start (){
		// Call the 'addEnemy' function in 0 second
		// Then every 'spawnTime' seconds
		InvokeRepeating("addEnemy", 0, spawnTime);
	}

	// method to spawn an enemy
	void  addEnemy (){
		// Get the renderer component of the spawn object
		if(rend==null)
			rend =gameObject.GetComponent<SpriteRenderer>();

		// Position of the left edge of the spawn object
		// position of the center-half the width
		float y1= transform.position.y - rend.bounds.size.y/2;

		// Same for the right edge
		float y2= transform.position.y + rend.bounds.size.y/2;

		// Randomly pick a point within the spawn object
		spawnPoint= new Vector2(transform.position.x,Random.Range(y1, y2));

		//select random enemy from enemy  list
		int index = Random.Range (0, enemy.Length);

		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy[index], spawnPoint, Quaternion.identity);
	}
}

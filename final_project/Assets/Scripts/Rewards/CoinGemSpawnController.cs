//*Source            :CoinGemSpawnController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       : it randomly creates gems and coins from list, it is connected  a gameobject which is at the right
//* outside of the screen
//* all these gameobjects create the clones of the connected prefabs.
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/Rewards

using UnityEngine;
using System.Collections;

public class CoinGemSpawnController : MonoBehaviour {

	// array Variable to store the gems and coins
	public GameObject[] gems;
	public GameObject potion;
	//min lives number to create the potions 
	public int minLife;
	private Transform _transform;
	private Vector2 spawnPoint;
	private SpriteRenderer rend;
	// Variable to know how fast we should create new gems and coins
	public float spawnTime,distance ;
	float lastXPos;
	bool xLife;

	GameObject[] lives;
	void  Start (){
		// Call the 'addGem' function in 0 second
		// Then every 'spawnTime' seconds
//		InvokeRepeating("addGem", 0, spawnTime);
		xLife=false;
	
		lastXPos=transform.position.x;
		addGem ();

	}

	void Update(){
		xLife = false;
		//find game object with tag name "life"
		lives=GameObject.FindGameObjectsWithTag("life");

		if (lives.Length < minLife&&GameObject.FindGameObjectsWithTag("potion").Length==0) {
			xLife = true;
		} 
			
		float diff=transform.position.x-lastXPos;
		if (diff > distance)
			addGem ();

	}

	// method to spawn an gems and coins
	void  addGem (){
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

	
			
		//select random gems and coins from the list
		int index = Random.Range (0,gems.Length);
		GameObject instObj = gems [index];
		if (xLife)
			instObj = potion;

		// Create an reward at the 'spawnPoint' position
		Instantiate(instObj, spawnPoint, Quaternion.identity);
		lastXPos = transform.position.x;

	}
}

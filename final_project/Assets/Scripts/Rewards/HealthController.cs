//*Source            : HealthController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       : it creates hearts(lives) at beginning of the game in desired numbers, it controls the number of the hearts, 
//*removes or adds lives 
//* all these gameobjects create the clones of the connected prefabs.
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/Rewards


using UnityEngine;
using System.Collections;

public class HealthController: MonoBehaviour {
	//the game object to create on the screen
	public GameObject heart;
	//the distance between hearts(lives) on the screen
	public float distance;
	//the number of the hearts(lives) on the screen
	public int howMany;
	Transform _transform;
	SpriteRenderer _renderer;
	GameObject []lives;
	// Use this for initialization
	void Start () {

		//place the hearts on the screen according the entered values
		_transform = GetComponent<Transform> ();
		_renderer = GetComponent<SpriteRenderer> ();
		float _heartWidth = _renderer.bounds.size.x;
		float _heartXPos = _transform.position.x;
		float _heartYPos = _transform.position.y;
		float xPos = _heartXPos;
		for (int i = 1; i < howMany; i++) {
			xPos = xPos + _heartWidth + distance;

			createLife (xPos, _heartYPos, i);


		}
	}
	
	// Update is called once per frame
	void Update () {
		//get list of hearts on the screen
		lives=GameObject.FindGameObjectsWithTag("life");
	}
	//add a life
	public void addLife(){
		
		float xPosLast = lives [lives.Length-1].GetComponent<Transform> ().position.x;
		print ("x last pos"+xPosLast);
		float yPosLast=lives[lives.Length-1].GetComponent<Transform>().position.y;
		print ("y last pos"+yPosLast);
		float xPos = xPosLast+_renderer.bounds.size.x+distance ;
		print ("x pos"+xPos);
		createLife (xPos, yPosLast, lives.Length);

	}
	//remove a life
	public void removeLife(){
		
		Destroy (lives [lives.Length - 1]);
		Update ();
		print ("Rest lives:"+lives.Length);
		//if the number of the lives is 1
		if (lives.Length == 1) {
			print ("life is zero");
			//destroy parent relationship between camera and ninja
			Camera.main.transform.parent = null;
			//destroy the ninja
			Destroy (GameObject.FindGameObjectWithTag ("ninja"));
			//reset points to zero
			Player.Instance.Points = 0;
			//goto Game_end scene
			print (GameObject.FindGameObjectWithTag("scene").name);
			GameObject.FindGameObjectWithTag("scene").GetComponent<SceneController>().loadScene("Game_End");
		} 
			


	}

	//create a life method
	void createLife(float x,float y,int num){
		GameObject myHeart=Instantiate (heart, new Vector2 (x, y), Quaternion.identity)as GameObject;
		myHeart.name = "heart" + num;
		myHeart.tag="life";
		myHeart.transform.parent = transform.parent;
	}

}

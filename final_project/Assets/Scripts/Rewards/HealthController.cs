using UnityEngine;
using System.Collections;

public class HealthController: MonoBehaviour {
	public GameObject heart;
	public float distance;
	public int howMany;
	Transform _transform;
	SpriteRenderer _renderer;
	GameObject []lives;
	// Use this for initialization
	void Start () {
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
		lives=GameObject.FindGameObjectsWithTag("life");
	}
	public void addLife(){
		
		float xPosLast = lives [lives.Length-1].GetComponent<Transform> ().position.x;
		print ("x last pos"+xPosLast);
		float yPosLast=lives[lives.Length-1].GetComponent<Transform>().position.y;
		print ("y last pos"+yPosLast);
		float xPos = xPosLast+_renderer.bounds.size.x+distance ;
		print ("x pos"+xPos);
		createLife (xPos, yPosLast, lives.Length);

	}

	public void removeLife(){
		
		Destroy (lives [lives.Length - 1]);
		Update ();
		print ("Rest lives:"+lives.Length);

		if (lives.Length == 1) {
			print ("life is zero");
			Camera.main.transform.parent = null;
			Destroy (GameObject.FindGameObjectWithTag ("ninja"));
			//reset points to zero
			Player.Instance.Points = 0;
			//goto Game_end scene
			print (GameObject.FindGameObjectWithTag("scene").name);
			GameObject.FindGameObjectWithTag("scene").GetComponent<SceneController>().loadScene("Game_End");
		} 


			//goto Game_end scene
			//			scene=GameObject.FindGameObjectsWithTag("scene");
			//			scene [0].GetComponent<SceneController> ().loadScene("Game_End");




	}


	void createLife(float x,float y,int num){
		GameObject myHeart=Instantiate (heart, new Vector2 (x, y), Quaternion.identity)as GameObject;
		myHeart.name = "heart" + num;
		myHeart.tag="life";
		myHeart.transform.parent = transform.parent;
	}

}

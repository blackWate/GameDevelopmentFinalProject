//*Source            :BackGrndController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :it controls the background, seamlessly moves background in opposite direction of the ninja
//*when ninja moves 
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/background


using UnityEngine;
using System.Collections;

public class BackGrndController : MonoBehaviour {


	public GameObject  ninja;
	// Use this for initialization
	void Start () {
		;
	}

	// Update is called once per frame
	void Update () {
		
		//Camera.main.GetComponent<Transform>().position
		Vector2 _position = new Vector2 (ninja.GetComponent<Transform> ().position.x, 13.1f);

		GetComponent<Transform> ().position = _position;
		//create new offset value for background according the NinjaController
		//move variable
		Vector2 _offset = new Vector2 (ninja.GetComponent<NinjaController> ().move, 0);
		//set the offset value of the background  to the calculated value
		GetComponent<MeshRenderer> ().material.mainTextureOffset = _offset;
	
	}
}

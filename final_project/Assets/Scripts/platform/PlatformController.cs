//*Source            :PlatformController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :make the platform moves back and forth with desired speed between other two selected platforms 
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/platform

using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	//speed of the platform
	public float speed;
	//two platforms; front and back platforms, 
	public GameObject frontPlatform,backPlatform;
	//position of the platforms
	Transform _transform,frntTrans,bckTrans;
	//position x values of the platforms(Front and back)
	float frntPlatX,bckPlatX;
	//postion of the platform
	Vector2 _currentPos;
	//moving directioon of the platform
	public bool direction;
	SpriteRenderer frntRen,bckRen,_renderer;


	// Use this for initialization
	void Start () {
		//for size of the front and backplatforms
		frntRen = frontPlatform.GetComponent<SpriteRenderer> ();
		bckRen = backPlatform.GetComponent<SpriteRenderer> ();
		_renderer=GetComponent<SpriteRenderer> ();

		frntTrans = frontPlatform.GetComponent<Transform> ();
		bckTrans = backPlatform.GetComponent<Transform> ();
		_transform = GetComponent<Transform> ();

		//calculate the  x distance of the tip point of front platform and back platform
		//for moving distance of platform in the middle
		frntPlatX = frntTrans.position.x+frntRen.bounds.size.x/2+_renderer.bounds.size.x/2;
		bckPlatX = bckTrans.position.x-bckRen.bounds.size.x/2-_renderer.bounds.size.x/2;
		//place the middle platform someher between other two platforms
		float randomX= Random.Range (frntPlatX, bckPlatX);
		_currentPos = new Vector2 (randomX,_transform.position.y);
//		direction = false;

	}
	
	// Update is called once per frame
	void Update () {
		//move the platform between the other platforms to the left until it gets the 
		//min value
			if (_currentPos.x < bckPlatX && direction) {
				_currentPos += new Vector2 (speed, 0);
			} else {
				direction = false;
			}

		//move the platform between the other platforms to the right until it gets the 
		//max value
			if (_currentPos.x > frntPlatX && !direction) {
				_currentPos -= new Vector2 (speed, 0);
			} else {
				direction = true;
			}
	
		_transform.position = _currentPos;
	
	}

		

}

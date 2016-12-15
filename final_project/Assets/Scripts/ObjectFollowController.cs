//*Source            :ObjectFollowController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :it connects the game object to the other object that to be followed it
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts

using UnityEngine;
using System.Collections;

public class ObjectFollowController : MonoBehaviour {
	//game object to be followed
	public GameObject objToFollow;

	Vector3 _distance;
	void Start () {
		//calculate the distance between objects
		_distance = transform.position - objToFollow.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//change the position in order to follow the other in same distance
		transform.position = objToFollow.transform.position + _distance;
	
	}



}

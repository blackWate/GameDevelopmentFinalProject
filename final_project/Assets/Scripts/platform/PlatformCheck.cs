//*Source            :PlatformCheck.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :controls the platform and it connects enemy to the platform 
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/platform

using UnityEngine;
using System.Collections;



public class PlatformCheck : MonoBehaviour {


//	public GameObject platform;
	public bool IsEnemy;
	// Update is called once per frame
	void Start () {
//		IsEnemy = false;
	}
	void FixedUpdate(){
		
		IsEnemy = false;
	}
	//when stay collieded
	void  OnTriggerStay2D (Collider2D obj){
		//if object tag is enemy
		if (obj.tag == "enemy") {
			IsEnemy = true;
			//associate the platform to the platform variable of the collided objcet's EnemyPlatformController
			obj.gameObject.GetComponent<EnemyPlatformController> ().platform = gameObject;
		} 

	}


}

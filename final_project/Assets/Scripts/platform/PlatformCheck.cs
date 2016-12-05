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
	void  OnTriggerStay2D (Collider2D obj){
		
		if (obj.tag == "enemy" ) {
			IsEnemy = true;
			obj.gameObject.GetComponent<EnemyPlatformController> ().platform = gameObject;
		} 

	}


}

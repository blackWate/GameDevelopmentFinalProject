using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public float speed;
	public GameObject frontPlatform,backPlatform;
	Transform _transform,frntTrans,bckTrans;
	float frntPlatX,bckPlatX;
	Vector2 _currentPos;
	public bool direction;
	SpriteRenderer frntRen,bckRen,_renderer;


	// Use this for initialization
	void Start () {
		frntRen = frontPlatform.GetComponent<SpriteRenderer> ();
		bckRen = backPlatform.GetComponent<SpriteRenderer> ();
		_renderer=GetComponent<SpriteRenderer> ();

		frntTrans = frontPlatform.GetComponent<Transform> ();
		bckTrans = backPlatform.GetComponent<Transform> ();
		_transform = GetComponent<Transform> ();


		frntPlatX = frntTrans.position.x+frntRen.bounds.size.x/2+_renderer.bounds.size.x/2;
		bckPlatX = bckTrans.position.x-bckRen.bounds.size.x/2-_renderer.bounds.size.x/2;

		float randomX= Random.Range (frntPlatX, bckPlatX);
		_currentPos = new Vector2 (randomX,_transform.position.y);
//		direction = false;

	}
	
	// Update is called once per frame
	void Update () {

			if (_currentPos.x < bckPlatX && direction) {
				_currentPos += new Vector2 (speed, 0);
			} else {
				direction = false;
			}


			if (_currentPos.x > frntPlatX && !direction) {
				_currentPos -= new Vector2 (speed, 0);
			} else {
				direction = true;
			}
	
		_transform.position = _currentPos;
	
	}

		

}

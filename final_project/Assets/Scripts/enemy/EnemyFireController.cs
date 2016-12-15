//*Source            :EnemyFireController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Ngoc Hieu Trinh
//*Date last Modified:Dec 15, 2016
//*Description       :EnemyFireController gives an ability to the enemies to fire bullets randomly.
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/enemy
using UnityEngine;
using System.Collections;

public class EnemyFireController : MonoBehaviour {

	//a weapon gameobject to connect to the enemy
	[SerializeField]
	private GameObject bullet,ninja;
	//min time in secs between bullets
	[SerializeField]
	public float fireRateMin;
	//max time in secs between bullets
	[SerializeField]
	public float fireRateMax;
	//base fire time in secs
	[SerializeField]
	private float baseFireTime;

	private Transform _transform,ninjaTrans;
	private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		ninjaTrans = ninja.GetComponent<Transform> ();
		_renderer = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per tick
	void Update () {

		//creates random time and add to the base fire time if actual time is greater than  the base fire time
		if (Time.time > baseFireTime) {
			baseFireTime = Time.time + Random.Range (fireRateMin, fireRateMax);
			if (ninjaTrans.position.x < _transform.position.x && !_renderer.flipX) {
				bullet.GetComponent<NinjaBladeController> ().speed = -Mathf.Abs (bullet.GetComponent<NinjaBladeController> ().speed);
				OnBecameVisible();
			} else if (ninjaTrans.position.x > _transform.position.x && _renderer.flipX) {
				bullet.GetComponent<NinjaBladeController> ().speed = Mathf.Abs (bullet.GetComponent<NinjaBladeController> ().speed);
				OnBecameVisible();
			}


		}

	}
	void OnBecameVisible(){

		//creates a bullet at the position of the enemy
		Instantiate(bullet, transform.position, Quaternion.identity);

	}

}

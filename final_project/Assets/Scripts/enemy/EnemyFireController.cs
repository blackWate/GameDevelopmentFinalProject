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
				fireBullet ();
			} else if (ninjaTrans.position.x > _transform.position.x && _renderer.flipX) {
				bullet.GetComponent<NinjaBladeController> ().speed = Mathf.Abs (bullet.GetComponent<NinjaBladeController> ().speed);
				fireBullet ();
			}


		}

	}
	void fireBullet(){

		//creates a bullet at the position of the enemy
		Instantiate(bullet, transform.position, Quaternion.identity);

	}

}

using UnityEngine;
using System.Collections;

public class ObjectFollowController : MonoBehaviour {

	public GameObject objToFollow;
	// Use this for initialization


	Vector3 _distance;
	void Start () {
		_distance = transform.position - objToFollow.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = objToFollow.transform.position + _distance;
	
	}



}

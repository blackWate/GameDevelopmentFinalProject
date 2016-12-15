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
		Vector2 _offset = new Vector2 (ninja.GetComponent<NinjaController> ().move, 0);
		GetComponent<MeshRenderer> ().material.mainTextureOffset = _offset;
	
	}
}

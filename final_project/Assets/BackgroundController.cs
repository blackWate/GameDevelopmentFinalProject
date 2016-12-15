using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public GameObject ninja;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (-ninja.GetComponent<Transform>().position.x,0);
		GetComponent<MeshRenderer> ().material.mainTextureOffset = offset;
//		renderer.material.mainTextureOffset = offset;
	}
}

using UnityEngine;
using System.Collections;

public class HealthController: MonoBehaviour {
	public GameObject heart,parent;
	public float distance;
	public int howMany;
	Transform _transform,_transParent;
	SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform> ();
		_renderer = GetComponent<SpriteRenderer> ();
		_transParent = parent.GetComponent<Transform> ();
		_transParent.parent = _transform;
//		gameObject.tag = "";
//		GameObject[] objs ;
//		objs = GameObject.FindGameObjectsWithTag("health");
//		foreach (GameObject health in objs) {
//			Destroy (health);
//		}
		float _heartWidth = _renderer.bounds.size.x;
		float _heartXPos = _transform.position.x;
		float _heartYPos = _transform.position.y;
		float xPos = _heartXPos;
		for (int i = 1; i < howMany; i++) {
			xPos = xPos + _heartWidth + distance;
			GameObject myHeart=Instantiate (heart, new Vector2 (xPos, _heartYPos), Quaternion.identity)as GameObject;
			myHeart.name = "heart" + i;
			myHeart.transform.parent = _transParent;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

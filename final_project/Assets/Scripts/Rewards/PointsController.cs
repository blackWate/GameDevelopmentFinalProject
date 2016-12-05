using UnityEngine;
using System.Collections;

public class PointsController : MonoBehaviour {

	//connects to the text objects
	[SerializeField]
	UnityEngine.UI.Text points = null;


	// Use this for initialization
	void Start () {
		//create a player instance with pointscontroller which is a member of player class for this
		Player.Instance.poc = this;
	}


	//method to update the point values on the scene
	public void UpdatePoints(){

		points.text =  Player.Instance.Points.ToString();

	}

}

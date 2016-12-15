//*Source            :PointsController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :PointsController is connected to a empty game object and this object is //*gives it is
//* value to the text gameobject  to keep the point score update
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/Rewards


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

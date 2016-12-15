//*Source            :SceneController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :Scene Manager, it manages the scene navigation and , app quit
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	//load the  desired scene
	public void loadScene(string scene){

		SceneManager.LoadScene (scene);
	}
	//quit application does not work  at in development mode, but works after "build and run"
	public void quit(){
		Application.Quit ();
	}
}

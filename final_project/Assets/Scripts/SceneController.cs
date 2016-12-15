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

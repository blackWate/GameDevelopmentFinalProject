using UnityEngine;
using System.Collections;

public class Player  {

	//initilize the points to zero
	private int _points = 0;

	//pointscontroller variable which is connected to the text object
	public PointsController poc;

	//intilize player object as null(it is static no need to create class)
	private static Player _instance = null;

	//player static instance get method
	public static Player Instance{

		get{ //if not exsit create one
			if (_instance == null) {

				_instance = new Player ();
			}
			return _instance;
		}
	}

	private Player(){
	}
	//getter and setter methods for points variable of the player class
	public int Points{
		get{
			return _points;
		}

		set{
			_points = value;

			//when new value set for player instance it will update pointcontroller
			//points which is connected to the text object of the scene
			poc.UpdatePoints();
		}
	}

}

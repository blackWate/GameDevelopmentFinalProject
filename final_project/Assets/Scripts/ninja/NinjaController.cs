//*Source            :NinjaController.cs
//*Author            :Umit M.Karasu - 100938361  Ngoc Hieu Trinh - 100986583
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Dec 15, 2016
//*Description       :Controls ninja, moves up, down, left and right, checks whether is landed or not, check bounds of the game for ninja
//* controls ninja's collisions with other game objects
//*Revision History  :https://github.com/blackWate/GameDevelopmentFinalProject/tree/master/final_project/Assets/Scripts/ninja
using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {



	//force values for jumping and moving left and right
	public float jumpForce,moveForce;

	//a weapon gameobject to connect to the ninja
	public GameObject weapon;

	//Ground Check Variables
	public Transform checkLanded;
	public float checkRadius;
	public float fallDistance,xPos,yPos;
	public LayerMask whatIsLand;
	bool isLanded;
	//get the last stepped platform before fall
	private GameObject lastSteppedOn;
	float ninjaLPos;
	Transform _lastSteppedOnTrans;
	Animator anim;
	//move value for background
	public float move;

	private SpriteRenderer ren,_rendLastSteppedOn;

	private float speedWeapon;
	private Rigidbody2D ninjaRigidbody;
	bool direction;

	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();


		ninjaRigidbody=GetComponent<Rigidbody2D>();
		anim.SetTrigger ("idle");
	   move = 0;

	}

	// Update is called once per frame
	void FixedUpdate(){
		//left side bound of the game screen
		if (GetComponent<Transform> ().position.x < -13.2f) {
			Vector2 xBound = new Vector2 (-13.2f,0);
			GetComponent<Transform> ().position = xBound;
		}


		//right side level competed axis point
		if (GetComponent<Transform> ().position.x >782.66f) {
			Vector2 xBound = new Vector2 (-13.2f,0);
			GetComponent<Transform> ().position = xBound;
			//when ninja reached lavel complleted x value load You Won scene
			GameObject.FindGameObjectWithTag("scene").GetComponent<SceneController>().loadScene("You_Won");
		}
		//chech whether ninja is landed or not
		isLanded = Physics2D.OverlapCircle (checkLanded.position,checkRadius,whatIsLand);
		anim.ResetTrigger ("throw");

		//select animation layer according to the player situation(in the air or grounded)
		if (!isLanded)
			anim.SetLayerWeight (1, 1);
		else {
			anim.SetLayerWeight (1, 0);
			anim.SetBool ("landing", false);
		}
		//if ninja is not landed but vertical speed is negative then it is landing
		if (ninjaRigidbody.velocity.y < 0&&!isLanded) {
			anim.SetBool ("landing", true);

		}
	
		ren = GetComponent<SpriteRenderer> ();


		//to flip the ninja according the direction that it moves
		direction = ren.flipX;

		//if ninla fell put it back on the last platform he stepped on ,and take one of it's lives
		if (transform.position.y < fallDistance) {	
			transform.position = new Vector2 (xPos, yPos); 
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().removeLife ();
		}

		//move right
		if (Input.GetKey (KeyCode.D)) {
			moveBackground("r");
			anim.SetTrigger ("run");
			anim.ResetTrigger ("idle");
			ren.flipX = false;
			ninjaRigidbody.AddForce(new Vector2 (moveForce, 0));
		}

		//stop when key released
		if (Input.GetKeyUp (KeyCode.D)) {
				anim.ResetTrigger ("run");
				anim.SetTrigger ("idle");
			ninjaRigidbody.velocity =Vector2.zero;
		}

		//move left
		if (Input.GetKey (KeyCode.A)) {
			moveBackground ("l");
			anim.SetTrigger ("run");
			anim.ResetTrigger ("idle");
			ren.flipX = true;
			ninjaRigidbody.AddForce(new Vector2 (-moveForce, 0));
		}
			
		//stop when key released
		if (Input.GetKeyUp (KeyCode.A)) {
			anim.ResetTrigger ("run");
			anim.SetTrigger ("idle");
			ninjaRigidbody.velocity =Vector2.zero;

		}
		//jump up 
		if (Input.GetKeyDown (KeyCode.W)) {
			if (isLanded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("run");
				anim.SetTrigger ("jump");
			ninjaRigidbody.AddForce(new Vector2(0,jumpForce));
			}
		}

		//move down
		if (Input.GetKeyDown (KeyCode.S)) {
			if (!isLanded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("run");
				anim.SetBool ("landing", true);
				ninjaRigidbody.AddForce(new Vector2(0,-jumpForce));
			}
		}
		//shoot the enemies
		if (Input.GetKeyDown ("space")) {
			anim.SetTrigger ("throw");
			// Create a new weapon at “transform.position”
			// Which is the current position of the ninja
			if (direction)
				weapon.GetComponent<NinjaBladeController> ().speed = -Mathf.Abs (weapon.GetComponent<NinjaBladeController> ().speed);
			else//if (!direction)
				weapon.GetComponent<NinjaBladeController> ().speed = Mathf.Abs (weapon.GetComponent<NinjaBladeController> ().speed);
			Instantiate (weapon, transform.position, Quaternion.identity);
		}
		if (Input.GetKeyUp ("space")) {
			anim.ResetTrigger ("throw");
			anim.SetTrigger ("idle");
		}


				
					
					
		ninjaLPos = GetComponent<Transform> ().position.x;	

	}

	//when ninja stay collided 
	void  OnTriggerStay2D ( Collider2D other  ){
		//if the collided object is a platform
		if(other.gameObject.tag == "platform"){
			//make the platform parent of the ninja to keep ninja on the platform
			transform.parent = other.transform;

		}
		//make the platform the last platform that ninja collided to put back the ninja when it falls afterwards
		lastSteppedOn = other.gameObject;
		_lastSteppedOnTrans = lastSteppedOn.GetComponent<Transform> ();
		_rendLastSteppedOn=lastSteppedOn.GetComponent<SpriteRenderer> ();
		xPos=_lastSteppedOnTrans.position.x;
		yPos=_lastSteppedOnTrans.position.y + _rendLastSteppedOn.bounds.size.y/2+GetComponent<SpriteRenderer>().bounds.size.y/2;
//		print ("Last stepped Game Object Name: " + lastSteppedOn.name);
//		+_rendLastSteppedOn.bounds.size.x/2+GetComponent<SpriteRenderer>().bounds.size.x/2 
	}

	void  OnTriggerExit2D ( Collider2D other  ){
		//when ninja leaves the platform, remove the parent relationship
		if(other.gameObject.tag == "platform"){
			transform.parent = null;

		}
	}    
	//when ninja collided 
	void  OnTriggerEnter2D ( Collider2D other  ){
		//if the object is  life potion
		if(other.gameObject.tag == "potion"){
// destroy the potion bottle
			Destroy (other.gameObject);
			// and increase lives of the ninja by 1 by calling healthController's addlife method
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().addLife ();

		}
		//if it is a enemy bullet 
		if(other.gameObject.tag == "enemyBullet"){
			//destroy the buller
			Destroy (other.gameObject);
			//and remove one of lives of Ninja
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().removeLife ();

		}
	}
	//method to move the background of game 
	void moveBackground(string direction)
	{
		
		if (GetComponent<Transform> ().position.x != ninjaLPos) {

			if (direction == "l") {
				if (move < -1)
					move = 0;

				move -= 0.002f;
			} else {
				if (move == 1)
					move = 0;

				move += 0.002f;

			}
		}
	}
} 

using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {



	public float speed;

	public float jumpForce;

	//a weapon gameobject to connect to the ninja
	public GameObject weapon;

	//

	//Ground Check Variables
	public Transform checkLanded;
	public float checkRadius;
	public float fallDistance,xPos,yPos;
	public LayerMask whatIsLand;
	bool isLanded;
	private GameObject lastSteppedOn;

	Transform _lastSteppedOnTrans;
	Animator anim;



	private SpriteRenderer ren,_rendLastSteppedOn;

	private float speedWeapon;
	private Rigidbody2D ninjaRigidbody;
	bool direction;

	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();


		ninjaRigidbody=GetComponent<Rigidbody2D>();
		anim.SetTrigger ("idle");

	}

	// Update is called once per frame
	void FixedUpdate(){




		isLanded = Physics2D.OverlapCircle (checkLanded.position,checkRadius,whatIsLand);
		anim.ResetTrigger ("throw");

		//select animation layer according to the player situation(in the air or grounded)
		if (!isLanded)
			anim.SetLayerWeight (1, 1);
		else {
			anim.SetLayerWeight (1, 0);
			anim.SetBool ("landing", false);
		}

		if (ninjaRigidbody.velocity.y < 0&&!isLanded) {
			anim.SetBool ("landing", true);

		}
	
		ren = GetComponent<SpriteRenderer> ();


		
		direction = ren.flipX;


		if (transform.position.y < fallDistance) {	
			transform.position = new Vector2 (xPos, yPos); 
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().removeLife ();
		}


		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			

				
			anim.SetTrigger ("run");
			anim.ResetTrigger ("idle");
			ren.flipX = false;
			ninjaRigidbody.velocity = new Vector2 (speed, 0);
		}


		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			
				anim.ResetTrigger ("run");
				anim.SetTrigger ("idle");
				ninjaRigidbody.velocity = new Vector2 (0, 0);



		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			
	
				anim.SetTrigger ("run");
				anim.ResetTrigger ("idle");
				ren.flipX = true;
				ninjaRigidbody.velocity = new Vector2 (-speed, 0);
			
				
			
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			anim.ResetTrigger ("run");
			anim.SetTrigger ("idle");
			ninjaRigidbody.velocity = new Vector2 (0, 0);

		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (isLanded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("run");
				anim.SetTrigger ("jump");
			ninjaRigidbody.AddForce(new Vector2(0,jumpForce));
				isLanded= false;
			}
		}


		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (!isLanded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("run");
				anim.SetBool ("landing", true);
				ninjaRigidbody.AddForce(new Vector2(0,-jumpForce));
				isLanded= false;
			}
		}

		if (Input.GetKeyDown ("space")) {
			anim.SetTrigger ("throw");
			// Create a new weapon at “transform.position”
			// Which is the current position of the ninja
			if (direction)
				weapon.GetComponent<NinjaBladeController> ().speed = -Mathf.Abs (weapon.GetComponent<NinjaBladeController> ().speed);
			if (!direction)
				weapon.GetComponent<NinjaBladeController> ().speed = Mathf.Abs (weapon.GetComponent<NinjaBladeController> ().speed);
			Instantiate (weapon, transform.position, Quaternion.identity);
		}
		if (Input.GetKeyUp ("space")) {
			anim.ResetTrigger ("throw");
			anim.SetTrigger ("idle");
		}


				
					
					
				

	}


	void  OnTriggerStay2D ( Collider2D other  ){
		if(other.gameObject.tag == "platform"){
			transform.parent = other.transform;

		}
		lastSteppedOn = other.gameObject;
		_lastSteppedOnTrans = lastSteppedOn.GetComponent<Transform> ();
		_rendLastSteppedOn=lastSteppedOn.GetComponent<SpriteRenderer> ();
		xPos=_lastSteppedOnTrans.position.x;
		yPos=_lastSteppedOnTrans.position.y + _rendLastSteppedOn.bounds.size.y/2+GetComponent<SpriteRenderer>().bounds.size.y/2;
//		print ("Last stepped Game Object Name: " + lastSteppedOn.name);
//		+_rendLastSteppedOn.bounds.size.x/2+GetComponent<SpriteRenderer>().bounds.size.x/2 
	}

	void  OnTriggerExit2D ( Collider2D other  ){
		if(other.gameObject.tag == "platform"){
			transform.parent = null;
//			lastSteppedOn = other.gameObject;
//			print ("Last stepped Game Object Name: " + lastSteppedOn.name);
		}
	}    
	void  OnTriggerEnter2D ( Collider2D other  ){
		if(other.gameObject.tag == "potion"){
//			print ("hit potion");
			Destroy (other.gameObject);
			GameObject.FindGameObjectsWithTag ("life") [0].GetComponent<HealthController> ().addLife ();

		}
	}
} 

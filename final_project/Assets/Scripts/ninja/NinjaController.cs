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
	public LayerMask whatIsLand;
	bool isLanded;

	Animator anim;



	private SpriteRenderer ren;

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
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			print ("run");

				
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
			print ("run");
	
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
	}

	void  OnTriggerExit2D ( Collider2D other  ){
		if(other.gameObject.tag == "platform"){
			transform.parent = null;

		}
	}    


} 

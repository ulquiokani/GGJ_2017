using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	BoxCollider2D playerCollider;

	float maxSpeed;
	float currentSpeed;
	float force;
	float tileMomentum;

	int jumpDelay;


	// Use this for initialization
	void Start () {
		player = this.gameObject;
		rb = player.GetComponent<Rigidbody2D> ();
		playerCollider = player.GetComponent<BoxCollider2D> ();
		maxSpeed = 5f;
		force = 250f;
		jumpDelay = 0;
		tileMomentum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (jumpDelay > 0)
			jumpDelay--;

	}

	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if (playerCollider.IsTouchingLayers (1 << 8) && jumpDelay == 0f) {
				rb.AddForce (Vector2.up * (force + tileMomentum));
				jumpDelay = 3;
			} 
		}
		float horizontalInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (horizontalInput * maxSpeed, rb.velocity.y);
	}

	void OnCollisionStay(Collision c){
		if (c.gameObject.tag == "tile") {
			//tileMomentum = c.gameObject.GetComponent<MapObject> ().GetMovementVector ().magnitude;
		}
	}
}

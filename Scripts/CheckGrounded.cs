using UnityEngine;
using System.Collections;

public class CheckGrounded : MonoBehaviour {

	private player play;

	// Use this for initialization
	void Start () {
		play = GetComponentInParent<player>();
	}
	
	void OnCollisionStay2D(Collision2D col){

		if (col.gameObject.tag == "Ground") {
			play.grounded = true;
		}
		if (col.gameObject.tag == "Platform") {
			play.transform.parent = col.transform;
			play.grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			play.grounded = false;
		}
		if (col.gameObject.tag == "Platform") {
			play.transform.parent = null;
			play.grounded = false;
		}
	}
}

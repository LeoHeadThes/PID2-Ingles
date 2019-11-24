using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxSpeed = 1f;
	public float speed = 1f;
	public bool regular;
	public player panda;
	//public GameObject player;

	private Rigidbody2D rb2d;
	private bool queColor;
	//private GameObject hope;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		//hope = Instantiate (player) as GameObject;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb2d.AddForce(Vector2.right * speed);		
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){
			speed = -speed;
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}

		if (speed < 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (speed > 0){
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		queColor = panda.getColor ();//si es true es rojo
		Debug.Log(queColor);
		if (col.gameObject.tag == "Player") {

			if (transform.position.y < col.transform.position.y && queColor == true && regular == false) {
				panda.EnemyJump ();
				score.scoreValue += 100;
				Destroy (gameObject);
			} else if (transform.position.y < col.transform.position.y && queColor == false && regular == true) {
				panda.EnemyJump ();
				score.scoreValue += 100;
				Destroy (gameObject);
			} else {
				panda.EnemyKnockBack (transform.position.x);
			}
		}
	}
}

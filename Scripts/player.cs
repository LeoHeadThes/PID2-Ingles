using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speed = 20f;
	public float jumpPower = 7f;
	public bool grounded;
	public static bool GameIsPaused = false;
	public bool colorPanda;
	public AudioClip jumpClip, dieClip, switchClip, pauseClip, hurtClip, squishClip,eatClip;

	private Rigidbody2D rb2d;
	private Animator anim;
	private SpriteRenderer spr;
	private bool jump;
	private bool movement = true;
	private GameObject healthbar;
	private AudioSource audioPlayer;
	private int salud;

	// Use this for initialization
	void Start () {
		salud = 100;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer> ();
		colorPanda = true;
		spr.color = Color.red;
		healthbar = GameObject.Find ("HealthBar");
		audioPlayer = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			audioPlayer.clip = pauseClip;
			audioPlayer.Play ();
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			audioPlayer.clip = switchClip;
			audioPlayer.Play ();
			if (colorPanda) {
				spr.color = Color.green;
				colorPanda = false;
			} else {
				spr.color = Color.red;
				colorPanda = true;
			}
		}

		anim.SetBool ("Grounded", grounded);

		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

		anim.SetFloat("Force", Mathf.Abs(rb2d.velocity.y));

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = true;
			audioPlayer.clip = jumpClip;
			audioPlayer.Play ();
		}
	}

	void FixedUpdate(){

		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.5f;

		if (grounded)
			rb2d.velocity = fixedVelocity;
		
		float h = Input.GetAxis ("Horizontal");

		if (!movement)
			h = 0;
		
		rb2d.AddForce (Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f) 
			transform.localScale = new Vector3 (1f, 1f, 1f);
		
		if (h < 0.1f) 
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		

		if (jump) {
			rb2d.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			fixedVelocity.x *= 0.75f;
			jump = false;
		}
			
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "DeathZone") {
			Death ();
		}
		if (col.gameObject.tag == "Fruit") {
			audioPlayer.clip = eatClip;
			audioPlayer.Play ();
			score.scoreValue += 50;
			healthbar.SendMessage ("EatRecover", 10);
			if(salud <= 90)
			salud += 10;
			Destroy (col.gameObject);
			Debug.Log (salud);
		}
		if (col.gameObject.tag == "Exit") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		}
	}

	public void EnemyJump(){
		audioPlayer.clip = squishClip;
		audioPlayer.Play ();
		jump = true;
	}

	public void EnemyKnockBack(float enemyPosX){

		audioPlayer.clip = hurtClip;
		audioPlayer.Play ();

		healthbar.SendMessage ("TakeDamage", 15);
		salud -= 15;
		jump = true;
		if (salud <= 0) {
			Vidas.ups = Vidas.ups -0.5f;
			Death ();
		}
		float side = Mathf.Sign (enemyPosX - transform.position.x);
		rb2d.AddForce (Vector2.left * side * jumpPower, ForceMode2D.Impulse);

		movement = false;
		spr.color = Color.magenta;
		Invoke ("EnableMovement", 0.7f);


	}

	void EnableMovement(){
		movement = true;
		spr.color = Color.white;
		if (colorPanda) {
			spr.color = Color.red;
		} else {
			spr.color = Color.green;
		}
	}

	public bool getColor(){
		return colorPanda;
	}

	public void Death(){
		audioPlayer.clip = dieClip;
		audioPlayer.Play ();
		Vidas.ups = Vidas.ups -0.5f;
		if (Vidas.ups < 0f) {
			score.scoreValue = 0;
			SceneManager.LoadScene ("menu");
		}else
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}

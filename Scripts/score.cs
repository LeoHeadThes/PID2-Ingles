using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public static int scoreValue = 0;
	Text puntaje;

	// Use this for initialization
	void Start () {
		puntaje = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		puntaje.text = "Score " + scoreValue;
	}
}

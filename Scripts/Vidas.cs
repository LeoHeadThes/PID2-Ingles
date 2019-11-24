using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vidas : MonoBehaviour {

	public static float ups = 3;
	Text vida;

	// Use this for initialization
	void Start () {
		vida = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		vida.text = "x0" + ups;
	}
}

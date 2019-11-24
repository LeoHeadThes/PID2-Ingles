using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageChanger : MonoBehaviour {

	public int rand;
	public Sprite [] sprites;
	// Use this for initialization
	void Start () {
		changer ();
	}
	
	public void setImage(int seleccionar){
		rand = seleccionar;
		changer ();
	}

	void changer () {
		gameObject.GetComponent<Image> ().sprite = sprites[rand];
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FormManager : MonoBehaviour {

	public string[] presentes = new string [10];
	public string[] preteritos = new string [10];

	public Button textoPresente, textoPreterito;
	public int i;
	private int seleccion;

	void Start () {
		//displayBotones ();
	}

	public void setButtons(int select){
		i = select;
		displayBotones ();
	}

	public void displayBotones(){
		textoPresente.GetComponentInChildren<Text>().text = presentes [i];
		textoPreterito.GetComponentInChildren<Text>().text = preteritos [i];
		textoPresente.GetComponent<Image>().color = Color.white;
		textoPreterito.GetComponent<Image>().color = Color.white;
	}
	
	public void presente(){
		seleccion = 1;
		textoPresente.GetComponent<Image>().color = Color.green;
		textoPreterito.GetComponent<Image>().color = Color.white;
		Debug.Log ("Presente");
	}

	public void preterito(){
		seleccion = 0;
		textoPresente.GetComponent<Image>().color = Color.white;
		textoPreterito.GetComponent<Image>().color = Color.green;
		Debug.Log ("Preterito");
	}

	public bool returner(){
		Debug.Log (seleccion);
		if (seleccion == 1)
			return true;
		else
			return false;
	}
}

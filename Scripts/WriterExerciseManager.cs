using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WriterExerciseManager : MonoBehaviour {
	public Text textoSpanish;
	public InputField textoEnglish;
	int i = 0, j, total = 0,areEqual;
	bool evaluado;
	[TextArea(3,10)]
	public string[] traducciones = new string [11];
	private string[] usuario = new string[11];
	public string[] respuestas = new string [11];

	void Start () {
		textoSpanish.text = "Ingrese el verbo en inglés";
		textoEnglish.Select ();
		textoEnglish.text = "Write here...";
		FindObjectOfType <ImageChanger> ().setImage (11);
		FindObjectOfType <PlayImage> ().setAudio (11);
	}

	public void DisplayTheNextSentence (){
		if (i < 11) {
			usuario [i] = textoEnglish.text;
			Debug.Log ("posicion "+i+usuario[i]);
			textoEnglish.Select ();
			textoEnglish.text = "";
			i++;
			textoSpanish.text = traducciones [i];
			FindObjectOfType <PlayImage> ().setAudio (i);
			FindObjectOfType <ImageChanger> ().setImage (i);
		} else {
			FindObjectOfType <ImageChanger> ().setImage (i);
			FindObjectOfType <PlayImage> ().setAudio (i);
			evaluacion ();
			if (evaluado == false) {
				textoEnglish.Select ();
				textoEnglish.text = "Regresar al menu...";
				textoSpanish.text = "RESULTADO\n" + total + " / 100";
				evaluado = true;
			}else
				SceneManager.LoadScene ("menu");
		}
	}

	public void evaluacion(){
		for (j = 1; j < 11; j++) {
			//areEqual = usuario [j].Equals (respuestas [j]);
			areEqual = string.Compare (usuario [j], respuestas [j], StringComparison.OrdinalIgnoreCase);
			if (areEqual==0)
				total = total + 10;
			Debug.Log(usuario[j]+" y "+respuestas[j]+j+" "+areEqual);
		}
	}

}

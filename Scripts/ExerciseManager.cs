using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ExerciseManager : MonoBehaviour {


	public Text textoEjercicio;
	int i = 0, j, total = 0;
	public bool[] respuestas = new bool[10];//PRESENTE -> TRUE | PRETERITE -> FALSE
	private bool [] resultados = new bool[10];
	private bool evaluado = false;
	[TextArea(3,10)]
	public string[] sentences = new string [10];

	void Start () {
		DisplayTheNextSentence ();
	}

	public void DisplayTheNextSentence (){
		if (i < 10) {
			textoEjercicio.text = sentences [i];
			FindObjectOfType <PlayImage> ().setAudio (i);
			FindObjectOfType <ImageChanger> ().setImage (i);
			FindObjectOfType <FormManager> ().setButtons (i);
			resultados[i] = FindObjectOfType <FormManager> ().returner ();
			i++;
		} else {
			FindObjectOfType <ImageChanger> ().setImage (i);
			FindObjectOfType <PlayImage> ().setAudio (i);
			evaluacion ();
			if (evaluado == false) {
				textoEjercicio.text = "RESULTADO\n" + total + " / 100";
				evaluado = true;
			}else
				SceneManager.LoadScene ("menu");
		}
	}

	public void evaluacion(){
		for (j = 0; j < 10; j++)
			if (respuestas [j] == resultados [j]) {
				total = total + 10;
				Debug.Log (j+" "+resultados[j]);
			}
	}

}

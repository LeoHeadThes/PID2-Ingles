using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue){
		nameText.text = dialogue.name;
		sentences.Clear ();

		foreach(string sentence in dialogue.sentences){
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}

	public void DisplayNextSentence (){
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		dialogueText.text = sentence;
	}

	public void EndDialogue(){
		Debug.Log ("End of exercise");
	}
}

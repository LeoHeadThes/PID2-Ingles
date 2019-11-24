using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayImage : MonoBehaviour {
	private AudioSource audioPlayer;
	public AudioClip [] examples;
	public int i = 0;

	// Use this for initialization
	void Start () {
		audioPlayer = GetComponent<AudioSource> ();
	}

	public void setAudio(int select){
		i = select;
	}

	public void playButton(){
		audioPlayer.clip = examples[i];
		audioPlayer.Play ();
	}
}

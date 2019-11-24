using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

	public bool go = true;
	public AudioMixer audioMixer;
	public AudioClip okClip, baClip;
	private AudioSource audioPlayer;

	void Start () {
		audioPlayer = GetComponent<AudioSource> ();
		Vidas.ups = 3;
	}

	public void setCheat(){
		go = false;
	}

	public void SelectSound(){
		if(go)
			audioPlayer.clip = okClip;
		else
			audioPlayer.clip = baClip;
		
		audioPlayer.Play ();
	}

	public void PlayGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}

	public void ReloadGame(){
		SceneManager.LoadScene ("menu");
	}

	public void QuitGame(){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}

	public void SetVolume(float volume){
		audioMixer.SetFloat ("volume", volume);
	}
}

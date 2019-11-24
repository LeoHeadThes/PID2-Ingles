using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoaderScence : MonoBehaviour {
	
	public void LoadVerb(){
		SceneManager.LoadScene ("Write-Verb");
	}

	public void LoadSentence(){
		SceneManager.LoadScene ("Select-PresentPreterite");
	}

}

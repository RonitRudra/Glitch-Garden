using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	float loadDelay = 3f;
	
	void Start(){
		Invoke("LoadNextLevel",loadDelay);
	}
	
	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	
}
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	float loadDelay = 3f;
	public bool autoLoad;
	
	void Start(){
		//autoload next level after delay (splash screen)
		// Never going back to splash screen so ditched singleton pattern
		if(autoLoad == true){
			Invoke("LoadNextLevel",loadDelay);
		}
		
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
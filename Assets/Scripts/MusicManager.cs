using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	#region Global Variables
	// Make Array of audio clips for each scene
	public AudioClip[] LevelMusic;
	
	// Make audiosource object
	private AudioSource audioSource;
	
	#endregion
	// Use this for initialization
	void Awake () {
		// object not destroyed on scene loads
		// no need to check for duplicates as splash screen not revisited
		DontDestroyOnLoad(gameObject);
	}
	
	void Start(){
		// get audiosource component from same object
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnLevelWasLoaded(int level){
		// set clip for current level
		AudioClip music_current = LevelMusic[level];
		// If clip present then play on loop
		if(music_current){
			audioSource.clip = music_current;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void VolumeControl(float volume){
		audioSource.volume = volume;
			
	}
}

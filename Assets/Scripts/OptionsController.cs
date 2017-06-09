using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	private MusicManager musicManager;
	float unsaved_volume;
	float unsaved_difficulty;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		unsaved_difficulty = difficultySlider.value;
		print(difficultySlider.value.ToString());
		unsaved_volume = volumeSlider.value;
		print(volumeSlider.value.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.VolumeControl(volumeSlider.value);
		
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}
	
	public void ExitWithoutSave(){
	//TODO Add panel asking for unsaved changes
		PlayerPrefsManager.SetMasterVolume(unsaved_volume);
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		musicManager.VolumeControl(unsaved_volume);
		PlayerPrefsManager.SetDifficulty(unsaved_difficulty);
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		
		levelManager.LoadLevel("01a Start");
		
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.75f;
		difficultySlider.value = 2f;
	}
	
	
}

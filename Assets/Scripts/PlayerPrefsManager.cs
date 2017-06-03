using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	// Unity Player Prefs has no Bool so use 1 True and 0 False
	// Clamp ranges to prevent slider malfunction

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume ( float volume){
		if (volume >0f && volume < 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY,volume);
		} else {
			volume = Mathf.Clamp(volume,0f,1f);
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY,volume);
			//Debug.LogError ("Master Volume of Out of Range");
		}
	}
	
	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
		}
	
	public static void UnlockLevel(int level){
		if(level <= Application.levelCount-1){
			PlayerPrefs.SetInt(LEVEL_KEY+level.ToString(),1);
		}else{
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	
	public static bool isLevelUnlocked(int level){
		int levelvalue = PlayerPrefs.GetInt(LEVEL_KEY+level.ToString());
		bool islevelunlocked = (levelvalue==1);
		if(level <= Application.levelCount-1){
			return islevelunlocked;
		}else{
			Debug.LogError("Level not in build order");
			return false;
		}
	}
	
	public static void SetDifficulty(float difficulty){
		if(difficulty >=1f && difficulty <= 3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY,difficulty);
		}else{
			difficulty = Mathf.Clamp(difficulty,1f,3f);
			PlayerPrefs.SetFloat (DIFFICULTY_KEY,difficulty);
			//Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}

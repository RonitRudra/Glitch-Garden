using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private GameObject parent;
	public GameObject[] spawnArray;
	// Use this for initializatio
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in spawnArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attacker){
		float rarityInSec = attacker.GetComponent<Attacker>().rarity*10;
		// should see particular enemy once every rarityInSec seconds 
		float spawnsPerSec = 1/rarityInSec;
		if(Time.deltaTime >spawnsPerSec){
			Debug.LogWarning("Spawn Rate faster than frame rate");
		}
		//Divide by number of lanes
		float threshold = spawnsPerSec*Time.deltaTime/5;
		
		if(Random.value < threshold){
			return true;
		} else{
			return false;
		}
	}
}

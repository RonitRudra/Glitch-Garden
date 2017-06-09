using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.GetComponent<Attacker>()){
			levelManager.LoadLevel("03b Lose");
		}
	}
}

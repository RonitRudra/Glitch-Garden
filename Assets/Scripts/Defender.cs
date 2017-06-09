using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public StarDisplay starDisplay;
	[Tooltip("Cost of Placing Defender")]
	public int starCost;
	
	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars(int amount){
		starDisplay.AddStars(amount);
	}
	
}

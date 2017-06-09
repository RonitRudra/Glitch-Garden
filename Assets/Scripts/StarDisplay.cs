using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {
	private Text text;
	private int stars = 100;
	public enum Status {SUCCESS, FAILURE};
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = stars.ToString();
	}
	
	// called from defender script
	public void AddStars(int amount){
			stars+=amount;		
	}
	
	public Status UseStars(int amount){
		if(stars>=amount){
			stars-=amount;
			return Status.SUCCESS;
		}else{
			return Status.FAILURE;
		}	
	}
}

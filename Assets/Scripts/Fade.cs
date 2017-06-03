using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this script is a separate gameobject so explicitly deactivate panel
public class Fade : MonoBehaviour {
	public Image panel;
	public float fadetime=3f;
	// Use this for initialization
	void Start () {
		panel.CrossFadeAlpha(0,fadetime,true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad >= fadetime){
			panel.gameObject.SetActive(false);
		}
		
	}
}

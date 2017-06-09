using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		defenderParent = GameObject.Find("Defenders");
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown(){
		//print (Input.mousePosition);
		//print (worldPoinMouseClick());
		Vector2 pos = roundWorldpos(worldPointMouseClick());
		GameObject obj = Button.selectedDefender;
		//Find cost of selected defender
		int defenderCost = obj.GetComponent<Defender>().starCost;
		//Only allow first four columns for defender placement
		if (pos.x <= 4) {
			//Call UseStars and check enum for success
			if(starDisplay.UseStars(defenderCost)==StarDisplay.Status.SUCCESS){
				SpawnDefender(pos, obj);
			}else{
				starDisplay.AddStars(defenderCost);
				Debug.Log("Insufficient Stars");
			}
		}else{
			Debug.LogError ("Cannot Place Defender There");
		}
		
	}
	
	Vector2 worldPointMouseClick(){
		float mousex = Input.mousePosition.x;
		float mousey = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 triplet = new Vector3(mousex,mousey,distanceFromCamera);
		Vector2 worldpos = myCamera.ScreenToWorldPoint(triplet);
		return worldpos;
	}
	
	Vector2 roundWorldpos(Vector2 mousepos){
		float x = Mathf.RoundToInt(mousepos.x);
		float y = Mathf.RoundToInt(mousepos.y);
		return new Vector2(x,y);
	}

	void SpawnDefender (Vector2 pos, GameObject obj)
	{
			GameObject newdef = Instantiate (obj, pos, Quaternion.identity) as GameObject;
			newdef.transform.parent = defenderParent.transform;
	}
}

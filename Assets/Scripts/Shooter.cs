using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLane;
	
	
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		// Newly spawned defenders cannot find Projectiles Object added through prefab
		// Create a new hierarchy if not present
		projectileParent = GameObject.Find("Projectiles");
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}
	
	void Update(){
		if(AttackerInLane()){
			animator.SetBool("isAttacking",true);
		}else{
			animator.SetBool("isAttacking",false);
		}
	}
	
	private void FireControl(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	bool AttackerInLane(){
		if(myLane.transform.childCount<=0){
			return false;
		}
		//check for attackers to the right of the defender
		foreach(Transform attackers in myLane.transform){
			if(attackers.transform.position.x>=transform.position.x){
				return true;
			}
		}
		// attacker behind defender
		return false;	
	}
	
	//find lane of spawned defender
	void SetMyLaneSpawner(){
			Spawner[] spawnArray = GameObject.FindObjectsOfType<Spawner>();
		foreach(Spawner lane in spawnArray){
			if(lane.transform.position.y==transform.position.y){
				myLane = lane;
				return;
			}
		}
		Debug.LogError("Can't find spawner in lane");
	}
		
}

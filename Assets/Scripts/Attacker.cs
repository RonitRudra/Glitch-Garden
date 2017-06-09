using UnityEngine;
using System.Collections;

//Collision->Attack(Sets curent Target)->StrikeCurrentTarget(Does the damage)

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Attacker))]
public class Attacker : MonoBehaviour {

	[Range (-1f,1.5f)] private float currentSpeed;
	[Tooltip("How often does this enemy appear")]
	[Range(1,10)]
	public int rarity;
	// Rarity in seconds would be in multiples of 10
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Translate Pivot of Entity by direction*speed*time
		transform.Translate(Vector3.left*currentSpeed*Time.deltaTime);
		if(!currentTarget){
			animator.SetBool("isAttacking",false);
		}
	}
	
	void OnTriggerEnter2D(){
		Debug.Log(name+" Collision");
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;		
	}
	
	// Called From Animator
	public void StrikeCurrentTarget(float damage){
		Debug.Log(name+" Does "+damage+" Damage");
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
		
	}
}

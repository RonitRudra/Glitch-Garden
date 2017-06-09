using UnityEngine;
using System.Collections;

// RequireComponent is a sanity check for new entities added later on
// Checks whether entities of class Fox do have an attacker script attached
[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {
	private Animator animator;
	private Attacker attacker;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject defender = collider.gameObject;
		// Abort
		if(!defender.GetComponent<Defender>()){
			return;
		}
		if(defender.GetComponent<Stone>()){
			animator.SetTrigger("Jump Trigger");
		} else{
			animator.SetTrigger("isAttacking");
			attacker.Attack(defender);
		}
		Debug.Log ("Fox collided with "+collider.name);
	}
}

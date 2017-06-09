using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	// Use this for initialization
	
	public void DealDamage(float damage){
		health -=damage;
		if(health<=0){
			Destroy(gameObject);	
		}
	}
}

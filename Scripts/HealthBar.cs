using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	float hp,maxHp = 100f;
	public Image health;

	// Use this for initialization
	void Start () {
		hp = maxHp;
	}

	public void TakeDamage(float amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		health.transform.localScale = new Vector2 (hp / maxHp, 1);
	}

	public void EatRecover(float amount){
		hp = Mathf.Clamp (hp + amount, 0f, maxHp);
		health.transform.localScale = new Vector2 (hp / maxHp, 1);
	}
		
}

using UnityEngine;
using System.Collections;

public class DrawScenceLine : MonoBehaviour {

	public Transform from;
	public Transform to;

	void OnDrawGizmosSelected(){
		if (from != null && to != null) {
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine (from.position, to.position);
			Gizmos.DrawSphere (from.position,0.15f);
		}
	}
}

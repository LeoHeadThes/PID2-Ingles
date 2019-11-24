using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate(){

		Vector3 desiredPosition = target.position + offset;
		//desiredPosition.y = offset.y;
		transform.position = desiredPosition;
	}
}

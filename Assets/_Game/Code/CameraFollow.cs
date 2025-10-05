using UnityEngine;

class CameraFollow : MonoBehaviour
{

	[SerializeField] float followSpeed;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] GameObject player;

	void FixedUpdate()
	{
		Vector2 delta = player.transform.position - rb.transform.position;
		rb.linearVelocity = delta * followSpeed;
	}

}
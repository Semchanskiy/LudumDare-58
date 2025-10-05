using UnityEngine;

class EnemyGhost : MonoBehaviour
{

	[SerializeField] float speed;
	[SerializeField] Vector2 targetOffset;
	[SerializeField] Rigidbody2D rb;
	Vector2 targetPos;

	void Start()
	{
		targetPos = (Vector2) G.run.Player.transform.position + targetOffset;
	}

	void FixedUpdate()
	{
		Vector2 delta = targetPos - (Vector2) rb.transform.position;
		if (delta.sqrMagnitude > 1)
		{
			delta = delta.normalized;
		}
		rb.linearVelocity = delta;
	}

}
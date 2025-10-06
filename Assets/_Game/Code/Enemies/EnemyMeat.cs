using UnityEngine;

class EnemyMeat : MonoBehaviour
{

	[SerializeField] float speed;
	[SerializeField] Rigidbody2D rb;

	void FixedUpdate()
	{
		if (!G.run.IsPlay)
		{
			rb.linearVelocity = Vector2.zero; 
			return;
		}
		Vector2 targetPos = (Vector2) G.run.Player.transform.position;
		Vector2 delta = targetPos - (Vector2)rb.transform.position;
		if (delta.sqrMagnitude > 1)
		{
			delta = delta.normalized;
		}
		rb.linearVelocity = delta * speed;
	}

}
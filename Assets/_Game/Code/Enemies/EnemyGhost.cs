using System;
using UnityEngine;

class EnemyGhost : MonoBehaviour
{

	[SerializeField] float flySpeed;
	[SerializeField] float chargeSpeed;
	[SerializeField] Animator animator;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] SpriteRenderer body;
	[SerializeField] Sprite spriteBodySmiling;
	int mode;
	float chargeTimer;
	Vector2 targetPos;

	void Start()
	{
		targetPos = (Vector2)G.run.Player.transform.position;
		Vector2 delta = targetPos - (Vector2)rb.transform.position;
	}

	void StartSmiling()
	{
		body.sprite = spriteBodySmiling;
	}

	void FixedUpdate()
	{
		if (!G.run.IsPlay)
		{
			rb.linearVelocity = Vector2.zero; 
			return;
		}
		if (mode == 0 || mode == 1)
		{ 
			targetPos = (Vector2)G.run.Player.transform.position;
		}

		Vector2 delta = targetPos - (Vector2) rb.transform.position;

		if (delta.magnitude > 10f)
		{
			Destroy(gameObject);
			return;
		}

		if (delta.x >= 0)
		{
			transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		else
		{
			transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}

		if (mode == 0 && delta.magnitude < 2.5f)
		{
			StartSmiling();
			mode = 1;
		}

		if (delta.sqrMagnitude > 1)
		{
			delta = delta.normalized;
		}

		float moveSpeed = flySpeed;
		if (mode == 1)
		{
			moveSpeed = 0.2f;
			chargeTimer += Time.fixedDeltaTime;
			if (chargeTimer >= 1)
			{
				mode = 2;
			}
			// set sprite smiling
		}
		else if (mode == 2)
		{
			moveSpeed = chargeSpeed;
		}
		rb.linearVelocity = delta * moveSpeed;

		if (delta.magnitude < 0.1f)
		{
			animator.Play("GhostFadeOut");
		}
	}

	void AnimationEnded()
	{
		Destroy(gameObject);
	}

}
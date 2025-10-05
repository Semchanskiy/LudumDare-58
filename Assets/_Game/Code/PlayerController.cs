using UnityEngine;

class PlayerController : MonoBehaviour
{

	[SerializeField] float speed;
	Vector2 direction;
	Vector2 targetDirection;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] Animator animator;

	void Update()
	{
		direction = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		).normalized;
	}

	void FixedUpdate()
	{
		// с плавностью
		targetDirection = Vector2.Lerp(targetDirection, direction, 0.3f);
		rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * targetDirection);

		// без плавности
		// rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

		if (targetDirection.sqrMagnitude > 0.01f)
		{
			animator.Play("PlayerWalk");
			if (targetDirection.x >= 0) {
				transform.localScale = new Vector3(-1, 1, 1);
			} else {
				transform.localScale = new Vector3(1, 1, 1);
			}
		}
		else
		{
			animator.Play("PlayerIdle");
		}
	}

}
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

class PlayerController : MonoBehaviour
{

	[SerializeField] float speed;
	Vector2 direction;
	Vector2 targetDirection;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] Animator animator;
	[SerializeField] bool isHandsStageEnabled;
	Coroutine handsEnemyTimer;
	[SerializeField] GameObject handsEnemyPrefab;
	GameObject handsEnemy;
	bool isEnableHandsSpawning;
	bool isMovementEnabled = true;

	void Start()
	{
		if (G.run)
		{
			G.run.OnChangeCountThings += (stage) =>
			{
				isHandsStageEnabled = stage >= 3;
			};
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent(out EnemyGhost ghost))
		{
			isMovementEnabled = false;
			Debug.Log("Game over in 2 sec");
		}
	}

	public void CatchByHands()
	{
		isMovementEnabled = false;
		Debug.Log("Game over in 2 sec");
	}

	IEnumerator EnableHandsEnemyTimer()
	{
		yield return new WaitForSeconds(5f);
		isEnableHandsSpawning = true;
		handsEnemyTimer = null;
	}

	void ClearHandsTimer()
	{
		isEnableHandsSpawning = false;
		if (handsEnemyTimer != null)
		{
			StopCoroutine(handsEnemyTimer);
			handsEnemyTimer = null;
		}
	}

	void StarHandsTimer()
	{
		if (handsEnemy)
		{
			return;
		}

		if (isEnableHandsSpawning && handsEnemyPrefab)
		{
			handsEnemy = Instantiate(handsEnemyPrefab, rb.transform.position, Quaternion.identity);
			return;
		}

		if (handsEnemyTimer == null)
		{
			handsEnemyTimer = StartCoroutine(EnableHandsEnemyTimer());
		}
	}

	void Update()
	{
		if (!isMovementEnabled)
		{
			direction = Vector2.zero;
			return;
		}
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
			if (targetDirection.x >= 0)
			{
				transform.localScale = new Vector3(-1, 1, 1);
			}
			else
			{
				transform.localScale = new Vector3(1, 1, 1);
			}
			if (isHandsStageEnabled)
			{
				ClearHandsTimer();
			}
		}
		else
		{
			animator.Play("PlayerIdle");
			if (isHandsStageEnabled)
			{
				StarHandsTimer();
			}
		}
	}

}
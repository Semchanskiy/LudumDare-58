using System.Collections;
using UnityEngine;

class PlayerController : SpriteChanger
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
	private float StepTime = 0.25f;
	private float StepTimer = 0;

	protected override void Start()
	{
		StartCoroutine(StepSoundLoop());
		base.Start();
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
		else if(collider.TryGetComponent(out Item item))
		{
			G.run.CollectItem();
			item.Kill();
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

	protected override void ChangeThings(int i)
    {
        base.ChangeThings(i);
		StartCoroutine(StepSoundLoop());
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

	protected override IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected override IEnumerator FirstThing()
    {
        yield return null;
    }
    
    protected override IEnumerator SecondThing()
    {
        yield return null;
    }
    protected override IEnumerator ThirdThing()
    {
        yield return null;
    }
    protected override IEnumerator FourthThing()
    {
        yield return null;
    }
    protected override IEnumerator FifthThing()
    {
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        yield return null;
    }
    
    protected override IEnumerator SeventhThing()
    {
        yield return null;
    }

    private IEnumerator StepSoundLoop()
    {
	    while (StepTime>-5)
	    {
		    if (direction.sqrMagnitude > 0.01f)
			{
				if (G.audio)
				{
					G.audio.PlaySFX("Step", 1, Random.Range(0.8f, 1.2f));
				}
				yield return new WaitForSeconds(StepTime);
			}
		    yield return new WaitForSeconds(0.1f);
	    }
    }

}
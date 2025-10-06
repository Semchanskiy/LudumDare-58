using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerController : SpriteChanger
{
	[SerializeField] float speed;
	Vector2 direction;
	Vector2 targetDirection;
	[SerializeField] Rigidbody2D rb;
	Animator[] animators;
	private int _currentIndexAnim = 0;
	[SerializeField] bool isHandsStageEnabled;
	[SerializeField] SpriteRenderer shadowSprite;
	[SerializeField] SpriteRenderer playerSprite;
	Coroutine handsEnemyTimer;
	bool isEnableHandsSpawning;
	bool isMovementEnabled = true;
	private float StepTime = 0.25f;

	protected override void Awake()
	{
		animators = GetComponentsInChildren<Animator>();
		Debug.Log(animators.Length);
		base.Awake();
	}

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
		if (!G.run.IsPlay) return;
		if (collider.TryGetComponent(out EnemyGhost ghost))
		{
			isMovementEnabled = false;
			StartCoroutine( GameOver());
		}
		else if (collider.TryGetComponent(out EnemyMeat meat))
		{
			isMovementEnabled = false;
			StartCoroutine( GameOver());
		}
		else if (collider.TryGetComponent(out Item item))
		{
			G.run.CollectItem();
			item.Kill();
		}
	}

	public void CatchByHands()
	{
		isMovementEnabled = false;
		StartCoroutine( GameOver());
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
		if (G.enemies.IsHandsEnemySpawned())
		{
			return;
		}
		
		if (isEnableHandsSpawning)
		{
			G.enemies.CreateEnemyHands();
			return;
		}

		if (handsEnemyTimer == null)
		{
			handsEnemyTimer = StartCoroutine(EnableHandsEnemyTimer());
		}
	}

	void Update()
	{
		if (!G.run.IsPlay) return;
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

	void LateUpdate()
	{
		if (!G.run.IsPlay) return;
		shadowSprite.sortingOrder = playerSprite.sortingOrder - 1;
	}

	void FixedUpdate()
	{
		if (!G.run.IsPlay) return;
			// с плавностью
			targetDirection = Vector2.Lerp(targetDirection, direction, 0.3f);
			rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * targetDirection);

			// без плавности
			// rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

			if (targetDirection.sqrMagnitude > 0.01f)
			{
				animators[_currentIndexAnim].Play("PlayerWalk");
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
				animators[_currentIndexAnim].Play("PlayerIdle");
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
	    G.audio.PlaySFX("Overload");
	    
        yield return null;
    }
    
    protected override IEnumerator SecondThing()
    {
	    G.audio.PlaySFX("Overload");
	    
        yield return null;
    }
    protected override IEnumerator ThirdThing()
    {
	    G.audio.PlaySFX("Overload");
	    _currentIndexAnim = 1;
	    EnableChildrenForIndex(1);
        yield return null;
    }
    protected override IEnumerator FourthThing()
    {
	    G.audio.PlaySFX("Overload");
        yield return null;
    }
    protected override IEnumerator FifthThing()
    {
	    G.audio.PlaySFX("Overload");
	    _currentIndexAnim = 2;
	    EnableChildrenForIndex(2);
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
	    G.audio.PlaySFX("Overload");
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
		    if (direction.sqrMagnitude > 0.01f && G.run.IsPlay)
			{
				if (G.audio)
				{
					G.audio.PlaySFX("Step", 0.6f, Random.Range(0.9f, 1.1f));
				}
				yield return new WaitForSeconds(StepTime);
			}
		    yield return new WaitForSeconds(0.1f);
	    }
    }

    private IEnumerator GameOver()
    {
	    
	    yield return new WaitForSeconds(2f);
	    //звук мяса
	    G.ui.losePanel.Show();
    }

}
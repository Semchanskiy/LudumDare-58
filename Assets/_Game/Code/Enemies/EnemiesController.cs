using UnityEngine;

public class EnemiesController : MonoBehaviour
{

	[SerializeField] GameObject ghostEnemyPrefab;
	[SerializeField] GameObject handsEnemyPrefab;
	[SerializeField] GameObject meatEnemyPrefab;
	GameObject ghostEnemy;
	GameObject handsEnemy;
	GameObject meatEnemy;
	[SerializeField] bool isGhostStageEnabled;
	float ghostSpawnTimer;
	float ghostSpawnFrequency;

	void Start()
	{
		G.enemies = this;
		ghostSpawnFrequency = 25f;
		ghostSpawnTimer = ghostSpawnFrequency;
		if (G.run)
		{
			G.run.OnChangeCountThings += (stage) =>
			{
				isGhostStageEnabled = stage >= 4;
				// isMeatStageEnabled = stage >= 2;

				if (stage == 2)
				{
					CreateEnemyMeat();
				}

				if (stage == 4)
				{
					ghostSpawnFrequency = 25f;
				}
				else if (stage == 5)
				{
					ghostSpawnFrequency = 20f;
				}
				else if (stage == 6)
				{
					ghostSpawnFrequency = 20f;
				}
				else // stage == 7
				{
					ghostSpawnFrequency = 15f;
				}
			};
		}
	}

	void Update()
	{
		if (isGhostStageEnabled && !IsGhostEnemySpawned())
		{
			ghostSpawnTimer -= Time.deltaTime;
			if (ghostSpawnTimer <= 0)
			{
				CreateEnemyGhost();
				ghostSpawnTimer = ghostSpawnFrequency;
			}
		}
	}

	Vector2 GetSpawnPositionOutsideScreen()
	{
		float spawnOffsetX = 6f;
		float spawnOffsetY = 3.5f;
		Vector2 offset = ((Vector2) Random.onUnitSphere).normalized;
		return (Vector2) G.run.Player.transform.position + new Vector2(offset.x * spawnOffsetX, offset.y * spawnOffsetY - 1f);
    }

	public bool IsHandsEnemySpawned()
	{
		return handsEnemy != null;
	}

	public bool IsGhostEnemySpawned()
	{
		return ghostEnemy != null;
	}

	public bool IsMeatEnemySpawned()
	{
		return meatEnemy != null;
	}

	public void CreateEnemyGhost()
	{
		if (IsGhostEnemySpawned())
		{
			return;
		}
		Vector3 spawnPosition = GetSpawnPositionOutsideScreen();
		ghostEnemy = Instantiate(ghostEnemyPrefab, spawnPosition, Quaternion.identity);
	}

	public void CreateEnemyHands()
	{
		if (IsHandsEnemySpawned())
		{
			return;
		}
		Vector2 playerPos = G.run.Player.transform.position;
		handsEnemy = Instantiate(handsEnemyPrefab, playerPos, Quaternion.identity);
	}

	public void CreateEnemyMeat()
	{
		if (IsMeatEnemySpawned())
		{
			return;
		}
		Vector3 spawnPosition = GetSpawnPositionOutsideScreen();
		meatEnemy = Instantiate(meatEnemyPrefab, spawnPosition, Quaternion.identity);
	}

}
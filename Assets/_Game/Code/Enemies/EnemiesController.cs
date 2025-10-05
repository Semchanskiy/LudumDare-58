using UnityEngine;

public class EnemiesController : MonoBehaviour
{

	[SerializeField] GameObject ghostEnemyPrefab;
	[SerializeField] GameObject handsEnemyPrefab;
	[SerializeField] GameObject meatEnemyPrefab;
	GameObject ghostEnemy;
	GameObject handsEnemy;
	GameObject meatEnemy;

	public void CreateEnemyGhost()
	{
		Vector2 pos = Vector2.zero;
		handsEnemy = Instantiate(ghostEnemyPrefab, pos, Quaternion.identity);
	}

	public bool IsHandsEnemySpawned()
	{
		return handsEnemy != null;
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
		Vector2 pos = Vector2.zero;
		handsEnemy = Instantiate(meatEnemyPrefab, pos, Quaternion.identity);
	}

}
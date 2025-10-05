using UnityEngine;

class EnemyHands : MonoBehaviour
{

	[SerializeField] float grabRange = 1;

	void GrabPlayer()
	{
		Vector2 playerPos = G.run.Player.transform.position;
		Vector2 delta = playerPos - (Vector2)transform.position;
		if (delta.magnitude <= grabRange)
		{
			G.run.Player.GetComponent<PlayerController>().CatchByHands();
		}
	}

	void AnimationEnded()
	{
		Destroy(transform.parent.gameObject);
	}

}
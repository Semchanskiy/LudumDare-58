using System;
using UnityEngine;

class EnemyMeat : MonoBehaviour
{
	private AudioSource _audioSource;
	[SerializeField] float speed;
	[SerializeField] Rigidbody2D rb;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

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
		
		float distance = Vector3.Distance(transform.position, G.run.Player.transform.position);
		float normalizedDistance = Mathf.Clamp01(distance / 10);
		float proximityFactor = 1f - normalizedDistance;
		
		_audioSource.volume = Mathf.Lerp(0f, 1f, proximityFactor);
	}

}
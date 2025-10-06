using UnityEngine;

public class CryMushroom : MonoBehaviour
{
    private AudioSource _audioSource;
    void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            float distance = Vector3.Distance(transform.position, G.run.Player.transform.position);
            float normalizedDistance = Mathf.Clamp01(distance / 5);
            float proximityFactor = 1f - normalizedDistance;
            _audioSource.volume = Mathf.Lerp(0f, 1f, proximityFactor);
        }
    }
}

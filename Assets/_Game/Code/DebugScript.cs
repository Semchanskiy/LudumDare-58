using TMPro;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
     private TextMeshProUGUI _text;
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1.0f / Time.smoothDeltaTime;
        _text.SetText( Mathf.RoundToInt(fps).ToString());
        //_text.SetText((1f/Time.deltaTime).ToString());
    }
}

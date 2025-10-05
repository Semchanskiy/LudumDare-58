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
        _text.SetText(G.run.countThings.ToString());
    }
}

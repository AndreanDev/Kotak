using TMPro;
using UnityEngine;

public class ToggleText : MonoBehaviour
{
    // Call this function to change the text dynamically
    public void SetText(TextMeshProUGUI textToToggle, string newText)
    {
        if (textToToggle != null)
            textToToggle.text = newText;
    }
}

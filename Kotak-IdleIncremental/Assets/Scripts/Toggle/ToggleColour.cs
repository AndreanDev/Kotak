using UnityEngine;
using UnityEngine.UI; // Needed for UI Image

public class ToggleColour : MonoBehaviour
{
    public void UpdateObjectColorToGreen(GameObject obj)
    {
        if (obj != null)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.green;
            }
            else
            {
                Debug.LogWarning("Image component not found on the given GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject reference is null.");
        }
    }

    public void UpdateObjectColorToWhite(GameObject obj)
    {
        if (obj != null)
        {
            Image image = obj.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.white;
            }
            else
            {
                Debug.LogWarning("Image component not found on the given GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject reference is null.");
        }
    }
}

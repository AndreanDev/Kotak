using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    private SoundManager sound;

    void Start()
    {
        GameObject soundManagerObject = GameObject.Find("SoundManager");
        if (soundManagerObject != null)
        {
            sound = soundManagerObject.GetComponent<SoundManager>();
        }
        else
        {
            Debug.LogWarning("SoundManager GameObject not found in the scene.");
        }
    }

    public void SetVisibleTrue(GameObject obj)
    {
        if (sound != null) sound.PlayClickingSfx();
        obj.SetActive(true);
    }

    public void SetVisibleFalse(GameObject obj)
    {
        if (sound != null) sound.PlayClickingSfx();
        obj.SetActive(false);
    }
}

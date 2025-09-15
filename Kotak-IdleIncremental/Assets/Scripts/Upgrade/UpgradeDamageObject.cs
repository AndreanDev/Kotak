using UnityEngine;

[System.Serializable]
public class UpgradeDamageObject
{
    public string id;

    public float level;
    public float baseCost;
    public float cost;
    public float baseDPS;
    public float dps; //Damage Per Second
    public float duration;
    public float waitNow;

    public void UpdateStats()
    {
        int hundredSteps = Mathf.FloorToInt(level / 100f);
        cost = baseCost * (level + 1) * (1f + 0.5f * hundredSteps);

        dps = baseDPS * level;
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetFloat(id + "_levelDamage", level);

        PlayerPrefs.Save();
    }

    public void LoadLevel()
    {
        level = PlayerPrefs.GetFloat(id + "_levelDamage", 0f);
        UpdateStats();
    }

    public void ResetLevel()
    {
        level = 0;
        UpdateStats();
        SaveLevel();
    }
}

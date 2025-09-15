using UnityEngine;

[System.Serializable]
public class UpgradeCoinObject
{
    public string id;

    public float level;
    public float baseCost;
    public float cost;
    public float baseCPS;
    public float cps; //Coin Per Second
    public float duration;
    public float waitNow;

    public void UpdateStats()
    {
        int hundredSteps = Mathf.FloorToInt(level / 100f);
        cost = baseCost * (level + 1) * (1f + 0.5f * hundredSteps);

        cps = baseCPS * level;
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetFloat(id + "_levelCoin", level);

        PlayerPrefs.Save();
    }

    public void LoadLevel()
    {
        level = PlayerPrefs.GetFloat(id + "_levelCoin", 0f);
        UpdateStats();
    }

    public void ResetLevel()
    {
        level = 0;
        UpdateStats();
        SaveLevel();
    }
}

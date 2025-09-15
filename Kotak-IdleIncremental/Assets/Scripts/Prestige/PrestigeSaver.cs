using UnityEngine;

public class PrestigeSaver : MonoBehaviour
{
    private Prestige prestige;

    void Start()
    {
        prestige = GetComponent<Prestige>();
    }

    public void SavePrestige()
    {
        PlayerPrefs.SetFloat("PrestigePoints", prestige.prestigePoint);

        PlayerPrefs.SetInt("CoinBoosterLevel", prestige.coinBoosterArtifactLevel);
        PlayerPrefs.SetInt("DamageBoosterLevel", prestige.damageBoosterArtifactLevel);
        PlayerPrefs.SetInt("PrestigeBoosterLevel", prestige.prestigeBoosterArtifactLevel);
        PlayerPrefs.SetInt("StageSkipperLevel", prestige.monsterSkipperArtifactLevel);
        PlayerPrefs.SetInt("GeneratorAcceleratorLevel", prestige.generatorAcceleratorArtifactLevel);

        PlayerPrefs.Save(); // make sure it’s written to disk
        Debug.Log("Prestige saved.");
    }

    public void LoadPrestige()
    {
        prestige.prestigePoint = PlayerPrefs.GetFloat("PrestigePoints", 0f);

        prestige.coinBoosterArtifactLevel = PlayerPrefs.GetInt("CoinBoosterLevel", 0);
        prestige.damageBoosterArtifactLevel = PlayerPrefs.GetInt("DamageBoosterLevel", 0);
        prestige.prestigeBoosterArtifactLevel = PlayerPrefs.GetInt("PrestigeBoosterLevel", 0);
        prestige.monsterSkipperArtifactLevel = PlayerPrefs.GetInt("StageSkipperLevel", 0);
        prestige.generatorAcceleratorArtifactLevel = PlayerPrefs.GetInt("GeneratorAcceleratorLevel", 0);

        Debug.Log("Prestige loaded.");
    }
}

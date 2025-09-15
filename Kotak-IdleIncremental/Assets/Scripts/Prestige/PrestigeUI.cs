using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PrestigeUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI prestigePointText;
    public TextMeshProUGUI prestigeGainText;

    public GameObject prestigeDisableButton;

    public TextMeshProUGUI coinBoosterLevelText;
    public TextMeshProUGUI coinBoosterPriceText;
    public GameObject coinBoosterDisableButton;

    public TextMeshProUGUI damageBoosterLevelText;
    public TextMeshProUGUI damageBoosterPriceText;
    public GameObject damageBoosterDisableButton;

    public TextMeshProUGUI prestigeBoosterLevelText;
    public TextMeshProUGUI prestigeBoosterPriceText;
    public GameObject prestigeBoosterDisableButton;

    public TextMeshProUGUI monsterSkipperLevelText;
    public TextMeshProUGUI monsterSkipperPriceText;
    public GameObject monsterSkipperDisableButton;

    public TextMeshProUGUI generatorAcceleratorLevelText;
    public TextMeshProUGUI generatorAcceleratorPriceText;
    public GameObject generatorAcceleratorDisableButton;

    private Prestige prestige;

    public FormatNumber format;

    public void CallStart()
    {
        prestige = GetComponent<Prestige>();

        SetAllUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAllUI()
    {
        PrestigePointUI();
        DisablePrestigeButton();
        SetCoinBoosterUI();
        SetDamageBoosterUI();
        SetPrestigeBoosterUI();
        SetMonsterSkipperUI();
        SetGeneratorAcceleratorUI();
    }

    public void PrestigePointUI()
    {
        print("Error");
        prestigePointText.text = "TOTAL PRESTIGE POINT: " + format.FormatWithSuffix(prestige.prestigePoint);
        prestigeGainText.text = "PRESTIGE POINT GAIN: " + format.FormatWithSuffix(prestige.CalculatePrestigeGain());
    }

    public void DisablePrestigeButton()
    {
        if (prestige.stage.currentStage >= 100)
        {
            prestigeDisableButton.SetActive(false);
        }
        else
        {
            prestigeDisableButton.SetActive(true);
        }
    }

    public void SetCoinBoosterUI()
    {
        coinBoosterLevelText.text = "LEVEL: \n" + format.FormatRoundedSuffix(prestige.coinBoosterArtifactLevel);
        coinBoosterPriceText.text = format.FormatWithSuffix(prestige.GetArtifactPrice(0));

        if (prestige.prestigePoint >= prestige.GetArtifactPrice(0))
        {
            coinBoosterDisableButton.SetActive(false);
        }
        else
        {
            coinBoosterDisableButton.SetActive(true);
        }
    }

    public void SetDamageBoosterUI()
    {
        damageBoosterLevelText.text = "LEVEL: \n" + format.FormatRoundedSuffix(prestige.damageBoosterArtifactLevel);
        damageBoosterPriceText.text = format.FormatWithSuffix(prestige.GetArtifactPrice(1));

        if (prestige.prestigePoint >= prestige.GetArtifactPrice(1))
        {
            damageBoosterDisableButton.SetActive(false);
        }
        else
        {
            damageBoosterDisableButton.SetActive(true);
        }
    }

    public void SetPrestigeBoosterUI()
    {
        prestigeBoosterLevelText.text = "LEVEL: \n" + format.FormatRoundedSuffix(prestige.prestigeBoosterArtifactLevel);
        prestigeBoosterPriceText.text = format.FormatWithSuffix(prestige.GetArtifactPrice(2));

        if (prestige.prestigePoint >= prestige.GetArtifactPrice(2))
        {
            prestigeBoosterDisableButton.SetActive(false);
        }
        else
        {
            prestigeBoosterDisableButton.SetActive(true);
        }
    }

    public void SetMonsterSkipperUI()
    {
        monsterSkipperLevelText.text = "LEVEL: \n" + format.FormatRoundedSuffix(prestige.monsterSkipperArtifactLevel);
        monsterSkipperPriceText.text = format.FormatWithSuffix(prestige.GetArtifactPrice(3));

        if (prestige.prestigePoint >= prestige.GetArtifactPrice(3))
        {
            monsterSkipperDisableButton.SetActive(false);
        }
        else
        {
            monsterSkipperDisableButton.SetActive(true);
        }
    }

    public void SetGeneratorAcceleratorUI()
    {
        generatorAcceleratorLevelText.text = "LEVEL: \n" + format.FormatRoundedSuffix(prestige.generatorAcceleratorArtifactLevel);
        generatorAcceleratorPriceText.text = format.FormatWithSuffix(prestige.GetArtifactPrice(4));

        if (prestige.prestigePoint >= prestige.GetArtifactPrice(4))
        {
            generatorAcceleratorDisableButton.SetActive(false);
        }
        else
        {
            generatorAcceleratorDisableButton.SetActive(true);
        }
    }
    

}

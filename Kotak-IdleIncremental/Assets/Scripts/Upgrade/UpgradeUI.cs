using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UpgradeUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Upgrade upgrade;

    public GameObject damageUpgradePanel;
    public GameObject coinUpgradePanel;

    public TextMeshProUGUI totalDpsText;
    public TextMeshProUGUI totalCpsText;

    public TextMeshProUGUI[] coinLevelText;
    public TextMeshProUGUI[] damageLevelText;

    public TextMeshProUGUI[] coinPriceText;
    public TextMeshProUGUI[] damagePriceText;

    public TextMeshProUGUI[] coinCPSText;
    public TextMeshProUGUI[] damageDPSText;

    public GameObject[] CoinDisableButton;
    public GameObject[] DamageDisableButton;

    public Slider[] coinSlider;
    public Slider[] damageSlider;

    public FormatNumber format;

    public void CallStart()
    {
        upgrade = GetComponent<Upgrade>();

        SetAllUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAllUI()
    {
        SetAllUICoin();
        SetAllUIDamage();
    }

    public void SetAllUICoin()
    {   
        SetTotalCPS();
        
        if (!coinUpgradePanel.activeInHierarchy)
            return; // skip updating while panel hidden

        for (int i = 0; i < upgrade.coinObject.Length; i++)
        {
            SetCoinLevelText(i);
            SetCoinPriceText(i);
            SetCoinCPSText(i);
            SetCoinButton(i);
            SetCoinSlider(i);
        }
    }

    public void SetAllUIDamage()
    {
        SetTotalDPS();

        if (!damageUpgradePanel.activeInHierarchy)
            return; // skip updating while panel hidden

        for (int i = 0; i < upgrade.damageObject.Length; i++)
        {
            SetDamageLevelText(i);
            SetDamagePriceText(i);
            SetDamageDPSText(i);
            SetDamageButton(i);
            SetDamageSlider(i);
        }
    }

    public void SetCoinLevelText(int index)
    {
        coinLevelText[index].text = "LEVEL \n" + upgrade.format.FormatWithSuffix(upgrade.coinObject[index].level);
    }

    public void SetDamageLevelText(int index)
    {
        damageLevelText[index].text = "LEVEL \n" + upgrade.format.FormatWithSuffix(upgrade.damageObject[index].level);
    }

    public void SetCoinPriceText(int index)
    {
        coinPriceText[index].text = "PRICE: \n" + upgrade.format.FormatWithSuffix(upgrade.coinObject[index].cost);
    }

    public void SetDamagePriceText(int index)
    {
        damagePriceText[index].text = "PRICE: \n" + upgrade.format.FormatWithSuffix(upgrade.damageObject[index].cost);
    }

    public void SetCoinCPSText(int index)
    {
        coinCPSText[index].text = "TOTAL CPS: " + upgrade.format.FormatWithSuffix(upgrade.coinObject[index].cps);
    }

    public void SetDamageDPSText(int index)
    {
        damageDPSText[index].text = "TOTAL DPS: " + upgrade.format.FormatWithSuffix(upgrade.damageObject[index].dps);
    }

    public void SetCoinButton(int index)
    {
        if (upgrade.player.coin >= upgrade.coinObject[index].cost)
        {
            print("Can afford coin upgrade " + index);
            CoinDisableButton[index].SetActive(false);
        }
        else
        {
            print("Cannot afford coin upgrade " + index + " cost: " + upgrade.coinObject[index].cost + " player coin: " + upgrade.player.coin);
            CoinDisableButton[index].SetActive(true);
        }
    }

    public void SetDamageButton(int index)
    {
        if (upgrade.player.coin >= upgrade.damageObject[index].cost)
        {
            print("Can afford damage upgrade " + index);
            DamageDisableButton[index].SetActive(false);
        }
        else
        {
            DamageDisableButton[index].SetActive(true);
        }
    }

    public void SetCoinSlider(int index)
    {
        if (!coinUpgradePanel.activeInHierarchy)
            return; // skip updating while panel hidden

        if (upgrade.coinObject[index].level >= 1)
        {
            float duration = upgrade.upgradeCoin.GetDurationTime(index);
            coinSlider[index].maxValue = duration;
            coinSlider[index].SetValueWithoutNotify(upgrade.coinObject[index].waitNow);
        }
        else
        {
            coinSlider[index].maxValue = 1;
            coinSlider[index].SetValueWithoutNotify(0);
        }
    }

    public void SetDamageSlider(int index)
    {
        if (upgrade.damageObject[index].level >= 1)
        {
            float duration = upgrade.upgradeDamage.GetDurationTime(index);
            damageSlider[index].maxValue = duration;
            damageSlider[index].SetValueWithoutNotify(upgrade.damageObject[index].waitNow);
        }
        else
        {
            damageSlider[index].maxValue = 1;
            damageSlider[index].SetValueWithoutNotify(0);
        }
    }

    public void SetTotalDPS()
    {
        float totalDps = 0f;

        for (int i = 0; i < upgrade.damageObject.Length; i++)
        {
            totalDps += upgrade.damageObject[i].dps;
        }
        
        totalDpsText.text = "DPS: \n" + upgrade.format.FormatWithSuffix(totalDps);
    }

    public void SetTotalCPS()
    {
        float totalCps = 0f;

        for (int i = 0; i < upgrade.coinObject.Length; i++)
        {
            totalCps += upgrade.coinObject[i].cps;
        }

        totalCpsText.text = "CPS: \n" + upgrade.format.FormatWithSuffix(totalCps);
    }
}

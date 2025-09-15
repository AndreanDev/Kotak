using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider expSlider;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI coinText;

    private Player player;
    public FormatNumber format;

    public void CallStart()
    {
        player = GetComponent<Player>();

        SetAllUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAllUI()
    {
        SetExpUI();
        SetCoinUI();
    }

    public void SetExpUI()
    {
        SetLevelText();
        SetExpSlider();
    }

    public void SetLevelText()
    {
        levelText.text = "LV. " + format.FormatRoundedSuffix(player.level);   
    }

    public void SetExpSlider()
    {
        float expPercent = player.exp / player.expToNextLevel;
        expSlider.value = expPercent;
    }
    
    public void SetCoinUI()
    {
        coinText.text = format.FormatWithSuffix(player.coin);
    }
}

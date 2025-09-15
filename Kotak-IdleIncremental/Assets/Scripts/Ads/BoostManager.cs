using System.Collections;
using UnityEngine;
using TMPro;

public class BoostManager : MonoBehaviour
{
    // public bool noAds; // Can be purchased in store

    // public float speedBonus;
    // public float spawnBonus;
    // public bool autoMoveBonus;

    // private int speedCooldownTimeNow = 0;
    // private int spawnCooldownTimeNow = 0;
    // private int autoMoveCooldownTimeNow = 0;

    // public GameObject movePanel;
    // public GameObject autoMovingText;

    // // This TMP is to show the time remaining for each boost
    // public TextMeshProUGUI speedCooldownTimeText;
    // public TextMeshProUGUI spawnCooldownTimeText;
    // public TextMeshProUGUI autoMoveCooldownTimeText;

    // // This Gameobject will be activated when certain ads is watched
    // public GameObject onAdsSpeed;
    // public GameObject onAdsSpawn;
    // public GameObject onAdsAutoMove;

    // // This Gameobject is for turn on or off auto moving
    // public GameObject turnOnOffPanel;
    // public GameObject turnedOnButton; //Will run turn off
    // public GameObject turnedOffButton;

    // public Player player;

    // void Start()
    // {
    //     speedBonus = 0f;
    //     spawnBonus = 0f;
    //     autoMoveBonus = false;
    // }

    // // ✅ This function updates ALL cooldown texts
    // private void UpdateCooldownTexts()
    // {
    //     speedCooldownTimeText.text = FormatTime(speedCooldownTimeNow);
    //     spawnCooldownTimeText.text = FormatTime(spawnCooldownTimeNow);
    //     autoMoveCooldownTimeText.text = FormatTime(autoMoveCooldownTimeNow);
    // }

    // // ✅ Helper function to format seconds into hh:mm:ss
    // private string FormatTime(int totalSeconds)
    // {
    //     if (totalSeconds <= 0) return "00:00";
    //     int hours = totalSeconds / 3600;
    //     int minutes = (totalSeconds % 3600) / 60;
    //     int seconds = totalSeconds % 60;

    //     if (hours > 0)
    //         return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    //     else
    //         return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    // }

    // public void ActivateSpeed()
    // {
    //     if (noAds)
    //     {
    //         ApplySpeedBonus();
    //     }
    //     else
    //     {
    //         ApplySpeedBonus();
    //     }
    // }

    // public void ActivateSpawn()
    // {
    //     if (noAds)
    //     {
    //         ApplySpawnBonus();
    //     }
    //     else
    //     {
    //         ApplySpawnBonus();
    //     }
    // }

    // public void ActivateAutoMove()
    // {
    //     if (noAds)
    //     {
    //         ApplyAutoMoveBonus();
    //     }
    //     else
    //     {
    //         ApplyAutoMoveBonus();
    //     }
    // }

    // private void ApplySpeedBonus()
    // {
    //     speedBonus = 0.25f;
    //     speedCooldownTimeNow = 3600;

    //     player.SetSpeed();
    //     StartCoroutine(SpeedBonusCooldown());
    // }

    // private void ApplySpawnBonus()
    // {
    //     spawnBonus = 0.25f;
    //     spawnCooldownTimeNow = 3600;
    //     StartCoroutine(SpawnBonusCooldown());
    // }

    // private void ApplyAutoMoveBonus()
    // {
    //     autoMoveBonus = true;
    //     autoMoveCooldownTimeNow = 1800;

    //     autoMovingText.SetActive(true);

    //     turnOnOffPanel.SetActive(true);
    //     turnedOffButton.SetActive(false);
    //     turnedOnButton.SetActive(true);

    //     StartCoroutine(AutoMoveBonusCooldown());
    // }

    // public void ApplyAllBonus()
    // {
    //     ApplyAutoMoveBonus();
    //     ApplySpawnBonus();
    //     ApplySpeedBonus();
    // }

    // private IEnumerator SpeedBonusCooldown()
    // {
    //     onAdsSpeed.SetActive(true);
    //     while (speedCooldownTimeNow > 0)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         speedCooldownTimeNow--;

    //         UpdateCooldownTexts();
    //     }
    //     onAdsSpeed.SetActive(false);
    //     speedBonus = 0f;
    // }

    // private IEnumerator SpawnBonusCooldown()
    // {
    //     onAdsSpawn.SetActive(true);
    //     while (spawnCooldownTimeNow > 0)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         spawnCooldownTimeNow--;

    //         UpdateCooldownTexts();
    //     }

    //     onAdsSpawn.SetActive(false);
    //     spawnBonus = 0f;
    // }

    // private IEnumerator AutoMoveBonusCooldown()
    // {
    //     onAdsAutoMove.SetActive(true);
    //     while (autoMoveCooldownTimeNow > 0)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         autoMoveCooldownTimeNow--;

    //         UpdateCooldownTexts();
    //         Debug.Log("Auto Move Time " + autoMoveCooldownTimeNow + " Left");
    //     }

    //     onAdsAutoMove.SetActive(false);

    //     turnOnOffPanel.SetActive(false);

    //     autoMoveBonus = false;
    //     movePanel.SetActive(true);
    //     autoMovingText.SetActive(false);
    // }

    // public void TurnOnAutoMove()
    // {
    //     autoMoveBonus = true;
    //     turnedOnButton.SetActive(true);
    //     turnedOffButton.SetActive(false);
    // }

    // public void TurnOffAutoMove()
    // {
    //     autoMoveBonus = false;
    //     turnedOffButton.SetActive(true);
    //     turnedOnButton.SetActive(false);
    // }
}

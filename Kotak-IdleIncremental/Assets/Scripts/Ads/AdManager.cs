// using Unity.Services.LevelPlay;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    // private LevelPlayRewardedAd rewardedAd;
    // private bool isAdsEnabled = false;

    // public BoostManager boostManager; // Drag BoostManager in Inspector
    // public BoostTrigger boostTrigger; // Drag BoostTrigger in Inspector
    // public string pendingBoostType;   // To remember which boost the player wants

    // void Start()
    // {
    //     Debug.Log("[LevelPlayRewardedSample] Initializing LevelPlay SDK...");
    //     LevelPlay.OnInitSuccess += OnSdkInitSuccess;
    //     LevelPlay.OnInitFailed += OnSdkInitFailed;

    //     LevelPlay.Init(AdConfig.AppKey);
    // }

    // private void OnSdkInitSuccess(LevelPlayConfiguration config)
    // {
    //     Debug.Log("[LevelPlayRewardedSample] SDK initialized successfully!");
    //     SetupRewardedAd();
    //     isAdsEnabled = true;

    //     LoadRewardedAd(); // <-- ADD THIS
    // }

    // private void OnSdkInitFailed(LevelPlayInitError error)
    // {
    //     Debug.LogError($"[LevelPlayRewardedSample] SDK initialization failed: {error}");
    // }

    // private void SetupRewardedAd()
    // {
    //     rewardedAd = new LevelPlayRewardedAd(AdConfig.RewardedVideoAdUnitId);

    //     // Register events
    //     rewardedAd.OnAdLoaded += OnRewardedAdLoaded;
    //     rewardedAd.OnAdLoadFailed += OnRewardedAdLoadFailed;
    //     rewardedAd.OnAdDisplayed += OnRewardedAdDisplayed;
    //     rewardedAd.OnAdDisplayFailed += OnRewardedAdDisplayFailed;
    //     rewardedAd.OnAdRewarded += OnRewardedAdRewarded;
    //     rewardedAd.OnAdClosed += OnRewardedAdClosed;
    // }

    // public void LoadRewardedAd()
    // {
    //     if (isAdsEnabled)
    //     {
    //         Debug.Log("[LevelPlayRewardedSample] Loading Rewarded Ad...");
    //         rewardedAd.LoadAd();
    //     }
    // }

    // public void ShowRewardedAd()
    // {
    //     if (rewardedAd != null && rewardedAd.IsAdReady())
    //     {
    //         Debug.Log("[LevelPlayRewardedSample] Showing Rewarded Ad...");
    //         rewardedAd.ShowAd();
    //     }
    //     else
    //     {
    //         Debug.Log("[LevelPlayRewardedSample] Rewarded Ad is not ready yet.");
    //         boostTrigger.noAdsAvailablePanel.SetActive(true);
    //     }
    // }

    // #region Rewarded Ad Event Handlers

    // private void OnRewardedAdLoaded(LevelPlayAdInfo adInfo)
    // {
    //     Debug.Log($"[LevelPlayRewardedSample] Rewarded Ad loaded: {adInfo}");
    // }

    // private void OnRewardedAdLoadFailed(LevelPlayAdError error)
    // {
    //     Debug.LogError($"[LevelPlayRewardedSample] Failed to load Rewarded Ad: {error}");
    // }

    // private void OnRewardedAdDisplayed(LevelPlayAdInfo adInfo)
    // {
    //     Debug.Log($"[LevelPlayRewardedSample] Rewarded Ad displayed: {adInfo}");
    // }

    // private void OnRewardedAdDisplayFailed(LevelPlayAdDisplayInfoError error)
    // {
    //     Debug.LogError($"[LevelPlayRewardedSample] Failed to display Rewarded Ad: {error}");
    // }

    // private void OnRewardedAdRewarded(LevelPlayAdInfo adInfo, LevelPlayReward reward)
    // {
    //     Debug.Log($"[LevelPlayRewardedSample] User rewarded! Reward: {reward} | Ad Info: {adInfo}");

    //     // Grant the boost based on pending type
    //     switch (pendingBoostType)
    //     {
    //         case "Speed":
    //             boostManager.ActivateSpeed();
    //             break;
    //         case "Spawn":
    //             boostManager.ActivateSpawn();
    //             break;
    //         case "AutoMove":
    //             boostManager.ActivateAutoMove();
    //             break;
    //     }

    //     pendingBoostType = ""; // reset
    // }

    // private void OnRewardedAdClosed(LevelPlayAdInfo adInfo)
    // {
    //     Debug.Log("[LevelPlayRewardedSample] Rewarded Ad closed.");

    //     LoadRewardedAd(); // <-- ADD THIS
    // }

    // #endregion
}

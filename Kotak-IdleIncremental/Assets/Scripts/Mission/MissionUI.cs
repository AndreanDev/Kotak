using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MissionUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI missionPointText;
    public TextMeshProUGUI missionProgressText;
    public GameObject missionCompleteDisableButton;

    private Mission mission;

    public FormatNumber format;
    public void CallStart()
    {
        mission = GetComponent<Mission>();
        
        SetAllUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAllUI()
    {
        MissionPointUI();
        ProgressUI();
        DisableButton();
    }

    public void MissionPointUI()
    {
        missionPointText.text = "Mission Point: " + mission.missionPoint.ToString();
    }

    public void ProgressUI()
    {
        missionProgressText.text = format.FormatRoundedSuffix(mission.upgrade.totalUpgrade) + " / " + format.FormatRoundedSuffix(mission.missionGoal);
    }   

    public void DisableButton()
    {
        if(mission.upgrade.totalUpgrade >= mission.missionGoal)
        {
            missionCompleteDisableButton.SetActive(false);
        }
        else
        {
            missionCompleteDisableButton.SetActive(true);
        }   
    }
}

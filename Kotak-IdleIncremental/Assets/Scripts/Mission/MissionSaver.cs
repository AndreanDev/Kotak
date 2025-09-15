using UnityEngine;

public class MissionSaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Mission mission;
    void Start()
    {
        mission = GetComponent<Mission>();
    }

    // Update is called once per frame
    public void SaveMission()
    {
        // Save mission data here
        PlayerPrefs.SetInt("MissionPoint", mission.missionPoint);
        PlayerPrefs.SetFloat("MissionGoal", mission.missionGoal);
        
        PlayerPrefs.Save();
    }

    public void LoadMission()
    {
        // Load mission data here
        mission.missionPoint = PlayerPrefs.GetInt("MissionPoint", 0);
        mission.missionGoal = PlayerPrefs.GetFloat("MissionGoal", 25f); //

        //Called set all after load to update UI
        mission.SetAll();
    }
}

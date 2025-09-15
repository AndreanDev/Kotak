using UnityEngine;

public class StageSaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Stage stage;
    public void CallStart()
    {
        stage = GetComponent<Stage>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveStage()
    {
        // Save stage data here
        PlayerPrefs.SetFloat("CurrentStage", stage.currentStage);
        PlayerPrefs.SetInt("MonsterDefeated", stage.monsterDefeated);

        Debug.Log("Stage saved.");
    }
    
    public void LoadStage()
    {
        // Load stage data here
        stage.currentStage = PlayerPrefs.GetFloat("CurrentStage", 1f);
        stage.monsterDefeated = PlayerPrefs.GetInt("MonsterDefeated", 0);

        Debug.Log("Stage loaded.");

        //Called set all after load to update UI
        stage.SetAll();
    }
}

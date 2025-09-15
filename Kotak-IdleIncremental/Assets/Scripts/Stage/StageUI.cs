using UnityEngine;
using TMPro;
public class StageUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI progressText;

    private Stage stage;

    public FormatNumber format;
    public void CallStart()
    {
        stage = GetComponent<Stage>();

        SetAllUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAllUI()
    {
        SetStageText();
        SetProgressText();
    }

    public void SetStageText()
    {
        stageText.text = "STAGE " + stage.currentStage.ToString();
    }
    
    public void SetProgressText()
    {
        progressText.text = format.FormatRoundedSuffix(stage.monsterDefeated) + " / " + format.FormatRoundedSuffix(stage.monsterPerStage);
    }
}

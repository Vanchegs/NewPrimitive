using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text primScoreText;

    private ScoreModel scoreModel;
    
    public void SetModel(ScoreModel scoreModel)
    {
        this.scoreModel = scoreModel;
    }

    public void PrimScoreView()
    {
        primScoreText.text = "" + scoreModel.PrimScore;
    }
}

using UnityEngine;
using Vanchegs;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;

    private ScoreModel scoreModel;

    private void Start()
    {
        scoreModel = new ScoreModel();
        scoreView.SetModel(scoreModel);
        scoreView.PrimScoreView();
    }

    public void Click()
    {
        scoreModel.IncrementPrimScore();
        scoreView.PrimScoreView();
        EventPack.OnClickScreen?.Invoke();
        EventPack.OnSwitchToNextLevel?.Invoke();
    }
}

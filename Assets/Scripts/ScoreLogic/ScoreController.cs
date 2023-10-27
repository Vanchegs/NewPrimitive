using UnityEngine;
using Vanchegs;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;

    private ScoreModel scoreModel;

    private void Start()
    {
        scoreView.SetModel(scoreModel);
    }

    public void Click()
    {
        scoreModel.IncrementPrimScore();
        scoreView.PrimScoreView();
        EventPack.OnClickScreen?.Invoke();
        EventPack.OnSwitchToNextLevel?.Invoke();
    }
}

using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.EventSystem;
using Vanchegs.Interanl.Scripts.PrimitiveLogic.Factorys;
using Vanchegs.Interanl.Scripts.ScoreLogic.Score;
using Vanchegs.Interanl.Scripts.TimerLogic;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField] private CurtainView curtain;
        [SerializeField] private PrimitiveFactory primitiveFactory;
        [SerializeField] private GameObject button;
        [SerializeField] private Timer timer;
        
        private ScoreController scoreController;
        private LevelController levelController;
    
        private void Start()
        {
            scoreController = GetComponent<ScoreController>();
            levelController = GetComponent<LevelController>();
        }

        private void UpPrimLevel()
        {
            curtain.ShowCurtain(true, null);
            button.SetActive(false);
            scoreController.UpLevelPrimScore();
            levelController.UpPrimLevelNumber();
            primitiveFactory.OffPrimitives();
            curtain.HideCurtain(1, null);
            StartCoroutine(timer.RestartTimer());
            button.SetActive(true);
        }

        private void ResetPrimLevel()
        {
            curtain.ShowCurtain(true, null);
            button.SetActive(false);
            primitiveFactory.OffPrimitives();
            levelController.ResetPrimLevelNumber();
            scoreController.ReturnPrimScore();
            curtain.HideCurtain(1,null);
            StartCoroutine(timer.RestartTimer());
            button.SetActive(true);
        }

        private void OnEnable()
        {
            EventPack.OnSwitchToNextLevel += UpPrimLevel;
            EventPack.OnResetOnFirstLevel += ResetPrimLevel;
        }

        private void OnDisable()
        {
            EventPack.OnSwitchToNextLevel -= UpPrimLevel;
            EventPack.OnResetOnFirstLevel -= ResetPrimLevel;
        }
    }
}


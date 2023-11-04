using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.EventSystem;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.TimerLogic;
using Vanchegs.Interanl.Scripts.ScoreLogic.Score;
using Vanchegs.Interanl.Scripts.PrimitiveLogic.Factorys;
using Zenject;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    [DisallowMultipleComponent]
    public sealed class LevelSwitcher : MonoBehaviour
    {
        [Inject] private ICurtainService curtain;
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

        private void UpPrimLevel()
        {
            curtain.ShowCurtain(true, LevelUpAction);

            void LevelUpAction()
            {
                button.SetActive(false);
                scoreController.UpLevelPrimScore();
                levelController.UpPrimLevelNumber();
                primitiveFactory.OffPrimitives();
                curtain.HideCurtain(1, null);
                StartCoroutine(timer.RestartTimer());
                button.SetActive(true);
            }
        }

        private void ResetPrimLevel()
        {
            curtain.ShowCurtain(true, ResetLeveAction);

            void ResetLeveAction()
            {
                button.SetActive(false);
                primitiveFactory.OffPrimitives();
                levelController.ResetPrimLevelNumber();
                scoreController.ReturnPrimScore();
                curtain.HideCurtain(1, null);
                StartCoroutine(timer.RestartTimer());
                button.SetActive(true);
            }
        }
    }
}
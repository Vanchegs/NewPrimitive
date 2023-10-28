using System;
using UnityEngine;

namespace ScoreLogic
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelView levelView;

        private LevelModel levelModel;

        private void Start()
        {
            levelModel = new LevelModel();
            levelView.SetLevelModel(levelModel);
            levelView.PrimLevelView();
        }

        public void UpPrimLevelNumber()
        {
            levelModel.IncrementPrimLevel();
            levelView.PrimLevelView();
        }
    }
}

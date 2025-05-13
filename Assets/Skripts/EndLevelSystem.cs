using Skripts.Configs.LevelsConfigs;
using Skripts.Global.SaveSystem;
using Skripts.SceneManagment;

namespace Skripts
{


    public class EndLevelSystem
    {
        
        private readonly EndLevelWindow _endLevelWindow;
        private readonly SaveSystem _saveSystem;
        private readonly GameEnterParams _gameEnterParams;
        private readonly LevelsConfig _levelsConfig;

        public EndLevelSystem(EndLevelWindow endLevelWindow,
            SaveSystem saveSystem,
            GameEnterParams gameEnterParams,
            LevelsConfig levelsConfig)
        {
            _levelsConfig = levelsConfig;
            _gameEnterParams = gameEnterParams;
            _saveSystem = saveSystem;
            _endLevelWindow = endLevelWindow;   
        }

        
        

        public void LevelPassed(bool isPassed)
        {
            
            bool isLast = _gameEnterParams.Level == _levelsConfig.GetMaxLevelOnLocation(_gameEnterParams.Location);

            if (isPassed)
            {
                TrySaveProgress();
                SaveWallet();


                _endLevelWindow.ShowWinWindow(isLast,SaveWallet());

            }
            else
            {
                _endLevelWindow.ShowLooseWindow();
            }
        }

        private void TrySaveProgress()
        {
            var progress = (Progress)_saveSystem.GetData(SavableObjectType.Progress);
            if (_gameEnterParams.Location !=
                progress.CurrentLocation || _gameEnterParams.Level != progress.CurrentLevel) return;

            var maxLocationAndLevel = _levelsConfig.GetMaxLocationAndLevel();
            if (progress.CurrentLocation > maxLocationAndLevel.x ||
                (progress.CurrentLocation == maxLocationAndLevel.x &&
                 progress.CurrentLevel >= maxLocationAndLevel.y)) return;
            var maxLevel = _levelsConfig.GetMaxLevelOnLocation(progress.CurrentLocation);
            if (progress.CurrentLevel + 1 > maxLevel)
            {
                progress.CurrentLevel = 1;
                progress.CurrentLocation++;
            }

            else
            {
                progress.CurrentLevel++;
            }

            _saveSystem.SaveData(SavableObjectType.Progress);

        }

        private int SaveWallet()
        {
            var wallet = (Wallet)_saveSystem.GetData(SavableObjectType.Wallet);
            var progress = (Progress)_saveSystem.GetData(SavableObjectType.Progress);
            wallet.Coins += _levelsConfig.GetWalletOnLevel(progress.CurrentLevel);

            return _levelsConfig.GetWalletOnLevel(progress.CurrentLevel);
        }
        
    }
}
using System;
using Skripts.Animations;
using Skripts.Configs.EnemyConfigs;
using Skripts.Configs.LevelsConfigs;
using Skripts.Configs.SkillsConfig;
using Skripts.Global.SaveSystem;
using Skripts.SceneManagment;
using Skripts.Skills;
using TMPro;
using UnityEngine;
using Progress = Skripts.Global.SaveSystem.Progress;

namespace Skripts
{
    public class GameManager : EntryPoint
    {
        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private ClickButtonManager _clickBtnManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private HealthBar _healthBar;

        private SaveSystem _saveSystem;
        private SceneLoader _sceneLoader;
       

        [SerializeField] private SkillSystem _skillSystem;
        [SerializeField] private Transform _damageAnimationContainer;
        [SerializeField] private GameObject _damageAnimationPrefab;
        [SerializeField] private SkillsConfig _skillsConfig;
        [SerializeField] private KNBConfig _knbConfig;
        [SerializeField] private EndLevelWindow _endLevelWindow;
        [SerializeField] private FearBar _fearBar;
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private EndLevelSystem _endLevelSystem;
        
        
        [SerializeField] AnimationSpawner _animationSpawner;
        private GameEnterParams _gameEnterParams;
        
        // private Timer _timer;


        private const string COMMON_OBJECT_TAG = "CommonObject";

       

        public override void Run(SceneEnterParams enterParams)
        {
            
            var commonObject = GameObject.FindWithTag(COMMON_OBJECT_TAG).GetComponent<CommmonObject>();
            _saveSystem = commonObject.SaveSystem;
            _sceneLoader = commonObject.SceneLoader;


            if (enterParams is not GameEnterParams gameEnterParams)
            {
                Debug.LogError("error");
                return;
            }

            _gameEnterParams = gameEnterParams;



            _animationSpawner.Initialize(_damageAnimationContainer,_damageAnimationPrefab,_wayPoints);
            _enemyManager.Initialize(_healthBar, _fearBar);
            _endLevelWindow.Initialize();
            
            var openedSkills = (OpenSkills)_saveSystem.GetData(SavableObjectType.OpenSkills);
            _skillSystem = new(openedSkills, _skillsConfig, _enemyManager,_knbConfig,_animationSpawner);
            _endLevelSystem = new(_endLevelWindow, _saveSystem, _gameEnterParams, _levelsConfig);

           
            _endLevelWindow.OnRestartClicked += RestartLevel;
            _enemyManager.OnLevelPassed += _endLevelSystem.LevelPassed;
            _endLevelWindow.OnNextLevel += NextLevel;
            _endLevelWindow.ToMap += ToMap;
            
            _clickBtnManager.Initialize(_skillSystem);
            StartLevel();
           
        }

        private void RestartLevel()
        {
            
            _sceneLoader.LoadGameplayscene(_gameEnterParams);
            
        }

        private void NextLevel()
        {

            var nextGameEnterParams = new GameEnterParams(_gameEnterParams.Location, _gameEnterParams.Level + 1);
            
            _sceneLoader.LoadGameplayscene(nextGameEnterParams);


        }

        private void ToMap()
        {
           
            _sceneLoader.LoadMetaScene();
        }

        

        

        private void StartLevel()
        {
            var maxLocationAndLevel = _levelsConfig.GetMaxLocationAndLevel();
            var location = _gameEnterParams.Location;
            var level = _gameEnterParams.Level;
            if (location > maxLocationAndLevel.x || (location == maxLocationAndLevel.x && level > maxLocationAndLevel.y))
            {
                location = maxLocationAndLevel.x;
                level = maxLocationAndLevel.y;
            }
           

            var levelData = _levelsConfig.GetLevel(_gameEnterParams.Location, _gameEnterParams.Level);


            _enemyManager.StartLevel(levelData);

        }
    }





}


using System;
using Skripts.Configs.SkillsConfig;
using Skripts.Global.SaveSystem;
using Skripts.Meta.Locations;
using Skripts.Meta.RewarderAD;
using Skripts.Meta.Shop;
using Skripts.SceneManagment;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Progress = Skripts.Global.SaveSystem.Progress;

namespace Skripts.Meta
{
    public class MetaEntryPoint:EntryPoint
    {
        [SerializeField] private LocationManager _locationManager;
        [SerializeField] private ShopWindow _shopWindow;
        [SerializeField] private SkillsConfig _skillsConfig;
        [SerializeField] private RewardedAdManager _rewardedAdManager;
        
        private SaveSystem _saveSystem;
        private SceneLoader _sceneLoader;
        private const string SCENE_LOADER_TAG = "CommonObject";
     
        
        public override void Run(SceneEnterParams enterParams)
        {
            var commonObject = GameObject.FindWithTag(SCENE_LOADER_TAG).GetComponent<CommmonObject>();
            _saveSystem = commonObject.SaveSystem;
            _sceneLoader = commonObject.SceneLoader;
                
            
            
            var progress =  (Progress) _saveSystem.GetData(SavableObjectType.Progress);
            _locationManager.Initialize(progress,StartLevel);
            _rewardedAdManager.Initialize(_saveSystem, callback => _shopWindow.ShowRewarderButton(callback),() => _shopWindow.HideRewardButton()) ;
            
            _shopWindow.Initialize(_skillsConfig,_saveSystem);
            
        }

        private void StartLevel(int location,int level)
        {
           
               
                _sceneLoader.LoadGameplayscene(new GameEnterParams(location, level));
            
        }
    }
}
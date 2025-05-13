using System.Collections.Generic;
using Skripts.Global.SaveSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

namespace Skripts.Meta.Locations
{
    public class LocationManager: MonoBehaviour
    {
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private List<Location> _locations;
        [SerializeField] private GameObject _shopWindow;
        private int _currentLocation;
        public void Initialize(Progress progress,UnityAction<int, int> startLevelCallback)
        {
            _currentLocation = progress.CurrentLocation;
            
            FirstInitLocation(progress, startLevelCallback);
            InitializeMoveLocationButtons();
        }

        private void InitializeMoveLocationButtons()
        {
            _prevButton.onClick.AddListener(ShowPreviousLocation);
            _nextButton.onClick.AddListener(ShowNextLocation);
            _shopButton.onClick.AddListener(ShowShopWindow);
            
            if (_currentLocation == _locations.Count)
            {
                _nextButton.gameObject.SetActive(false);
            }

            if (_currentLocation == 1)
            {
                _prevButton.gameObject.SetActive(false);
            }
        }

        private void ShowNextLocation()
        {
           
            
                _locations[_currentLocation - 1].gameObject.SetActive(false);
                _currentLocation++;
                _locations[_currentLocation - 1].gameObject.SetActive(true);

            if (_currentLocation == _locations.Count)
         {
             _nextButton.gameObject.SetActive(false);
         }

         if (_currentLocation == 2)
         {
             _prevButton.gameObject.SetActive(true);
         }
         

        }
        

        private void ShowShopWindow()
        {
            _shopWindow.SetActive(!_shopWindow.activeSelf);
            YG2.InterstitialAdvShow();
        }

        private void ShowPreviousLocation()
        {
            
                _locations[_currentLocation - 1].gameObject.SetActive(false);
                _currentLocation--;
                _locations[_currentLocation - 1].gameObject.SetActive(true);
            
           
            if (_currentLocation == _locations.Count-1)
            {
                _nextButton.gameObject.SetActive(true);
            }

            if (_currentLocation == 1)
            {
                _prevButton.gameObject.SetActive(false);
            }
         

        }
        

        private void FirstInitLocation(Progress progress, UnityAction<int,int> startLevelCallback)
        {
            for (var i = 0; i < _locations.Count; i++)
            {
                
                var locationNumber = i + 1;

                Pin.ProgressState isLocationPassed = progress.CurrentLocation > locationNumber ? Pin.ProgressState.Passed :
                    progress.CurrentLocation == locationNumber ? Pin.ProgressState.Current : Pin.ProgressState.Closed;
                var currentLevel = progress.CurrentLevel;
                _locations[i].Initialize(isLocationPassed,currentLevel,level => startLevelCallback?.Invoke(locationNumber,level));
                _locations[i].SetActive(progress.CurrentLocation == locationNumber);
                
                
            }
        }
    }
}
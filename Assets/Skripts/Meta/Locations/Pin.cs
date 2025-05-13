using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace Skripts.Meta.Locations
{
    public class Pin:MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Color _currentLevel;
        [SerializeField] private Color _passedtLevel;
        [SerializeField] private Color _closedLevel;
        private Sequence _currentLevelSequence;
        
        public void Initialize(int levelNumber,ProgressState progressState,UnityAction clickCallback)
        {
            SetupCurrentLevelSequence();
            _text.text = $"Ур. {levelNumber}";

            _image.color = progressState switch
            {
                ProgressState.Current => _currentLevel,
                ProgressState.Closed => _closedLevel,
                ProgressState.Passed => _passedtLevel
                
            };
            if (progressState == ProgressState.Current)
            {
                transform.DORotate(new(0, 0, 25f), 0.1f).OnComplete(() => _currentLevelSequence.Play());

            }

            _button.onClick.AddListener(() =>clickCallback?.Invoke());
            
        
        }

        private void SetupCurrentLevelSequence()
        {
            if (_currentLevelSequence != null) return;
            
                
                _currentLevelSequence = DOTween.Sequence()
                    .Append(transform.DORotate(new(0, 0, -25f), 0.2f))
                    .Append(transform.DORotate(new(0,0,25f),0.2f))
                    .SetLoops(-1)
                    .Pause();
            
        }
        
        public enum ProgressState
        {
            Passed = 1,
            Closed = 2,
            Current = 3
             
        }
        

        private void OnDestroy()
        {
            _currentLevelSequence.Kill();
            
        }
    }
}
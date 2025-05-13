using System;
using DG.Tweening;
using Skripts.Global.SaveSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using YG;
using Button = UnityEngine.UI.Button;

namespace Skripts.Meta.RewarderAD
{
    
    public class RewardedAdManager : MonoBehaviour
    {
        private UnityAction<UnityAction> _showRewardButton; 
        private UnityAction _hideRewardButton;
        private Wallet _wallet;
        [SerializeField] private ConfirmantionWindow _confirmWindow;
        
        [SerializeField] private SaveSystem _saveSystem;
        private Sequence _sequence;

        public void Initialize(SaveSystem saveSystem,UnityAction<UnityAction> showRewardButton, UnityAction hideRewardButton)
        {
            _saveSystem = saveSystem;
            _hideRewardButton = hideRewardButton;
            _wallet = (Wallet)_saveSystem.GetData(SavableObjectType.Wallet);
            _showRewardButton = showRewardButton;
            showRewardButton.Invoke(OnRewardClicked);
           
        }

        private void OnRewardClicked()
        {
            _confirmWindow.ShowWindowInfo(ShowAdvertisment,"Посмотрите рекламу и получите 50 монет!");
            
        }

        private void ShowAdvertisment()
        {
            YG2.RewardedAdvShow("shopReward",GetReward);
            _hideRewardButton?.Invoke();
           _sequence = DOTween.Sequence().AppendInterval(120f).OnComplete(() => _showRewardButton.Invoke(OnRewardClicked));
 
        }

        private void GetReward()
        {
            _wallet.Coins += 50;
            _saveSystem.SaveData(SavableObjectType.Wallet);
        }

        private void OnDestroy()
        {
            _sequence.Kill(  );
        }
    }
}
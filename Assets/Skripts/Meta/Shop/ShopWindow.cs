using System.Collections.Generic;
using Skripts.Configs.SkillsConfig;
using Skripts.Global.SaveSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Skripts.Meta.Shop
{
    public class ShopWindow : MonoBehaviour
    {
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _backToMap;
        private int _currentBlock = 0;
        [SerializeField] private List<GameObject> _blocks;
        [SerializeField] private List<ShopItem> _items;
        [SerializeField] private TextMeshProUGUI _playerCoinText;
        [SerializeField] private GameObject _shopWindow;
        [SerializeField] private Button _rewarderAdButton;
        private Dictionary<string, ShopItem> _itemsMap;
        private SkillsConfig _skillsConfig;
        private OpenSkills _openSkills;
        private SaveSystem _saveSystem;
        private Wallet _wallet;
        public void Initialize( SkillsConfig skillsConfig,SaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
            _skillsConfig = skillsConfig;
            _openSkills = (OpenSkills) saveSystem.GetData(SavableObjectType.OpenSkills);
            _wallet = (Wallet) saveSystem.GetData(SavableObjectType.Wallet);
            InitializeItemMaps();
            InitializeBlockSwitching();
            _playerCoinText.text = _wallet.Coins.ToString();
          
            ShowShopItems();
        }

        public void ShowRewarderButton(UnityAction callback)
        {
            _rewarderAdButton.onClick.RemoveAllListeners();
            _rewarderAdButton.onClick.AddListener(() => callback?.Invoke());

        }

        public void HideRewardButton()
        {
            _rewarderAdButton.onClick.RemoveAllListeners();
        }
        public void ShowShopItems()
        {
            
            foreach (var skillData in _skillsConfig.Skills)
            {
                var skillWithLevel = _openSkills.GetSkillWithLevel(skillData.Id);
                var skillDataByLevel = skillData.GetSkillDataByLevel(skillWithLevel.Level);
                if(!_itemsMap.ContainsKey(skillData.Id)) continue;
                _itemsMap[skillData.Id].Initialize(skillId => SkillUpgrade(skillId, skillDataByLevel.Cost),
                    skillDataByLevel.Name, skillDataByLevel.Desription,skillDataByLevel.Cost, _wallet.Coins >= skillDataByLevel.Cost,
                    skillData.IsMaxLevel(skillWithLevel.Level));
                     
            }
            _playerCoinText.text = _wallet.Coins.ToString();
            
            
        }

        private void InitializeItemMaps()
        {
            _itemsMap = new();
            foreach (var shopItem in _items)
            {
                _itemsMap[shopItem.SkillId] = shopItem;
            }
        }

        private void SkillUpgrade(string SkillId,int cost)
        {
            var skillWithLevel = _openSkills.GetSkillWithLevel(SkillId);
            skillWithLevel.Level++;
            _wallet.Coins -= cost;
            _saveSystem.SaveData(SavableObjectType.Wallet);
            _saveSystem.SaveData(SavableObjectType.OpenSkills);
            ShowShopItems();
        }

        public void InitializeBlockSwitching()
        {
            
            _previousButton.onClick.AddListener(() => ShowBlock(_currentBlock-1));
            _nextButton.onClick.AddListener(() => ShowBlock(_currentBlock+1));
            _backToMap.onClick.AddListener( () =>_shopWindow.SetActive(!_shopWindow.activeSelf));
            ShowBlock(1);
            
        }

        private void ShowBlock(int Index)
        {
            for (var i = 0; i < _blocks.Count; i++)
            {
                _currentBlock = (Index + _blocks.Count) % _blocks.Count;
                _blocks[i].SetActive(i == _currentBlock);
            }
        }
        
    }
}




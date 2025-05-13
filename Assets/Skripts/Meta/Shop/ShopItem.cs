using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skripts.Meta.Shop
{
    public class ShopItem:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextMeshProUGUI _deskription;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Button _BuyButton;
        // [SerializeField] private 
        [SerializeField] public string SkillId;

        public void Initialize(UnityAction<string> onCLick, string label,string deskription,int cost,bool IsEnough,bool isMaxLevel)
        {
            _BuyButton.onClick.RemoveAllListeners();
            _BuyButton.onClick.AddListener(() => onCLick?.Invoke(SkillId));
            _label.text = label;
            _deskription.text = deskription;
            if (isMaxLevel)
            {

                _BuyButton.interactable = false;
                _cost.text = "МАКС";
                return;
            }

            _cost.text = cost.ToString();
            _cost.color = IsEnough ? Color.green : Color.red;
            _BuyButton.interactable = IsEnough;



        }   







    }
}
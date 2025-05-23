using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Skripts
{
    public class ClickButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;


        public void Initialize(Sprite sprite ,ColorBlock colorBlock)
        {
            _image.sprite = sprite;
            _button.colors = colorBlock;

        }

        public void SubscribeOnClick(UnityAction action)
        {
            _button.onClick.AddListener(action);
        
        }
    
    
        public void UnSubscribeOnClick(UnityAction action)
        {
            _button.onClick.RemoveListener(action);
        }
    }
}
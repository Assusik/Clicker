using UnityEngine;
using UnityEngine.UI;

namespace Skripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

    
    
        public void HideHpBar()
        {
        
        }

        public void ShowHpBar()
        {
            gameObject.SetActive(true);
        }
        public void SetMaxValue(float value)
        {
            _slider.maxValue = value;
            _slider.value = value;
        }

        public void DecreasValue(float value)
        {
            _slider.value -= value;
        }
    
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Skripts
{
    [CreateAssetMenu(menuName = "Config/ClickButtonConfig",fileName = "ClickButtonConfig")]
    public class ClickButtonConfig: ScriptableObject
    {
        public Sprite DefaultSprite;
        public ColorBlock ButtonColors;
        
    }
}
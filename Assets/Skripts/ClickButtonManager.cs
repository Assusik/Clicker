using Skripts.Skills;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts
{
   public class ClickButtonManager : MonoBehaviour
   {
      [SerializeField] private ClickButton _holyButton;
      [SerializeField] private ClickButton _DarkButton;
      [SerializeField] private ClickButton _superNaturalButton;
      [SerializeField] private ClickButtonConfig _darkConfig;
      [SerializeField] private ClickButtonConfig _holyConfig;
      [SerializeField] private ClickButtonConfig _superNaturalConfig;
      

      public void Initialize(SkillSystem skillSystem)
      {
         _holyButton.Initialize(_holyConfig.DefaultSprite,_holyConfig.ButtonColors);
         _DarkButton.Initialize(_darkConfig.DefaultSprite,_darkConfig.ButtonColors);
         _superNaturalButton.Initialize(_superNaturalConfig.DefaultSprite,_superNaturalConfig.ButtonColors);
         
         _holyButton.SubscribeOnClick(() => skillSystem.InvokeTriger(SkillTriger.OnDamageHoly));
         _DarkButton.SubscribeOnClick(() => skillSystem.InvokeTriger(SkillTriger.OnDamageDark));
         _superNaturalButton.SubscribeOnClick(() => skillSystem.InvokeTriger(SkillTriger.OnDamageSuperNatural));
      
      }

     
   
   }
}

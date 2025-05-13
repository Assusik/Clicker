using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Skripts
{
    public class Spell : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private float _castTime;
        private float _fearPerCast;
        private float _coolDown;
        private bool _isInterruptible;  
        public event UnityAction EndCast;
        // public event UnityAction<float> OnAddingFear;
        public bool _alreadyCast;

        public void Initialize(SpellsData spellsData)
        {
            _castTime = spellsData.CastTime;
            _fearPerCast = spellsData.FearPerCast;
            _coolDown = spellsData.CoolDown;
            _isInterruptible = spellsData.IsInterruptible;

        }

        public void Cast()
        {
                                                                                                                                                                                                                                                                                                                                                                                                               
        }   


        // public void AddFear(float fear)
        // {
        //     if (_alreadyCast)
        //     {
        //         OnAddingFear?.Invoke(fear);
        //
        //         //...
        //
        //     }
        //
        //
        // }
    }
}

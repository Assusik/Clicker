using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Skripts.Animations
{
    public class DamageAnimation:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _damageText;
       
        private CanvasGroup _canvasGroup;
        
        
        public void PlayAnimation(Vector3[] pathPoints)
        {
            transform.DOPath(pathPoints, 0.5f)
                .SetEase(Ease.Linear)
                .OnComplete( () => Destroy(gameObject));




            // if (sequence != null)
            // {
            //
            //
            //     // sequence
            //     //     .Append(transform.DOMoveY(-3f, 1f).SetEase(Ease.Linear))
            //     //     .Join(transform.DOScale(2f,1f))
            //     //     .OnComplete(() => Destroy(gameObject));
            // }
        }
        


    }
}
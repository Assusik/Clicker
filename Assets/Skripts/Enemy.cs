using DG.Tweening;
using Skripts.Configs.EnemyConfigs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Color = System.Drawing.Color;
using Sequence = DG.Tweening.Sequence;

namespace Skripts
{
    public class Enemy : MonoBehaviour
    {
    
        [SerializeField] private Image _image;

        private float _health;
        private Sequence _currentSequanceDamage;
        

        public event UnityAction<float> OnDamaged;
        public event UnityAction OnDead;
    
        public void Initialize(Sprite sprite,float health,EnemyColor enemyColor,EnemyType enemyType)
        {
            
            _health = health;
            _image.sprite = sprite;
            if (enemyType == EnemyType.Dark)
            {
                _image.color = enemyColor.EnemyColors[0];
            }

            if (enemyType == EnemyType.Holy)
            {
                _image.color = enemyColor.EnemyColors[1];
                
            }
            if(enemyType == EnemyType.SuperNatural)
            {
                _image.color = enemyColor.EnemyColors[2];
            }
            SetCurrentSequanceDamage();
        }

        private void SetCurrentSequanceDamage()
        {
            _currentSequanceDamage = DOTween.Sequence()
                .AppendCallback( () => transform.localScale = new(1,1,1))
                .Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f))
                .Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f))
                .SetAutoKill(false)
                .Pause();
        }

        public void DoDamage(float damage)
        {
            if (damage >= _health)
            {
                _health = 0;
                OnDamaged?.Invoke(damage);
                OnDead?.Invoke();
                return;

            }

        
        
            _currentSequanceDamage.Restart();

        
      
            _health -= damage;
            OnDamaged?.Invoke(damage);
        }

        public float GetHealth()
        {
            return _health;
        }
    }
}

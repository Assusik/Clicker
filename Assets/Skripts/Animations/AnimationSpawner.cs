using TMPro;
using UnityEngine;

namespace Skripts.Animations
{
    public class AnimationSpawner:MonoBehaviour
    {
        private Transform _damageAnimationContainer;
        private GameObject _damageTextPrefab;
        private Transform[] _wayPoints;


        public void Initialize( Transform damageAnimationContainer, GameObject damageTextPrefab,Transform[] wayPoints)
        {
            _damageAnimationContainer = damageAnimationContainer;
            _damageTextPrefab = damageTextPrefab;
            _wayPoints = wayPoints;

        }

        public void CreateAndPlayAnimationDamage(float damage)
        {

            Vector3[] pathPoints = new Vector3[_wayPoints.Length];
            
            for (var i = 0; i < pathPoints.Length; i++)
            {
                pathPoints[i] = _wayPoints[i].position;
            }   
            
            
            var currentText =Instantiate(_damageTextPrefab, _damageAnimationContainer);
            currentText.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            currentText.GetComponent<DamageAnimation>().PlayAnimation(pathPoints);
            

        }

    }
}
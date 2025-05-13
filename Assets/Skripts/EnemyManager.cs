using Skripts.Animations;
using Skripts.Configs.EnemyConfigs;
using Skripts.Configs.LevelsConfigs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform _enemyContainer;
        [SerializeField] private EnemysConfig _enemysConfig;
        [SerializeField] private TextMeshProUGUI _lvltext;
        [SerializeField] private TextMeshProUGUI _enemyText;
        [SerializeField] private EnemyColor _enemyColor;

        // private Timer _timer;
        private FearBar _fearBar;

        private EnemyData _currentEnemyData;
        private Enemy _currentEnemy;
        private HealthBar _healthBar;
        private LevelData _levelData;
        private  int _currentEnemyIndex;
        private EnemyType _currentEnemyDamageType;
        

        public event UnityAction<bool> OnLevelPassed; 
        public void Initialize(HealthBar healthBar, FearBar fearBar)
        {
            // _timer = timer;
            _fearBar = fearBar;
            _healthBar = healthBar;
        
        }

        public void StartLevel(LevelData levelData)
        {
            _levelData = levelData;
            _currentEnemyIndex = - 1;
            if (_currentEnemy == null) {
                _currentEnemy = Instantiate(_enemysConfig.EnemyPrefab, _enemyContainer);
                _currentEnemy.OnDead += SpawnEnemy;
                _currentEnemy.OnDamaged += _healthBar.DecreasValue;
            }
            SpawnEnemy();
            
        }
        public void SpawnEnemy()
        {
            _enemyText.text = $"{_currentEnemyIndex + 2}/{_levelData.Enemies.Count}";
            _lvltext.text = $"lvl {_levelData.LevelNumber}";
            _currentEnemyIndex++;
            if (_currentEnemyIndex >= _levelData.Enemies.Count)
            {
                OnLevelPassed?.Invoke(true);
                _fearBar.Stop();
                // _timer.Stop();    
                return;
            }
            var currentEnemy = _levelData.Enemies[_currentEnemyIndex];
            _currentEnemyDamageType = currentEnemy.EnemyType;
            
            if (currentEnemy.IsBoss)
            {
                // _timer.Initialize(currentEnemy.BossTime);
                _fearBar.Initialize(currentEnemy.BossTime);
                // _timer.OnTimerEnd += () => OnLevelPassed?.Invoke(false);
                _fearBar.OnMaxFear += () => OnLevelPassed?.Invoke(false);

            }
            
            _currentEnemyData = _enemysConfig.GetEnemy(currentEnemy.Id);
            InitHpBar(currentEnemy.Hp);

            
                _currentEnemy.Initialize(_currentEnemyData.Sprite,currentEnemy.Hp,_enemyColor,currentEnemy.EnemyType);
        
        
        }

        private void InitHpBar(float health)
        {
            _healthBar.SetMaxValue(health);
            _healthBar.ShowHpBar();
        
        }

    

        public void DamageCurrentEnemy(float damage, AnimationSpawner animationSpawner)
        {
            
            _currentEnemy.DoDamage(damage);
            animationSpawner.CreateAndPlayAnimationDamage(damage);

        }

        public void SubscribeOnCurrentEnemyDamage(UnityAction<float> callback)
        {
            if (_currentEnemy != null)
            {
                _currentEnemy.OnDamaged += callback;
            }
        }

        public EnemyType GetCurrentEnemyDamageType()
        {
            return _currentEnemyDamageType;
        }
    
    }
}

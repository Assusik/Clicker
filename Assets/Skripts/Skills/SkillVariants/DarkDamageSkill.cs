using Skripts.Animations;
using Skripts.Configs.EnemyConfigs;
using Skripts.Configs.SkillsConfig.Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace Skripts.Skills.SkillVariants
{
    [Preserve]
    public class DarkDamageSkill:Skill
    {
        private EnemyManager _enemyManager;
        private SkillDataByLevel _skillDataByLevel;
        private KNBConfig _knbConfig;
        private AnimationSpawner _animationSpawner;
        public override void Initialize(SkillScope scope, SkillDataByLevel skillDataByLevel,AnimationSpawner animationSpawner)
        {
            _animationSpawner = animationSpawner;
            _skillDataByLevel = skillDataByLevel;
            _enemyManager = scope.EnemyManager;
            _knbConfig = scope._KnbConfig;
        }

        public override void SkillProcess()
        {
            var toDamageType = _enemyManager.GetCurrentEnemyDamageType();
            
         
            var calculatedDamage = _knbConfig.CalculateDamage(EnemyType.Dark, toDamageType, _skillDataByLevel.Value);
            
            _enemyManager.DamageCurrentEnemy(calculatedDamage,_animationSpawner);
        }
    }
}
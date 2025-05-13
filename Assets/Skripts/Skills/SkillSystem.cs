using System;
using System.Collections.Generic;
using Skripts.Animations;
using Skripts.Configs.EnemyConfigs;
using Skripts.Configs.SkillsConfig;
using Skripts.Global.SaveSystem;
using Skripts.Global.SaveSystem;
using UnityEngine;

namespace Skripts.Skills
{
    
    public class SkillSystem
    {
        private SkillScope _scope;
        private SkillsConfig _skillsConfig;
        private AnimationSpawner _animationSpawner;

        private Dictionary<SkillTriger, List<Skill>> _skillsByTrigger;
        public SkillSystem (OpenSkills openSkills,SkillsConfig skillsConfig,EnemyManager enemyManager,KNBConfig knbConfig,AnimationSpawner animationSpawner)
        {
            _animationSpawner = animationSpawner;
            _skillsByTrigger = new();
            _skillsConfig = skillsConfig;
            _scope = new ()
            {
                EnemyManager = enemyManager,
                _KnbConfig = knbConfig,
            };
            foreach (var skill in openSkills.Skills)
            {
                RegisterSkill(skill);
            }
            
            
            
        }

        private void RegisterSkill(SkillWithLevel skill)
        {
            var skillData = _skillsConfig.GetSkillData(skill.id, skill.Level);
            
            var skillType = Type.GetType($"Skripts.Skills.SkillVariants.{skill.id}");
            
            if (skillType == null)
            {
                throw new Exception($"{skill.id} not found");
            }
            
            
            if (Activator.CreateInstance(skillType) is not Skill skillInstance)
            {
                throw new($"can not create {skill.id}");
            }
            
            skillInstance.Initialize(_scope,skillData,_animationSpawner);
            
            if (!_skillsByTrigger.ContainsKey(skillData.Triger))
            {
                _skillsByTrigger[skillData.Triger] = new();
            }
            _skillsByTrigger[skillData.Triger].Add(skillInstance);
            skillInstance.OnSkillRegistered();
            
        }

        public void InvokeTriger(SkillTriger triger)
        {
            if (!_skillsByTrigger.ContainsKey(triger))
            { 
                
                return;
               
            }

            var skillToActivate = _skillsByTrigger[triger];
            foreach (var skill in skillToActivate)
            {
               
                skill.SkillProcess();
               
            }
        }
    }
}
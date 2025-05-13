using System.Collections.Generic;
using Skripts.Configs.SkillsConfig.Data;
using UnityEngine;

namespace Skripts.Configs.SkillsConfig
{
    [CreateAssetMenu(menuName = "Config/SkillsConfig", fileName = "SkillsConfig")]
    public class SkillsConfig : ScriptableObject
    {
        public List<SkillData> Skills;

        private Dictionary<string, Dictionary<int, SkillDataByLevel>> _skillDataByLevelMap;
        
        public SkillDataByLevel GetSkillData(string skillId, int level)
        {
            if (_skillDataByLevelMap == null || _skillDataByLevelMap.Count == 0)
            {
                FillSkillDataMap();
            }

            return _skillDataByLevelMap[skillId][level];
        }

        private void FillSkillDataMap()
        {
            _skillDataByLevelMap = new();
            foreach (var skilldata in Skills)
            {
                if (!_skillDataByLevelMap.ContainsKey(skilldata.Id))
                {
                    _skillDataByLevelMap[skilldata.Id] = new();
                }

                foreach (var skillDataByLevel in skilldata.SkillLevels)
                {
                        _skillDataByLevelMap[skilldata.Id][skillDataByLevel.Level] = skillDataByLevel;
                }
            }
        }
        }
        
        
    }

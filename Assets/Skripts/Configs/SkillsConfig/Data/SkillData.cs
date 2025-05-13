using System;
using System.Collections.Generic;
using System.Linq;

namespace Skripts.Configs.SkillsConfig.Data
{
    [Serializable]
    public struct SkillData
    {
        public string Id;
        public List<SkillDataByLevel> SkillLevels;

        public SkillDataByLevel GetSkillDataByLevel(int level)
        {
            return SkillLevels.Find(x => x.Level == level);
        }

        public bool IsMaxLevel(int level)
        {
            return SkillLevels.Max(x => x.Level) == level;
        }
    }
}
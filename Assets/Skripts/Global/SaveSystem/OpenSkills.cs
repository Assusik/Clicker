using System.Collections.Generic;

namespace Skripts.Global.SaveSystem
{
    public class OpenSkills : ISavable
    {
        public List<SkillWithLevel> Skills = new();

        public SkillWithLevel GetSkillWithLevel(string skillId)
        {
            foreach (var skillWithLevel in Skills)
            {
                if (skillWithLevel.id == skillId)
                {
                    return skillWithLevel;
                }
            }
            
            var newSkill = new SkillWithLevel()
            {
                id = skillId,
                Level = 0,
            };
            Skills.Add(newSkill);
            return newSkill;
        }
        
        
        
        
    }
}
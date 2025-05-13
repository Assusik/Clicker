using Skripts.Animations;
using Skripts.Configs.SkillsConfig.Data;

namespace Skripts.Skills
{
    public abstract class Skill
    {
        public virtual void Initialize(SkillScope scope,SkillDataByLevel skillDataByLevel,AnimationSpawner animationSpawner ){}
        
        public virtual void OnSkillRegistered(){}
        
        public virtual void SkillProcess(){}
        
        
    }
}
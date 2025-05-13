using System;
using Skripts.Skills;

namespace Skripts.Configs.SkillsConfig.Data
{
    [Serializable]
    public struct SkillDataByLevel
    {
        public int Level;
        public float Value;
        public SkillTriger Triger;
        public float TrigerValue;
        public int Cost;
        public string Desription;
        public string Name;
    }
} 
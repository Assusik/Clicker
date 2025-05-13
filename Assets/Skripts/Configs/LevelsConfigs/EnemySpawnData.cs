using System;
using Skripts.Configs.EnemyConfigs;

namespace Skripts.Configs.LevelsConfigs {
    [Serializable]
    public struct EnemySpawnData {
        public string Id;
        public float Hp;
        public bool IsBoss;
        public float BossTime;
        public EnemyType EnemyType;
    }
    
}
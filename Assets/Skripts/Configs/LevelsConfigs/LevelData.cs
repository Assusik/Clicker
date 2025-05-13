using System;
using System.Collections.Generic;

namespace Skripts.Configs.LevelsConfigs {
    [Serializable]
    public struct LevelData {
        public int Location;
        public int LevelNumber;
        public List<EnemySpawnData> Enemies;
        public int Reward;
    }
}
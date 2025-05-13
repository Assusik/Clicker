using System.Collections.Generic;
using Skripts.Extensions;
using UnityEngine;

namespace Skripts.Configs.LevelsConfigs {
    [CreateAssetMenu(menuName="Configs/LevelsConfig", fileName = "LevelsConfig")]
    public class LevelsConfig : ScriptableObject {
        public List<LevelData> Levels;
        private Dictionary<int, Dictionary<int, LevelData>> _levelsMap;
        
        public LevelData GetLevel(int location, int level) {
          if(_levelsMap.IsNullOrEmpty()) FillLevelMap();
          return _levelsMap[location][level];
            
           
        }

        public int GetWalletOnLevel(int level)
        {
            return Levels[level].Reward;
        }

        public int GetMaxLevelOnLocation(int location)
        {
            if(_levelsMap.IsNullOrEmpty()) FillLevelMap();
            var maxlevel = 0;
            foreach (var levelNumber in _levelsMap[location].Keys)
            {
                if(levelNumber <= maxlevel) continue;
                maxlevel = levelNumber;
            }

            return maxlevel;

        }
        public Vector2Int GetMaxLocationAndLevel() {
            if(_levelsMap.IsNullOrEmpty()) FillLevelMap();
            var locationAndLevel = new Vector2Int();
            foreach (var locationNumber in _levelsMap.Keys) {
                if (locationNumber <= locationAndLevel.x) continue;
                locationAndLevel.x = locationNumber;
            }
            
            foreach (var levelNumber in _levelsMap[locationAndLevel.x].Keys) {
                if (levelNumber <= locationAndLevel.y) continue;
                locationAndLevel.y = levelNumber;
            }

            return locationAndLevel;
        }
        public int GetMinLevelOnLocation(int location)
        {
            var minLevel = int.MaxValue;
            foreach (var levelData in Levels)
            {
                if (location == levelData.Location)
                {
                    if (levelData.LevelNumber < minLevel)
                    {
                        minLevel = levelData.LevelNumber;
                    }
                }
            }

            return minLevel;
        }

        private void FillLevelMap()
        {
            _levelsMap = new();
            foreach (var levelData in Levels)
            {
                var locationMap = _levelsMap.GetOrCreate(levelData.Location);
                locationMap[levelData.LevelNumber] = levelData;
            }
            
        }
    }
    
}
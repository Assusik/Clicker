using System.Collections.Generic;
using UnityEngine;

namespace Skripts.Configs.EnemyConfigs
{
    [CreateAssetMenu(menuName = "Config/EnemyConfig", fileName = "EnemysConfig")]
    public class EnemysConfig : ScriptableObject
    {
        public List<EnemyData> Enemies;
        public Enemy EnemyPrefab; 
        public Spell SpellPrefab;
        
    
        public EnemyData GetEnemy(string Id)
        {
            foreach (var enemyData in Enemies)
            {
                if (enemyData.Id == Id) return enemyData;
            }
            Debug.LogError($"not found enemy with id {Id}");    
            return default;
        }
    }
}   
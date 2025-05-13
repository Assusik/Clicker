using System;
using System.Collections.Generic;
using Skripts.Extensions;
using UnityEngine;

namespace Skripts.Configs.EnemyConfigs
{
    [CreateAssetMenu(menuName = "Config/KNBConfig", fileName = "KNBConfig")]
    public class KNBConfig : ScriptableObject
    {

        private Dictionary<EnemyType, Dictionary<EnemyType, float>> _dataMap = new();
        [SerializeField] private List<KNBData> _data;




        public float CalculateDamage(EnemyType from, EnemyType to, float damage)
        {
            
            if (_dataMap.IsNullOrEmpty()) FillDataMap();
           
         
            return _dataMap[from][to] * damage;
        }

        private void FillDataMap()
        {
            // _dataMap = new();
            
            foreach (var knbData in _data)
            {
                _dataMap.GetOrCreate(knbData.From);
                _dataMap[knbData.From] ??= new Dictionary<EnemyType, float>();
                _dataMap[knbData.From][knbData.To] = knbData.Multiplayer;
            }
        }
        
    }



    [Serializable]
    public struct KNBData
    {
        public EnemyType From;
        public EnemyType To;
        public float Multiplayer;
        

    }
    
}

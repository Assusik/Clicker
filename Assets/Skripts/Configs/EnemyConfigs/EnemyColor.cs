using System.Collections.Generic;
using UnityEngine;

namespace Skripts.Configs.EnemyConfigs
{
    [CreateAssetMenu(menuName = "Config/EnemyColor", fileName = "EnemyColor")]
    public class EnemyColor : ScriptableObject

    {
    public List<Color> EnemyColors;
    }
}
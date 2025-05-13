using UnityEngine;

namespace Skripts.SceneManagment
{
    public abstract class EntryPoint : MonoBehaviour
    {
        public abstract void Run(SceneEnterParams enterParams);
    }
}
using Skripts.Global.SaveSystem;
using UnityEngine;

namespace Skripts.SceneManagment
{
    public class MainEntryPoint:MonoBehaviour
    {
        private const string SCENE_LOADER_TAG = "CommonObject";

        public void Awake()
        {
            if (GameObject.FindGameObjectWithTag(SCENE_LOADER_TAG)) return;

            var commonObjectPrefab = Resources.Load<CommmonObject>("CommonObject");
            
            var commonObject = Instantiate(commonObjectPrefab);
            DontDestroyOnLoad(commonObject);
            // commonObject.SceneLoader.Initialize(commonObject.AudioManager);

            commonObject.SaveSystem = new();
            
            commonObject.SceneLoader.LoadMetaScene();
        }

        
    }
}
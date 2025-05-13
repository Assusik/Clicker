using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Meta.Locations
{
    public class Location:MonoBehaviour
    {
        [SerializeField] private List<Pin> _pins;

        public void Initialize(Pin.ProgressState locationState, int currentLevel, UnityAction<int> levelStartCallback)
        {
            

            for (var i = 0; i < _pins.Count; i++)
            {
                var level = i + 1;
                



                var pinState = locationState switch
                {
                    Pin.ProgressState.Passed => Pin.ProgressState.Passed,
                    Pin.ProgressState.Closed => Pin.ProgressState.Closed,
                    _ => currentLevel > level ? Pin.ProgressState.Passed :
                        currentLevel == level ? Pin.ProgressState.Current : Pin.ProgressState.Closed
                };
             

                if (pinState == Pin.ProgressState.Closed)
                {
                    _pins[i].Initialize(level, pinState,null);
                }
                else
                {
                    _pins[i].Initialize(level, pinState,() => levelStartCallback?.Invoke(level));
                    
                }
               
                
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

    }
}
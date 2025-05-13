using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts
{
   public class Timer : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _timerText;
      private float _maxTime;
      private float _currentTime;
      public event UnityAction OnTimerEnd;

      private bool _isPlaying;
   
   
      public void Initialize(float maxTime)
      {
         _maxTime = maxTime;
         _currentTime = maxTime;
      }

   

      public void Pause()
      {
         _isPlaying = false;
      }

      public void Rezume()
      {
         _isPlaying = true;
      }

      public void Play()
      {
         _isPlaying = true;
      }

      public void Stop()
      {
         _isPlaying = false;
         OnTimerEnd = null;
      }
   
      private void FixedUpdate()
      {
         if (!_isPlaying)
         {
            return;
         }

         var deltatime = Time.fixedDeltaTime;
         _currentTime -= deltatime;
         if (_currentTime<=0)
         {
            OnTimerEnd?.Invoke();
            Stop();
            return;
         }

         _currentTime -= deltatime;
         _timerText.text = _currentTime.ToString("00.00");
      }
   
   }
}

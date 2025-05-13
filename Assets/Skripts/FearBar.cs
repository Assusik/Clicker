using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Skripts
{
  public class FearBar : MonoBehaviour
  {
    [SerializeField] private Slider _fearBar;
    // [SerializeField] private Slider _extraFearBar;
    private bool _isPlaying = true;
    private float _maxFear;
    private float _currentFear;
    private float _extraFear;
    public event UnityAction OnMaxFear;
    // public event UnityAction OnExtraMaxFear;



    public void Initialize(float maxFear)
    {
      gameObject.SetActive(true);
      _currentFear = 0f;
      _maxFear = maxFear;
      _fearBar.maxValue = maxFear;
      _fearBar.value = _currentFear;
      // _extraFearBar.value = _currentFear;

    }
    public void Stop()
    {
    
      _isPlaying = false;
      OnMaxFear = null;
      gameObject.SetActive(false);
      // OnExtraMaxFear = null;
    }

    public void Play()
    {
      _isPlaying = true;
    }
  

    public void ShowHpBar()
    {
      _fearBar.gameObject.SetActive(true);
    }

 

    private void FixedUpdate()
    {
      if (!_isPlaying)
      {
        return;
      }

      var deltatime = Time.fixedDeltaTime;

      _currentFear += deltatime;
      if (_currentFear >= _maxFear)
      {
        OnMaxFear?.Invoke();
        Stop();
        return;
      }

      // if (_extraFearBar.value >= _maxFear)
      // {
      //   DOTween.Sequence()
      //     .AppendInterval(3f);
      //   //.AppendCallback(нужный метод); потом удалиить
      // }

    
      _fearBar.value = _currentFear;
      // _extraFearBar.value = _fearBar.value;
    


    }
  }
}

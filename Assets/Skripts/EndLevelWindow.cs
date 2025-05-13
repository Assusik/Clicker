using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Skripts
{
    public class EndLevelWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _looseWindow;
        [SerializeField] private GameObject _winWindow;
    
    
        [SerializeField] private Button _looseRestartButton;
        [SerializeField] private Button _winRestartButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private List<Button> _toMapButton;
        [SerializeField] private Timer _timer;
        [SerializeField] private TextMeshProUGUI MoneyText;

        public event UnityAction OnRestartClicked;
        public event UnityAction OnNextLevel;
        public event UnityAction ToMap; 

        public void Initialize()
        {
            _looseRestartButton.onClick.AddListener( Restart );
            _winRestartButton.onClick.AddListener( Restart );
            _nextLevelButton.onClick.AddListener(NextLevel);
            for (int i = 0; i < _toMapButton.Count; i++)
            {
                _toMapButton[i].onClick.AddListener(GoToMap);
            }
        
        
        }
        public void ShowLooseWindow()
        {
            gameObject.SetActive(true);
            _looseWindow.SetActive(true);
            _winWindow.SetActive(false);

        }
        public void ShowWinWindow(bool isLast,int money)
        {
            MoneyText.text = money.ToString();
            if (isLast)
            {
                _nextLevelButton.gameObject.SetActive(false);
            }

            _looseWindow.SetActive(false);
            _winWindow.SetActive(true);
            gameObject.SetActive(true);
            

        }

        private void Restart()
        {
            OnRestartClicked?.Invoke();
            gameObject.SetActive(false);
        }

        private void NextLevel()
        {
            OnNextLevel?.Invoke();
            
        }

        private void GoToMap()
        {
            ToMap?.Invoke();
        }
    }
}

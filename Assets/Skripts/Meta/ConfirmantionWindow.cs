using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Skripts.Meta
{
    public class ConfirmantionWindow : MonoBehaviour

    {
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _closeArea;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private TextMeshProUGUI _confirmText;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        _closeArea.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void ShowWindowInfo(UnityAction confirmCallback, string confirmText)
    {
        gameObject.SetActive(true);
        _confirmButton.onClick.RemoveAllListeners();
        _confirmButton.onClick.AddListener(() =>
        {
            confirmCallback?.Invoke();
            gameObject.SetActive(false);
        });
        _confirmText.text = confirmText;
    }


    










    }
}
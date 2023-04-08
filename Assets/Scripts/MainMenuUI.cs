using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInputField;

        private void Start()
        {
            nameInputField.text = GameManager.Instance.PlayerName;
        }
    }
}
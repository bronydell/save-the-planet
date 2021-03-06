﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene.Scripts.View.UI
{
    public class DemoUi : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI healthText;
        [SerializeField]
        private Button damageButton;

        public void SetHealth(int health)
        {
            healthText.SetText($"Health: {health}");
        }

        public void SetOnDamage(Action onDamage)
        {
            damageButton.onClick.AddListener(onDamage.Invoke);
        }
    }
}
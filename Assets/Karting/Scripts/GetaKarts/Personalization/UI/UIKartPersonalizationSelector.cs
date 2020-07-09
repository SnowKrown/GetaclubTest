using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GetaKarts.Personalization.UI
{
    public class UIKartPersonalizationSelector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText = default;
        [SerializeField] private TextMeshProUGUI indexText = default;

        private int current = 0;
        private int length;
        private Action<int> ValueChanged;

        public void SetUp(string name, int current, int length, Action<int> ValueChanged)
        {
            this.ValueChanged = ValueChanged;
            this.current = current;
            this.length = length;
            nameText.text = name;
            RefreshText();
        }

        public void Next()
        {
            current++;

            if (current >= length)
                current = 0;

            RefreshText();
            ValueChanged?.Invoke(current);
        }

        public void Previous()
        {
            current--;

            if (current < 0)
                current = length - 1;

            RefreshText();
            ValueChanged?.Invoke(current);
        }

        private void RefreshText()
        {
            indexText.text = current.ToString();
        }
    }
}

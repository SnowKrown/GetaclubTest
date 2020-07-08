using System;
using UnityEngine;

namespace GetaKarts.Personalization
{
    [Serializable]
    public struct KartVisualData
    {
        [Header("Body")]
        [SerializeField] private int bodyMaterialIndex;
        [SerializeField] private Color bodyColor;
        [Header("Wheels")]
        [SerializeField] private int wheelMaterialIndex;
        [SerializeField] private int rimIndex;
        [SerializeField] private int rimMaterialIndex;

        public int BodyMaterialIndex => bodyMaterialIndex;
        public Color BodyColor => bodyColor;
        public int WheelMaterialIndex => wheelMaterialIndex;
        public int RimIndex => rimIndex;
        public int RimMaterialIndex => rimMaterialIndex;

        public KartVisualData(int bodyMaterialIndex, Color bodyColor, int wheelMaterialIndex, int rimIndex, int rimMaterialIndex)
        {
            this.bodyMaterialIndex = bodyMaterialIndex;
            this.bodyColor = bodyColor;
            this.wheelMaterialIndex = wheelMaterialIndex;
            this.rimIndex = rimIndex;
            this.rimMaterialIndex = rimMaterialIndex;
        }
    }
}

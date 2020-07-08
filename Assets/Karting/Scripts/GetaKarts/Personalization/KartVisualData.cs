using System;
using UnityEngine;

namespace GetaKarts.Personalization
{
    [Serializable]
    public struct KartVisualData
    {
        [Header("Body")]
        public int bodyMaterialIndex;
        public int bodyColorIndex;
        [Header("Wheels")]
        public int tyreMaterialIndex;
        public int rimIndex;
        public int rimMaterialIndex;

        public KartVisualData(int bodyMaterialIndex, int bodyColorIndex, int tyreMaterialIndex, int rimIndex, int rimMaterialIndex)
        {
            this.bodyMaterialIndex = bodyMaterialIndex;
            this.bodyColorIndex = bodyColorIndex;
            this.tyreMaterialIndex = tyreMaterialIndex;
            this.rimIndex = rimIndex;
            this.rimMaterialIndex = rimMaterialIndex;
        }
    }
}

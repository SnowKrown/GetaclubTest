using System;
using UnityEngine;

namespace GetaKarts.Personalization
{
    public class KartVisuals : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer kartBody = default;
        [SerializeField] private Transform[] rimsParent = default;
        [SerializeField] private KartVisualData defaultVisualData = default;
        [SerializeField] private KartVisualLibrary visualLibrary = default;

        private KartVisualData? currentVisualData = null;

        private KartVisualData CurrentData
        {
            get
            {
                if (currentVisualData == null && PlayerPrefs.HasKey("KartVisualData"))
                    currentVisualData = JsonUtility.FromJson<KartVisualData>(PlayerPrefs.GetString("KartVisualData"));
                else
                    currentVisualData = defaultVisualData;

                return currentVisualData.Value;
            }
        }

        private void Awake()
        {
            ApplyCurrentVisuals();
        }

        private void ApplyCurrentVisuals()
        {
            kartBody.material = visualLibrary.BodyMaterials[CurrentData.BodyMaterialIndex];
            kartBody.material.color = CurrentData.BodyColor;
            
            if (kartBody.material.IsKeywordEnabled("_EMISSION"))
                kartBody.material.SetColor("_EmissionColor", CurrentData.BodyColor);
        }
    }
}

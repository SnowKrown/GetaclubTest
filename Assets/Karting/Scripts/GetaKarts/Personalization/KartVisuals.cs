using System;
using System.Collections.Generic;
using UnityEngine;

namespace GetaKarts.Personalization
{
    public class KartVisuals : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer kartBody = default;
        [SerializeField] private MeshRenderer[] tyres = default;
        [SerializeField] private Transform[] rimsParent = default;
        [SerializeField] private KartVisualData defaultVisualData = default;
        [SerializeField] private KartVisualLibrary visualLibrary = default;

        private KartVisualData currentVisualData;
        private List<Renderer> actualRims = new List<Renderer>();

        public KartVisualData SavedVisualData
        {
            get
            {
                if (PlayerPrefs.HasKey("KartVisualData"))
                    currentVisualData = JsonUtility.FromJson<KartVisualData>(PlayerPrefs.GetString("KartVisualData"));
                else
                    currentVisualData = defaultVisualData;

                return currentVisualData;
            }
        }

        private void Awake()
        {
            ApplyVisuals(SavedVisualData);
        }

        public void ApplyVisuals(KartVisualData visuals)
        {
            currentVisualData = visuals;
            ApplyRims();
            ApplyBody();
            Array.ForEach(tyres, t => t.material = visualLibrary.TyreMaterials[currentVisualData.tyreMaterialIndex]);
        }

        private void ApplyRims()
        {
            actualRims.ForEach(r => Destroy(r.gameObject));
            actualRims.Clear();

            foreach (Transform p in rimsParent)
            {
                KartVisualRim currentRim = visualLibrary.Rims[currentVisualData.rimIndex];
                Renderer newRim = Instantiate(currentRim.Prefab, p, false).GetComponent<Renderer>();
                newRim.material = currentRim.Materials[currentVisualData.rimMaterialIndex];
                actualRims.Add(newRim);
            }
        }

        private void ApplyBody()
        {
            kartBody.material = visualLibrary.BodyMaterials[currentVisualData.bodyMaterialIndex];
            kartBody.material.color = visualLibrary.BodyColors[currentVisualData.bodyColorIndex];

            if (kartBody.material.IsKeywordEnabled("_EMISSION"))
                kartBody.material.SetColor("_EmissionColor", visualLibrary.BodyColors[currentVisualData.bodyColorIndex]);
        }
    }
}

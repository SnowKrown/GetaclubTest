using UnityEngine;

namespace GetaKarts.Personalization.UI
{
    public class UIKartPersonalization : MonoBehaviour
    {
        [SerializeField] private UIKartPersonalizationSelector selectorPrefab = default;
        [SerializeField] private Transform selectorsTranform = default;
        [SerializeField] private KartVisualLibrary library = default;

        private KartVisuals kart;
        private KartVisualData data;
        private UIKartPersonalizationSelector rimsSelector;
        private UIKartPersonalizationSelector rimsMatSelector;
        private UIKartPersonalizationSelector tyresSelector;
        private UIKartPersonalizationSelector bodySelector;
        private UIKartPersonalizationSelector colorSelector;

        private void Awake()
        {
            kart = FindObjectOfType<KartVisuals>();
            data = kart.SavedVisualData;
            InstantiateSelectors();
            SetUpSelectors();
        }

        private void InstantiateSelectors()
        {
            rimsSelector = Instantiate(selectorPrefab, selectorsTranform, false);
            rimsMatSelector = Instantiate(selectorPrefab, selectorsTranform, false);
            tyresSelector = Instantiate(selectorPrefab, selectorsTranform, false);
            bodySelector = Instantiate(selectorPrefab, selectorsTranform, false);
            colorSelector = Instantiate(selectorPrefab, selectorsTranform, false);
        }

        private void SetUpSelectors()
        {
            rimsSelector.SetUp("Rims Style", data.rimIndex, library.Rims.Length, OnRimsChanged);
            rimsMatSelector.SetUp("Rims Material", data.rimMaterialIndex, library.Rims[data.rimIndex].Materials.Length, OnRimsMaterialChanged);
            tyresSelector.SetUp("Tyres", data.tyreMaterialIndex, library.TyreMaterials.Length, OnTyresChanged);
            bodySelector.SetUp("Body Style", data.bodyMaterialIndex, library.BodyMaterials.Length, OnBodyChanged);
            colorSelector.SetUp("Body Color", data.bodyColorIndex, library.BodyColors.Length, OnColorChanged);
        }

        private void OnRimsChanged(int newIndex)
        {
            data.rimMaterialIndex = 0;
            data.rimIndex = newIndex;
            rimsMatSelector.SetUp("Rims Material", data.rimMaterialIndex, library.Rims[data.rimIndex].Materials.Length, OnRimsMaterialChanged);
            kart.ApplyVisuals(data);
        }

        private void OnRimsMaterialChanged(int newIndex)
        {
            data.rimMaterialIndex = newIndex;
            kart.ApplyVisuals(data);
        }

        private void OnTyresChanged(int newIndex)
        {
            data.tyreMaterialIndex = newIndex;
            kart.ApplyVisuals(data);
        }

        private void OnBodyChanged(int newIndex)
        {
            data.bodyMaterialIndex = newIndex;
            kart.ApplyVisuals(data);
        }

        private void OnColorChanged(int newIndex)
        {
            data.bodyColorIndex = newIndex;
            kart.ApplyVisuals(data);
        }

        public void SaveData()
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("KartVisualData", json);
        }
    }
}

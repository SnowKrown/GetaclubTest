using UnityEngine;

namespace GetaKarts.Personalization
{
    [CreateAssetMenu(fileName = "KartVisualLibrary", menuName = "GetaKarts/Visual Library")]
    public class KartVisualLibrary : ScriptableObject
    {
        [SerializeField] private KartVisualRim[] rims = default;
        [SerializeField] private Material[] wheelMaterials = default;
        [SerializeField] private Material[] bodyMaterials = default;
        [SerializeField] private Color[] bodyColors = default;

        public Material[] BodyMaterials => bodyMaterials;
        public Material[] TyreMaterials => wheelMaterials;
        public KartVisualRim[] Rims => rims;
        public Color[] BodyColors => bodyColors;
    }
}

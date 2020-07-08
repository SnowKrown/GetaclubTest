using UnityEngine;

namespace GetaKarts.Personalization
{
    [CreateAssetMenu(fileName = "Kart Visual Library", menuName = "GetaKarts")]
    public class KartVisualLibrary : ScriptableObject
    {
        [SerializeField] private KartVisualRim[] rims = default;
        [SerializeField] private Material[] wheelMaterials = default;
        [SerializeField] private Material[] bodyMaterials = default;

        public Material[] BodyMaterials => bodyMaterials;
        public Material[] WheelMaterials => wheelMaterials;
        public KartVisualRim[] Rims => rims;
    }
}

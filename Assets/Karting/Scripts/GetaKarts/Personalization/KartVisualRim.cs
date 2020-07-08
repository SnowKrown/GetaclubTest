using System;
using UnityEngine;

namespace GetaKarts.Personalization
{
    [Serializable]
    public struct KartVisualRim
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Material[] materials;

        public GameObject Prefab => prefab;
        public Material[] Materials => materials;

        public KartVisualRim(GameObject prefab, Material[] materials)
        {
            this.prefab = prefab;
            this.materials = materials;
        }
    }
}

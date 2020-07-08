using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GetaKarts.Utils
{
    [RequireComponent(typeof(Renderer))]
    public class DisableRendererAtStart : MonoBehaviour
    {
        private enum Mode
        {
            Awake = 0,
            Start = 1
        }

        [SerializeField] private Mode executionMode = default;

        private Renderer myRenderer;

        private void Awake()
        {
            myRenderer = GetComponent<Renderer>();

            if (executionMode == Mode.Awake)
                myRenderer.enabled = false;
        }

        private void Start()
        {
            if (executionMode != Mode.Start)
                return;

            myRenderer.enabled = false;
        }
    }
}

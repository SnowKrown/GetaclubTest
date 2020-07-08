using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GetaKarts.Utils
{
    public class ObjectRotator : MonoBehaviour
    {
        [System.Flags]
        private enum Axis
        {
            X = (1 << 0),
            Y = (1 << 1),
            Z = (1 << 2),
        }

        [SerializeField] private Axis rotationAxis = default;
        [SerializeField] private float rotationSpeed = 2F;

        private void Update()
        {
            float xRotation = rotationAxis.HasFlag(Axis.X) ? rotationSpeed : 0;
            float yRotation = rotationAxis.HasFlag(Axis.Y) ? rotationSpeed : 0;
            float zRotation = rotationAxis.HasFlag(Axis.Z) ? rotationSpeed : 0;
            transform.Rotate(xRotation * Time.deltaTime, yRotation * Time.deltaTime, zRotation * Time.deltaTime);
        }
    }
}

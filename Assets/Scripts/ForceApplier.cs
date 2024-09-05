using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    [SerializeField] private float _startForce = 1;
    [SerializeField] private float _startSphereRadius = 1;

    public void BlowUp(Vector3 explosionPosition, float cubeScale)
    {
        foreach (Rigidbody rigidbody in GetNearRigidbodies(explosionPosition, _startSphereRadius / cubeScale))
            rigidbody.AddExplosionForce(_startForce / cubeScale, explosionPosition, cubeScale);
    }

    private List<Rigidbody> GetNearRigidbodies(Vector3 explosionPosition, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        List<Rigidbody> rigidbodies = new();

        foreach (Collider collider in colliders)
            if (collider.attachedRigidbody != null)
                rigidbodies.Add(collider.attachedRigidbody);

        return rigidbodies;
    }
}

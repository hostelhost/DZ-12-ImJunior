using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    [SerializeField] private float _explosiveForce = 10f;

    public void BlowUp(Vector3 explosionPosition, float radius)
    {
        foreach (Rigidbody rigidbody in GetNearRigidbodies(explosionPosition, radius))
            rigidbody.AddExplosionForce(_explosiveForce, explosionPosition, radius);
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

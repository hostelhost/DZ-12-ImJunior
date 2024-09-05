using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _decreaseNumber = 2;

    public event Action<Cube> Separation;

    public int SeparationProbability { get; private set; }

    public void OnClick()
    {
        if (IsProbable(SeparationProbability))
            Separation?.Invoke(this);

        Destroy(gameObject);
    }

    public void Initialize(int separationProbability)
    {
        SeparationProbability = separationProbability;
        SetRandomColor();
        ReduceImpact();
    }

    private void ReduceImpact()
    {
        SeparationProbability /= _decreaseNumber;
        transform.localScale /= _decreaseNumber;
    }

    private bool IsProbable(int separationProbability)
    {
        int minimum = 1;
        int maximum = 100;
        return UnityEngine.Random.Range(minimum, ++maximum) <= separationProbability;
    }

    private void SetRandomColor() =>
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
}
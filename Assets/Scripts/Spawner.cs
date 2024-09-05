using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private List<Cube> _cubesOnScene;
    [SerializeField] private ForceApplier _forceApplier;
    private int _startSeparationProbability = 200;

    private void Start()
    {
        foreach (Cube cube in _cubesOnScene)
        {
            cube.Initialize(_startSeparationProbability);
            cube.Separation += OnSeparation;
        }
    }
    
    private void OnSeparation(Cube cube)
    {
        CreateCubes(cube);
        _forceApplier.BlowUp(cube.transform.position, cube.transform.localScale.x);
    }

    private void CreateCubes(Cube cube)
    {
        Cube newCube;
        int minimumNumberObjects = 2;
        int maximumNumberObjects = 6;
        int creatingObjects = UnityEngine.Random.Range(minimumNumberObjects, ++maximumNumberObjects);

        for (int i = 0; i < creatingObjects; i++)
        {
            newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCube.Separation += OnSeparation;
            newCube.Initialize(cube.SeparationProbability);
        }

        cube.Separation -= OnSeparation;
    }
}

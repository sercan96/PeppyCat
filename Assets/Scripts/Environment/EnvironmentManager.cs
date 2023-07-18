using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer groundMesh;

    public static EnvironmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeGroundMat(Material material)
    {
         groundMesh.material = material;
    }
    
}

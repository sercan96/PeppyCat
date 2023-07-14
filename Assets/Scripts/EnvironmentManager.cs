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

    public Material ChangeGroundMat(Material material)
    {
        return groundMesh.material = material;
    }
    //public List<Material> groundMaterials;
    // private void OnEnable()
    // {
    //     EventManager.OnGameStart += ChangeEnvironmentWithDelay;
    // }
    // private void OnDisable()
    // {
    //     EventManager.OnGameStart -= ChangeEnvironmentWithDelay;
    // }
    //
    // private void ChangeEnvironmentWithDelay()
    // {
    //     if (GameManager.Instance.gameState != GameManager.GameState.PlayMixed && GameManager.Instance.gameState != GameManager.GameState.PlayJustOneAnimal)
    //         return;
    //     
    //     InvokeRepeating(nameof(ChangeEnvironment),0,Random.Range(25,50));
    // }
    // public void ChangeEnvironment()
    // {
    //     int getRndNumber = Random.Range(0, groundMaterials.Count);
    //     groundMesh.material = groundMaterials[getRndNumber];
    // }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentSetting : MonoBehaviour
{
    [SerializeField] private MeshRenderer groundMesh;
    public List<Material> groundMaterials;

    private void OnEnable()
    {
        EventManager.OnGameStart += ChangeEnvironmentWithDelay;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= ChangeEnvironmentWithDelay;
    }

    public void ChangeEnvironmentWithDelay()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Play)
            return;
        
        InvokeRepeating(nameof(ChangeEnvironment),0,Random.Range(25,50));
    }
    public void ChangeEnvironment()
    {
        int getRndNumber = Random.Range(0, groundMaterials.Count);
        groundMesh.material = groundMaterials[getRndNumber];
    }
}

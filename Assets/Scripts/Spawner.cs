using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public List<AnimalController> spawnAnimals;
    public List<AnimalController> animalList;
    public ParticleSystem dieParticle;

    public bool isFirstSpawn = true;
    private int animalCounter = 0;
    public static Spawner Instance;

    // [SerializeField] private int spawnAnimalCount;

    private int defaultObjectNumber=1;
    
    public List<AnimalController> choosenAnimals = new List<AnimalController>();

    public AnimalController lastDeadAnimal;
    private AnimalController selectedAnimal;
    
    
    public int spawnAnimalCount;
    public float speedValue; 
    
    
    private void OnEnable()
    {
        EventManager.OnGameStart += ChooseOneAnimal;
    }
    
    private void OnDisable()
    {
        EventManager.OnGameStart -= ChooseOneAnimal;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void SpawnAllObjects()
    {
        if(isFirstSpawn)
            return;
        
        foreach (var animal in spawnAnimals)
        {
            AnimalController spawnedObject = Instantiate(animal, transform);
            spawnedObject.movement.ChangeSpeedValue(speedValue);
            spawnedObject.name = "Object" + spawnedObject.GetInstanceID(); 
            animalList.Add(spawnedObject);
            animal.gameObject.SetActive(false);
        }
    }
    
    private void ChooseOneAnimal()
    {
        switch (GameManager.Instance.gameState)
        {
            case GameManager.GameState.PlayMixed:
                SpawnAllObjects();
                GetRandomChoose();
                break;
            case GameManager.GameState.PlayJustOneAnimal:
                GetChosenAnimal(selectedAnimal);
                break;
        }
    }
    
    public void CatchClickAnimal(AnimalController animalController)
    { 
        selectedAnimal = animalController;
    }

    private void GetChosenAnimal(AnimalController currenAnimal)
    {
        if (isFirstSpawn)
        {
            ActivateAnimal(lastDeadAnimal);
            return;
        }
            
        for (int i = 0; i < spawnAnimalCount; i++)
        {
            AnimalController spawnedObject = Instantiate(currenAnimal, transform);
            spawnedObject.movement.ChangeSpeedValue(speedValue);
            spawnedObject.name = "Object" + spawnedObject.GetInstanceID(); 
            animalList.Add(spawnedObject);
            ActivateAnimal(animalList[i]);
        }

        isFirstSpawn = true;
    }
    

    private void GetRandomChoose()
    {
        int maxSelectionCount = !isFirstSpawn ? spawnAnimalCount : defaultObjectNumber;

        for (int i = 0; i < maxSelectionCount; i++)
        {
            AnimalController randomAnimal = GetRandomAvailableAnimal();
            choosenAnimals.Add(randomAnimal);
            ActivateAnimal(randomAnimal);
        }

        isFirstSpawn = true;
    }

    private AnimalController GetRandomAvailableAnimal()
    {
        List<AnimalController> remainingAnimals = animalList.Except(choosenAnimals).ToList();
        int randomIndex = Random.Range(0, remainingAnimals.Count);
        return remainingAnimals[randomIndex];
    }

    private void ActivateAnimal(AnimalController animal)
    {
        animal.transform.position = RandomPositionGenerator.GetRandomPosition();
        animal.gameObject.SetActive(true);
    }

    public void RemoveFromList(AnimalController animal)
    {

        if (!animal.isActiveAndEnabled)
        {
            choosenAnimals.Remove(animal);
        }
    }

   
    public void GetNewAnimalWithDelay(Transform target)
    {
        DieParticle(target);
        Invoke(nameof(GetAnotherAnimal),1f);
    }
    private void DieParticle(Transform target)
    {
        ParticleSystem particle = Instantiate(dieParticle, target.position, Quaternion.identity);
        Destroy(particle.gameObject,3);
    }
    private void GetAnotherAnimal()
    {
        ChooseOneAnimal();
    }

    // public void UpdateSpawnValue(float value)
    // {
    //     spawnAnimalCount = (int) value;
    // }
    //
    // public void UpdateSpeedValue(float value)
    // {
    //     spawnAnimalCount = (int) value;
    // }

}

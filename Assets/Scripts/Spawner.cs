using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public List<AnimalController> spawnAnimals;
    public List<AnimalController> animalList;
    public AnimalController currentAnimal;
    public ParticleSystem dieParticle;

    public bool isFirstSpawn = true;
    private int animalCounter = 0;
    public static Spawner Instance;

    
    private System.Random random = new System.Random();
    public List<AnimalController> choosenAnimals = new List<AnimalController>();
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
    private void Start()
    {
        SpawnAllObjects();
    }

    private void SpawnAllObjects()
    {
        foreach (var animal in spawnAnimals)
        {
            animalList.Add(Instantiate(animal, transform));
            Instantiate(animal, transform);
            animal.gameObject.SetActive(false);
        }
    }
    
    private void ChooseOneAnimal()
    {
        int maxSelectionCount = isFirstSpawn ? 3 : 1;

        for (int i = 0; i < maxSelectionCount; i++)
        {
            AnimalController randomAnimal = GetRandomAvailableAnimal();
            choosenAnimals.Add(randomAnimal);
            ActivateAnimal(randomAnimal);
        }

        isFirstSpawn = false;
    }

    private AnimalController GetRandomAvailableAnimal()
    {
        List<AnimalController> remainingAnimals = animalList.Except(choosenAnimals).ToList();
        int randomIndex = random.Next(0, remainingAnimals.Count);
        return remainingAnimals[randomIndex];
    }

    private void ActivateAnimal(AnimalController animal)
    {
        //int random = Random.Range(0, animalList.Count);
        // animal = animalList[Random.Range(0, animalList.Count)];
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
        Invoke(nameof(GetAnotherAnimal),3f);
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
}

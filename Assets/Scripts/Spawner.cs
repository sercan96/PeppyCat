using System;
using System.Collections.Generic;
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

    public static Spawner Instance;

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
            animal.gameObject.SetActive(false);
        }
    }
    

    private void ChooseOneAnimal()
    {
        int random = Random.Range(0, spawnAnimals.Count);
        currentAnimal = animalList[random];
        currentAnimal.transform.position = RandomPositionGenerator.GetRandomPosition();
        currentAnimal.gameObject.SetActive(true);
    }

   
    public void GetNewAnimalWithDelay(Transform target)
    {
        DieParticle(target);
        Invoke(nameof(GetAnotherAnimal),4f);
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

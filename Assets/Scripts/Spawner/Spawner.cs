using System.Collections.Generic;
using System.Linq;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public List<AnimalController> spawnAnimals;
    public List<AnimalController> animalList;
    public ParticleSystem dieParticle;

    public bool isFirstSpawn;
    private int animalCounter = 0;
    public static Spawner Instance;

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
        if (isFirstSpawn)
            return;

        for (int i = 0; i < spawnAnimals.Count; i++)
        {
            AnimalController animal = spawnAnimals[i];
            AnimalController spawnedObject = Instantiate(animal, transform);
            spawnedObject.movement.ChangeSpeedValue(speedValue);
            spawnedObject.name = "Object" + spawnedObject.GetInstanceID();
            animalList.Add(spawnedObject);
            
            string layerName = "SpawnedObject" + i; 
            int layerIndex = SortingLayer.GetLayerValueFromName(layerName);
            SetObjectLayer(spawnedObject.gameObject, layerIndex);

            animal.gameObject.SetActive(false);
        }
    }
    private void SetObjectLayer(GameObject obj, int layerIndex)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in renderers)
        {
            renderer.gameObject.layer = layerIndex;
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
        // Seçilmemiş hayvanların bir listesini oluşturun
        List<AnimalController> remainingAnimals = animalList.Except(choosenAnimals).ToList();
    
        // 0 ile remainingAnimals.Count arasında rastgele bir indeks seçin
        int randomIndex = Random.Range(0, remainingAnimals.Count);
    
        // Seçilen rastgele hayvanı döndürün
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

   
    public void RespawnAnimals(Transform target,AnimalController animal)
    {
        DieParticle(target);
        GetAnotherAnimal();
        RemoveFromList(animal);
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

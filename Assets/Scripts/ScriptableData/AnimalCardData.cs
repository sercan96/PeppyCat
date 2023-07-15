using JSLizards.Iguana.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class AnimalCardData : ScriptableObject
{
   public AnimalController animalPrefab;
   public Material groundMat;
}

using System.Collections;
using System.Collections.Generic;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;

public class RaycastTarget : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private bool raycastProcessed = false;

    private void Update()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Play)
            return;
        
#if UNITY_EDITOR

      if (Input.GetMouseButtonDown(0) && !raycastProcessed)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Animal"))
                {
                    AnimalController animalCont = hit.collider.GetComponentInParent<AnimalController>();
                    animalCont.CloseObject();
                    //animalCont.GetComponentInParent<AnimatorController>()?.SetAsTargetObject(true);
                    Spawner.Instance.GetNewAnimalWithDelay(hit.transform);
                    Spawner.Instance.RemoveFromList(animalCont);
                    ScoreManager.Instance.AddScore(100);
                }
                else if (hit.collider.CompareTag("Far"))
                {
                    Debug.Log("Faraway");
                    hit.collider.GetComponentInParent<Movement>().EscapeFromClick();
                }
            }

            raycastProcessed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            raycastProcessed = false;
        }
#else
        
        switch (Input.touchCount)
        {
            case > 0 when !raycastProcessed:
            {
                Touch touch = Input.GetTouch(0);
        
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = mainCamera.ScreenPointToRay(touch.position);
                    RaycastHit hit;
        
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Animal"))
                        {
                            hit.collider.GetComponentInParent<AnimalController>().CloseObject();
                            Spawner.Instance.GetNewAnimalWithDelay(hit.transform);
                            ScoreManager.Instance.AddScore(100);
                        }
                        else if (hit.collider.CompareTag("Far"))
                        {
                            Debug.Log("Faraway");
                            hit.collider.GetComponentInParent<Movement>().EscapeFromClick();
                        }
                    }
        
                    raycastProcessed = true;
                }
        
                break;
            }
            case 0:
                raycastProcessed = false;
                break;
        }

#endif

        
       
        
    }
}




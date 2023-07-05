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
                            //EventManager.InvokeOnTargetDie();
                            // Debug.Log("SoClose");
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
    }
}




using System;
using System.Collections;
using System.Collections.Generic;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private float defaultMoveSpeed = 2;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float fastMoveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float escapeTimer = 0.75f;
    [SerializeField] private float minInterval = 1f;
    [SerializeField] private float maxInterval = 3f;
    [SerializeField] private float xMinLimit = -5f;
    [SerializeField] private float xMaxLimit = 5f;
    [SerializeField] private float zMinLimit = -4f;
    [SerializeField] private float zMaxLimit = 4f;

    private float currentInterval;
    private Vector3 randomDestination;
    private bool isMoving = true;

    private Vector3 currentDirection;
    private bool isChangingDirection;

    [SerializeField] private AnimatorController animatorCont;

    private void OnEnable()
    {
        EventManager.OnTargetMove += DefaultMoveSpeed;
        EventManager.OnTargetRun += OnTargetRun;
    }
    private void OnDisable()
    {
        EventManager.OnTargetMove -= DefaultMoveSpeed;
        EventManager.OnTargetRun -= OnTargetRun;
    }

    private void Start()
    {
        SetRandomInterval();
        SetRandomDestination();
        currentDirection = randomDestination - transform.position;
        currentDirection.y = 0f;
        currentDirection.Normalize();
    }

    private void Update()
    {
        if (isMoving)
        {
            UpdateMovingState();
        }
        else
        {
            UpdateIdleState();
        }
    }

    private void UpdateMovingState()
    {
        MoveTowardsDestination();
        RotateTowardsDestination();

        currentInterval -= Time.deltaTime;
            
        if (!(currentInterval <= 0f))
            return;

        HandleMovingIntervalEnd();
        SetRandomInterval();
    }

    private void HandleMovingIntervalEnd()
    { 
        IsAnimChange();
                
        if (isChangingDirection)
        {
            isChangingDirection = false;
        }
        else
        {
            isMoving = false;
            
            EventManager.InvokeOnTargetStop(animatorCont != null ? animatorCont.SetObjectTag() : null);
        }
        
    }

    private void UpdateIdleState()
    {
        currentInterval -= Time.deltaTime;
            
        if (!(currentInterval <= 0f)) 
            return;

        HandleIdleIntervalEnd();

        isMoving = true;
    
        EventManager.InvokeOnTargetMove(animatorCont != null ? animatorCont.SetObjectTag() : null);
        moveSpeed = defaultMoveSpeed;
       
    }

    private void HandleIdleIntervalEnd()
    {
        if (!isChangingDirection)
        {
            SetRandomInterval();
            SetRandomDestination();
            currentDirection = randomDestination - transform.position;
            currentDirection.y = 0f;
            currentDirection.Normalize();

            isChangingDirection = true;
        }
        else
        {
            isChangingDirection = false;
        }
    }

    private void IsAnimChange()
    {
        int random = Random.Range(0, 4);
        isChangingDirection = random != 0;
    }
    

    private void MoveTowardsDestination()
    {
        Vector3 newPosition = transform.position + currentDirection * moveSpeed * Time.deltaTime;

        // Check if the new position exceeds the x and z limits
        if (newPosition.x < xMinLimit || newPosition.x > xMaxLimit || newPosition.z < zMinLimit || newPosition.z > zMaxLimit)
        {
            // Calculate the closest position within the limits
            float newX = Mathf.Clamp(newPosition.x, xMinLimit, xMaxLimit);
            float newZ = Mathf.Clamp(newPosition.z, zMinLimit, zMaxLimit);

            // Calculate the direction to the closest position
            Vector3 newDirection = new Vector3(newX, 0f, newZ) - transform.position;
            newDirection.y = 0f;
            newDirection.Normalize();

            // Adjust the new position based on the closest position and the current direction
            newPosition = transform.position + newDirection * moveSpeed * Time.deltaTime;

            // Update the current direction
            currentDirection = newDirection;
        }

        transform.position = newPosition;
    }

    private void RotateTowardsDestination()
    {
        Quaternion toRotation = Quaternion.LookRotation(currentDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void SetRandomInterval()
    {
        currentInterval = Random.Range(minInterval, maxInterval);
    }

    private void SetRandomDestination()
    {
        float x = Random.Range(xMinLimit, xMaxLimit);
        float z = Random.Range(zMinLimit, zMaxLimit);
        randomDestination = new Vector3(x, 0f, z);
    }

    public void EscapeFromClick()
    {
        StopCoroutine(nameof(Escape));
        StartCoroutine(Escape(escapeTimer));
    }
    
    IEnumerator Escape(float waitTime)
    {
        if (animatorCont != null)
        {
            EventManager.InvokeOnTargetRun(animatorCont.SetObjectTag());
        }
        else
        {
            Debug.LogError("Animator controller is not assigned.");
        }

        yield return new WaitForSeconds(waitTime);

        if (animatorCont != null)
        {
            EventManager.InvokeOnTargetMove(animatorCont.SetObjectTag());
        }
        else
        {
            Debug.LogError("Animator controller is not assigned.");
        }
    }

    private void OnTargetRun(string tag)
    {
        if (gameObject.name != tag)
            return;
        
        currentInterval = 2f;
        isMoving = true;
        moveSpeed = fastMoveSpeed;
        
        ChooseRunPosition();
    }

    private void ChooseRunPosition()
    {
        float targetX = Random.Range(-10, 10);
        float targetZ = Random.Range(-7, 7);
        // Belirli bir noktaya gitmek için hedef pozisyonu belirleyin
        Vector3 targetPosition = new Vector3(targetX, 0f, targetZ); // targetX ve targetZ değerlerini istediğiniz noktanın koordinatlarına göre değiştirin
        // Hedef pozisyona doğru yönelmek için yeni bir yön vektörü oluşturun
        currentDirection = targetPosition - transform.position;
        currentDirection.y = 0f;
        currentDirection.Normalize();
    }
    private void DefaultMoveSpeed(string tag)
    {
        moveSpeed = defaultMoveSpeed;
    }

    public void ChangeSpeedValue(float speedValue)
    {
        int amountOfIncrease = 2;
        defaultMoveSpeed = moveSpeed += speedValue*0.5f;
        fastMoveSpeed = moveSpeed * amountOfIncrease;
    }
    
}


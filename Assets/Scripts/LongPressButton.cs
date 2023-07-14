using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float longPressDuration = 1.0f; // Uzun basma süresi (saniye)
    private bool isPressed = false;
    private float pressTime = 0.0f;
    private bool hasExecuted = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pressTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed && !hasExecuted && Time.time - pressTime >= longPressDuration)
        {
            hasExecuted = true;
            LevelLoader.Instance.LoadScene("Game");
        }
        else if (!isPressed)
        {
            hasExecuted = false;
        }
    }
}

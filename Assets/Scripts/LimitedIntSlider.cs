using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LimitedIntSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    public int minValue = 0; 
    public int maxValue = 4; 
    public int stepValue = 1;

    private int currentValue;
    
    public enum SliderType
    {
        SpawnCount,
        SpeedValue,
    }

    public SliderType sliderType;
    private void Start()
    {
        currentValue = Mathf.RoundToInt(slider.value); 
        slider.onValueChanged.AddListener(OnSliderValueChanged); 
    }

    private void OnSliderValueChanged(float value)
    {
        currentValue = Mathf.Clamp(Mathf.RoundToInt(value / stepValue) * stepValue, minValue, maxValue);
        slider.value = currentValue;
        
        SendSliderValueToAnimals();
        UpdateValueText(value);
    }
    private void UpdateValueText(float value)
    {
        valueText.text = $"{Mathf.RoundToInt(value)} / {Mathf.RoundToInt(slider.maxValue)}";
    }

    private void SendSliderValueToAnimals()
    {
        if(sliderType == SliderType.SpawnCount)
            Spawner.Instance.spawnAnimalCount = (int) slider.value;
        else if(sliderType == SliderType.SpeedValue)
            Spawner.Instance.speedValue = slider.value;
    }
}

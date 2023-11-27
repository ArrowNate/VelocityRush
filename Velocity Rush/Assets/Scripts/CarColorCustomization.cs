using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CarColorCustomization : MonoBehaviour
{
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private Image carPreview;

    private Color selectedColor = Color.white;

    private void Start()
    {
        LoadColor();
        UpdatePreview();
    }

    public void OnColorChanged()
    {
        selectedColor = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        //carPreview.color = selectedColor;
    }

    public void SaveColor()
    {
        PlayerPrefs.SetFloat("CarColorR", selectedColor.r);
        PlayerPrefs.SetFloat("CarColorG", selectedColor.g);
        PlayerPrefs.SetFloat("CarColorB", selectedColor.b);
        PlayerPrefs.Save();
    }

    private void LoadColor()
    {
        float r = PlayerPrefs.GetFloat("CarColorR", 1f);
        float g = PlayerPrefs.GetFloat("CarColorG", 1f);
        float b = PlayerPrefs.GetFloat("CarColorB", 1f);

        selectedColor = new Color(r, g, b);

        redSlider.value = r;
        greenSlider.value = g;
        blueSlider.value = b;
    }
}

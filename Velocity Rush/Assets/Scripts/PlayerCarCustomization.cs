using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCarCustomization : MonoBehaviour
{
    [SerializeField] private Renderer carRenderer; // Reference to the car's renderer or material

    private void Start()
    {
        ApplyCustomColor();
    }

    private void ApplyCustomColor()
    {
        float r = PlayerPrefs.GetFloat("CarColorR", 1f);
        float g = PlayerPrefs.GetFloat("CarColorG", 1f);
        float b = PlayerPrefs.GetFloat("CarColorB", 1f);

        Color customColor = new Color(r, g, b);

        // Apply the color to the car's material or color property
        carRenderer.material.color = customColor;
    }
}

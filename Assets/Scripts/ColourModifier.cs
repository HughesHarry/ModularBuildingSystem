using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourModifier : MonoBehaviour
{
    public GameObject ColourPanel;
    public Slider red;
    public Slider green;
    public Slider blue;

    public void OnEdit()
    {
        Color color = ColourPanel.GetComponent<Image>().color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        ColourPanel.GetComponent<Image>().color = color;
    } 
}

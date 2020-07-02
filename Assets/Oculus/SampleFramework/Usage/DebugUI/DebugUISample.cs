using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

// Show off all the Debug UI components.
public class DebugUISample : MonoBehaviour
{
    bool inMenu;
    private Text sliderText;

	void Start ()
    {
        DebugUIBuilder.instance.AddButton("Button Pressed", LogButtonPressed);
        DebugUIBuilder.instance.AddLabel("Label");
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Slider", 1.0f, 10.0f, SliderPressed, true);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        Assert.AreEqual(textElementsInSlider.Length, 2, "Slider prefab format requires 2 text components (label + value)");
        sliderText = textElementsInSlider[1];
        Assert.IsNotNull(sliderText, "No text component on slider prefab");
        sliderText.text = sliderPrefab.GetComponentInChildren<Slider>().value.ToString();
        DebugUIBuilder.instance.AddDivider();
        DebugUIBuilder.instance.AddToggle("Toggle", TogglePressed);
        DebugUIBuilder.instance.Show();
        inMenu = true;
	}

    public void TogglePressed(Toggle t)
    {
        Debug.Log("Toggle pressed. Is on? "+t.isOn);
    }
    public void RadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: "+radioLabel+", from group "+group+". New value: "+t.isOn);
    }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }

    void LogButtonPressed()
    {
        Debug.Log("Button pressed");
    }
}

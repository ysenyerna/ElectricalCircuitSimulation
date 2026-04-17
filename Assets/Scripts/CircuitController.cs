using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CircuitController : MonoBehaviour
{

	// Game objects
	public GameObject label;
	GameObject lightBulb;
	Slider slider;


	// Sprites
	public Sprite switchOpen;
	public Sprite switchClosed;

	private bool switch1On;
	private bool switch2On;

	private float voltage = 1;



	void Start()
	{
		lightBulb = GameObject.Find("Light");
		slider = GameObject.Find("VoltageSlider").GetComponent<Slider>();
		slider.GetComponent<Slider>().onValueChanged.AddListener(delegate { OnVoltageSlider_ValueChanged(); });
		UpdateCircuit();
	}

	public void OnSwitch1_Click()
	{
		switch1On = !switch1On;
		GameObject.Find("Switch1/Image").GetComponent<Image>().sprite = switch1On ? switchClosed : switchOpen;
		UpdateCircuit();
	}

	public void OnSwitch2_Click()
	{
		switch2On = !switch2On;
		GameObject.Find("Switch2/Image").GetComponent<Image>().sprite = switch2On ? switchClosed : switchOpen;
		UpdateCircuit();
		
	}

	public void OnVoltageSlider_ValueChanged()
	{
		voltage = slider.value;

		UpdateCircuit();

		// Update battery voltage visual
		GameObject.Find("Battery/Bottom").GetComponent<BatterySegment>().PercentShowing = AdjustVoltageValue(voltage * 3f);
		GameObject.Find("Battery/Middle").GetComponent<BatterySegment>().PercentShowing = AdjustVoltageValue((voltage - 1f/3f) * 3f);
		GameObject.Find("Battery/Top").GetComponent<BatterySegment>().PercentShowing = AdjustVoltageValue((voltage - 2f/3f) * 3f);
	}

	float AdjustVoltageValue(float val)
	{
		val = Math.Min(val, 1);
		val = Math.Max(val, 0);
		return val;
	}

	void UpdateCircuit()
	{
		var circuitClosed = switch1On && switch2On;

		// Update light intensity
		lightBulb.GetComponent<Image>().color = new (255, 255, 255, circuitClosed ? voltage : 0);

		// Update label
		string text = circuitClosed ? "Circuit complete" : "Circuit open";
		text += $" - Voltage : {voltage * 100f:F0}%";
		label.GetComponent<TextMeshProUGUI>().text = text;


	}

}

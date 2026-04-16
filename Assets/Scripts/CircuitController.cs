using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircuitController : MonoBehaviour
{

	// Game objects
	public GameObject label;
	public GameObject lightBulb;
	public GameObject slider;


	private bool switch1On;
	private bool switch2On;


	public void OnSwitch1_Click()
	{
		switch1On = !switch1On;
		UpdateCircuit();
	}

	public void OnSwitch2_Click()
	{
		switch2On = !switch2On;
		UpdateCircuit();
		
	}


	void UpdateCircuit()
	{
		string text = switch1On && switch2On ? "Circuit complete" : "Circuit open";
		label.GetComponent<TextMeshProUGUI>().text = text;


	}

	void Update()
	{
		var voltage = slider.GetComponent<Slider>().value;


		lightBulb.GetComponent<Image>().color = new (255, 255, 255, voltage);
	}

}

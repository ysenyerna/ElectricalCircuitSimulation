using UnityEngine;

public class BatterySegment : MonoBehaviour
{

	float _percentShowing;
	public float PercentShowing { get { return _percentShowing; } set { _percentShowing = value; UpdatePercentShowing(); } }

	RectTransform rect;

	float defaultY;
	float defaultHeight;

	void Start()
	{
		rect = GetComponent<RectTransform>();
		defaultY = rect.position.y;
		defaultHeight = rect.sizeDelta.y;
	}
	void UpdatePercentShowing()
	{
		var height = defaultHeight * PercentShowing;
		rect.sizeDelta = new (rect.sizeDelta.x, height);
		rect.position = new (rect.position.x, defaultY - (defaultHeight - height) / 2f);
		
	}

}

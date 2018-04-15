using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    public JoystickController2D _joystick;

    public Slider sliderX, sliderY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sliderX.value = _joystick.Horizontal;
        sliderY.value = _joystick.Vertical;
	}
}

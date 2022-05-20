using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TextMeshProUGUI _sliderText;
    float _prevVal;

    // Start is called before the first frame update
    void Start()
    {
        _sliderText.text = "4";
        _slider.value = 4;
        _prevVal = _slider.value;
        _slider.onValueChanged.AddListener(delegate { SliderLogic(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SliderLogic()
    {

        if (_slider.value % 2 != 0)
        {   //check odd value

            _slider.value = _prevVal;

        }
        else
        {

            _prevVal = _slider.value;

        }

        _sliderText.text = _slider.value.ToString();

    }
}

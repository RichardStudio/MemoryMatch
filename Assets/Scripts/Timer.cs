using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float timer = 0f;

    [SerializeField]
    private TextMeshProUGUI _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        _time.text = timer.ToString("0");
        DataHolder.time = timer.ToString("0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{

    public TextMeshProUGUI _time;

    public TextMeshProUGUI _guesses;

    // Start is called before the first frame update
    void Start()
    {
        _time.text = DataHolder.time;
        _guesses.text = DataHolder.guesses;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

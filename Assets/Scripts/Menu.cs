using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        DataHolder.numberOfButtons = int.Parse(_text.text);
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

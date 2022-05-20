using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject button;

    private void Awake()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        for (int i = 0; i < DataHolder.numberOfButtons; i++)
        {
            GameObject _button = Instantiate(button);
            _button.name = "" + i;
            _button.transform.SetParent(puzzleField, false);
        }
    }
}

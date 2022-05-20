using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImg;

    [SerializeField]
    private TextMeshProUGUI _guesser;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndx, secondGuessIndx;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Images");
    }

    // Start is called before the first frame update
    void Start()
    {
        GetButtons();
        AddListeners();
        AddPuzzles();
        Shuffle(gamePuzzles);

        gameGuesses = gamePuzzles.Count / 2;
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("puzzleBtn");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImg;
        }
    }

    void AddPuzzles()
    {
        int count = btns.Count;
        int idx = 0;
        int uimg = 0;
        if (DataHolder.sprite != null)
        {
            gamePuzzles.Add(DataHolder.sprite); 
            gamePuzzles.Add(DataHolder.sprite);
            uimg = 2;
        }
        for (int i = gamePuzzles.Count; i < count; i++)
        {
            if(idx == (count - uimg) / 2)
            {
                idx = 0;
            }
            gamePuzzles.Add(puzzles[idx]);
            idx++;
        }
    }
    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => GuessPuzzle());
        }
    }

    public void GuessPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndx = int.Parse(name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndx].name;
            btns[firstGuessIndx].image.sprite = gamePuzzles[firstGuessIndx];
        }else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndx = int.Parse(name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndx].name;
            btns[secondGuessIndx].image.sprite = gamePuzzles[secondGuessIndx];
            countGuesses++; 
            if(firstGuessPuzzle == secondGuessPuzzle)
            {
                print("match");
            }
            else
            {
                print("nah");
            }
            StartCoroutine(checkMatches());
            _guesser.text = countGuesses.ToString();
        }
    }

    IEnumerator checkMatches()
    {
        yield return new WaitForSeconds(0.5f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            btns[firstGuessIndx].interactable = false;
            btns[secondGuessIndx].interactable = false;

            btns[firstGuessIndx].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndx].image.color = new Color(0, 0, 0, 0);
            countCorrectGuesses++;
            CheckFinish();
        }
        else
        {
            btns[firstGuessIndx].image.sprite = bgImg;
            btns[secondGuessIndx].image.sprite = bgImg;
        }
        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;
    }

    void CheckFinish()
    {
        if(countCorrectGuesses == gameGuesses)
        {
            DataHolder.guesses = _guesser.text;
            SceneManager.LoadScene("Statistics");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}

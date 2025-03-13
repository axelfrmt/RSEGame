using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [Header("--- REFERENCES ---")]
    public TextMeshProUGUI ScoreBox;

    private GameController _gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void RefreshScore(){
        ScoreBox.text = ""+_gameController.Score;
    }
}

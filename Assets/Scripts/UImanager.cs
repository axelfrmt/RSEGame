using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [Header("--- REFERENCES ---")]
    public GameObject HUD;
    public GameObject FINISH;
    public TextMeshProUGUI TitleFinish;
    public TextMeshProUGUI CommentFinish;
    public TextMeshProUGUI PercentageFinish;
    public Image IconeTeam;
    public TextMeshProUGUI ScoreBox;
    public TextMeshProUGUI TimeBox;

    [Header("--- VALUES ---")]
    public float StartHour, EndHour;

    private GameController _gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        RefreshScore();
    }

    void Update()
    {
        _displayTime();
    }

    public void SwitchToFinish(bool win){
        HUD.SetActive(false);
        FINISH.SetActive(true);

        if(win){
            TitleFinish.text = "VICTORY";
            CommentFinish.text = "YOU KEPT A HEALTHY WORKPLACE!";
        } else{
            TitleFinish.text = "GAME OVER";
            CommentFinish.text = "YOU'RE NOT VERY RSE...";
        }
        PercentageFinish.text = ScoreBox.text+" SATISFACTION";
    }

    public void RefreshScore(){
        int percentage = Mathf.RoundToInt(((float)_gameController.Score/_gameController.ScoreMax)*100f);
        ScoreBox.text = percentage+"%";
        if(percentage > 100)
            percentage = 100;
        IconeTeam.color = Color.Lerp(Color.red, Color.green, (float)percentage/100);
    }

    private void _displayTime(){
        TimeBox.text = _gameController.GetInGameTime(StartHour, EndHour);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
}

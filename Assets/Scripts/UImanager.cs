using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [Header("--- REFERENCES ---")]
    public GameObject HUD;
    public GameObject FINISH;

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

    public void SwitchToFinish(){
        HUD.SetActive(false);
        FINISH.SetActive(true);
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
    
}

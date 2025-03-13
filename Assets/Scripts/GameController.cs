using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameController : MonoBehaviour
{
    public enum Difficulty{ Easy, Medium, Hard }

    [Header("--- REFERENCES ---")]
    public UImanager UIManager;
    public Volume GlobalVolume;
    public DifficultyLevel EasyDiffStats, MediumDiffStats, HardDiffStats;

    [Header("--- VALUES ---")]
    public Difficulty ActualDifficulty;
    public float Duration;

    [HideInInspector] public float MinTimeBetweenEachWord;
    [HideInInspector] public int PositiveScoreValue;
    [HideInInspector] public int NegativeScoreValue;
    [HideInInspector] public float WordSpeed;
    public int Score = 150;
    public int PercentageToCritical;
    public int ScoreMax = 300;
    [HideInInspector] public float Timer = 0;

    private float _timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchDifficulty(Difficulty.Easy);
    }

    // Update is called once per frame
    void Update()
    {
        _updateTimer();
        _difficultyManagement();
    }

    private void _updateTimer(){
        _timer += Time.deltaTime;
        if(_timer > Duration){
            Debug.Log("FIN DE PARTIE");
        }
    }

    private void _difficultyManagement(){
        if(_timer/Duration <= 1f/3f)
            SwitchDifficulty(Difficulty.Easy);
        else if(_timer/Duration > 1f/3f && _timer/Duration <= 2f/3f)
            SwitchDifficulty(Difficulty.Medium);
        else if(_timer/Duration > 2f/3f)
            SwitchDifficulty(Difficulty.Hard);
    }

    public string GetInGameTime(float startHour, float endHour)
    {
        float totalMinutesInGame = (endHour - startHour) * 60f; // 9h = 540 minutes
        float timeFactor = totalMinutesInGame / Duration;

        float currentMinutes = startHour * 60f + _timer * timeFactor;
        int roundedMinutes = (int)(currentMinutes / 5) * 5;
        int hours = (int)(roundedMinutes / 60f);
        int minutes = (int)(roundedMinutes % 60f);

        return $"{hours:00}:{minutes:00}"; // Format HH:MM
    }
    
    public void SwitchDifficulty(Difficulty difficulty){
        switch (difficulty) {
            case Difficulty.Easy:
                ActualDifficulty = Difficulty.Easy;
                MinTimeBetweenEachWord = EasyDiffStats.MinTimeBetweenEachWord;
                PositiveScoreValue = EasyDiffStats.PositiveScoreValue;
                NegativeScoreValue = EasyDiffStats.NegativeScoreValue;
                WordSpeed = EasyDiffStats.WordSpeed;
                break;
            case Difficulty.Medium:
                ActualDifficulty = Difficulty.Medium;
                MinTimeBetweenEachWord = MediumDiffStats.MinTimeBetweenEachWord;
                PositiveScoreValue = MediumDiffStats.PositiveScoreValue;
                NegativeScoreValue = MediumDiffStats.NegativeScoreValue;
                WordSpeed = MediumDiffStats.WordSpeed;
                break;
            case Difficulty.Hard:
                ActualDifficulty = Difficulty.Hard;
                MinTimeBetweenEachWord = HardDiffStats.MinTimeBetweenEachWord;
                PositiveScoreValue = HardDiffStats.PositiveScoreValue;
                NegativeScoreValue = HardDiffStats.NegativeScoreValue;
                WordSpeed = HardDiffStats.WordSpeed;
                break;
        }
    }

    public void ApplyScore(int scoreToApply){
        Score += scoreToApply;

        if(Score < 0)
            Score = 0;

        UIManager.RefreshScore();

        int percentage = Mathf.RoundToInt(((float)Score/ScoreMax)*100f);

        if(scoreToApply < 0)
            Camera.main.GetComponent<ScreenShake>().StartShake(0.2f, 0.2f);
        if(percentage < PercentageToCritical)
            ApplyCriticalPostProcess();
        else
            ReturnBasePostProcess();
    }

    public void ApplyCriticalPostProcess(){
        if(GlobalVolume.profile.TryGet<Vignette>(out Vignette vignette)){
            vignette.color.overrideState = true;
            vignette.color.Override(Color.red);
            vignette.intensity.overrideState = true;
            vignette.intensity.Override(0.44f);
        }
        
        if(GlobalVolume.profile.TryGet<ChromaticAberration>(out ChromaticAberration ca)){
            ca.intensity.Override(1);
        }
    }

    public void ReturnBasePostProcess(){
        if(GlobalVolume.profile.TryGet<Vignette>(out Vignette vignette)){
            vignette.color.overrideState = false;
            vignette.intensity.overrideState = false;
        }
        
        if(GlobalVolume.profile.TryGet<ChromaticAberration>(out ChromaticAberration ca)){
            ca.intensity.Override(0.44f);
        }
    }
}

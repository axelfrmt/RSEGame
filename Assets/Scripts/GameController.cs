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
    [HideInInspector] public int Score = 0;

    private float _timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchDifficulty(Difficulty.Easy);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
            SwitchDifficulty(Difficulty.Easy);
        else if(Input.GetKey(KeyCode.V))
            SwitchDifficulty(Difficulty.Medium);
        else if(Input.GetKey(KeyCode.B))
            SwitchDifficulty(Difficulty.Hard);
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
        UIManager.RefreshScore();
        if(scoreToApply < 0)
            Camera.main.GetComponent<ScreenShake>().StartShake(0.2f, 0.2f);
        if(Score < NegativeScoreValue*-1.5)
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

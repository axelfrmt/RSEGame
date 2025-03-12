using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyScore(int scoreToApply){
        Score += scoreToApply;
    }
}

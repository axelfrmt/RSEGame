using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyLevel", menuName = "Game/Difficulty Level")]
public class DifficultyLevel : ScriptableObject
{
    public float MinTimeBetweenEachWord;
    public int PositiveScoreValue;
    public int NegativeScoreValue;
    public float WordSpeed;
}
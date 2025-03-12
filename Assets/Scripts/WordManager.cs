using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header("--- REFERENCES ---")]
    public GameObject WordPrefab;
    public Transform SpawnPoint;
    public List<Transform> Rails = new List<Transform>();

    [Header("--- VALUES ---")]
    public int PositiveScoring;
    public int NegativeScoring;
    public List<string> GoodWords = new List<string>();
    public List<string> BadWords = new List<string>();

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
            _spawnWord();
    }

    void _spawnWord(){
        Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, Rails[Random.Range(0,Rails.Count)].position.z);
        Word word = Instantiate(WordPrefab, spawnPosition, Quaternion.LookRotation(Vector3.down)).GetComponent<Word>();
        if(Random.Range(1, 101) > 50){
            word.TextBox.text = GoodWords[Random.Range(0,GoodWords.Count)];
            word.ScoreModifier = PositiveScoring;
        }else{
            word.TextBox.text = BadWords[Random.Range(0,BadWords.Count)];
            word.ScoreModifier = NegativeScoring;
        }
    }
}

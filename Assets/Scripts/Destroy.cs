using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameController _controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Word"))
        {
            _controller.ApplyScore(other.GetComponent<Word>().ScoreModifier);
            Destroy(other.gameObject);
        }
    }
}

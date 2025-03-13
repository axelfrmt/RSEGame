using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    [Header("--- REFERENCES ---")]
    public TextMeshProUGUI TextBox;

    [Header("--- VALUES ---")]
    public float Speed;

    [HideInInspector] public int ScoreModifier;
    private GameController _gameController;

    void Start()
    {
        
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if(!_gameController.Finished)
            _move();
    }

    private void _move(){
        transform.position += new Vector3(-Speed*Time.deltaTime, 0, 0);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            Destroy(gameObject);
        else if(other.name == "DestroyZone"){
            _gameController.ApplyScore(ScoreModifier);
            Destroy(gameObject);
        }
    }

}

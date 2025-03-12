using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    public float Speed;
    public int ScoreModifier;
    public TextMeshProUGUI TextBox;

    void Update()
    {
        _move();
    }

    private void _move(){
        transform.position += new Vector3(-Speed*Time.deltaTime, 0, 0);
    }

    void OnTriggerStay(Collider other)
    {
        GameController controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if(other.CompareTag("Player"))
        {
            //controller.ApplyScore(ScoreModifier);
            Destroy(gameObject);
        }
    }
}

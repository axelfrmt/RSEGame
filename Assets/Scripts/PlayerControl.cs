using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public List<Transform> ReperesDeplacement = new List<Transform>();
    public float Speed;
    
    private bool _moving = false;
    private int _currentPosition = 1;
    private Vector3 _targetPosition;
    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if(GameObject.Find("ValuesToKeep").GetComponent<ValuesToKeep>().Gender == ValuesToKeep.GenderChosen.Man){
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        } else {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        _currentPosition = 0;
        _setTargetPosition(ReperesDeplacement[_currentPosition].position);
        transform.position = _targetPosition;
        _targetPosition = Vector3.zero;
    }

    void Update()
    {
        if(!_gameController.Finished){
            _controls();
            _moveToNextPosition();
        }
    }

    private void _controls(){
        if(Input.GetKey(KeyCode.UpArrow) && !_moving && _currentPosition-1 >= 0){
            _setTargetPosition(ReperesDeplacement[_currentPosition-1].position);
            _currentPosition = _currentPosition - 1;
            _moving = true;
        } else if(Input.GetKey(KeyCode.DownArrow) && !_moving && _currentPosition+1 < ReperesDeplacement.Count){
            _setTargetPosition(ReperesDeplacement[_currentPosition+1].position);
            _currentPosition = _currentPosition + 1;
            _moving = true;
        }
    }

    private void _setTargetPosition(Vector3 originalTarget){
        _targetPosition = new Vector3(transform.position.x, transform.position.y, originalTarget.z);
    }

    private void _moveToNextPosition(){
        if(_moving){
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed*Time.deltaTime);
            if(Vector3.Distance(transform.position, _targetPosition) < 0.05f)
            {
                _targetPosition = Vector3.zero;
                _moving = false;
            }
        }

    }
}

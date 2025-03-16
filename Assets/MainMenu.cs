using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator ScreenAnimator;
    public Animator CamAnimator;
    public ValuesToKeep ToKeep;
    public List<GameObject> ButtonsGO = new List<GameObject>();
    public int _index = 0;

    void Start()
    {
        ToKeep = GameObject.Find("ValuesToKeep").GetComponent<ValuesToKeep>();
    }
    public void Play(){
        ScreenAnimator.SetTrigger("PLAY");
        _index+=2;
        for(int i = 0; i < ButtonsGO.Count; i++){
            if(i != _index)
                ButtonsGO[i].SetActive(false);
            else
                ButtonsGO[i].SetActive(true);
        }
    }

    public void Credits(){
        ScreenAnimator.SetTrigger("CREDITS");
        _index++;
        for(int i = 0; i < ButtonsGO.Count; i++){
            if(i != _index)
                ButtonsGO[i].SetActive(false);
            else
                ButtonsGO[i].SetActive(true);
        }
        _index--;
    }

    public void ExitCredits(){
        ScreenAnimator.SetTrigger("EXITCREDITS");
        for(int i = 0; i < ButtonsGO.Count; i++){
            if(i != _index)
                ButtonsGO[i].SetActive(false);
            else
                ButtonsGO[i].SetActive(true);
        }
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void Next(){

        ScreenAnimator.SetTrigger("NEXT");
        _index++;
        for(int i = 0; i < ButtonsGO.Count; i++){
            if(i != _index)
                ButtonsGO[i].SetActive(false);
            else
                ButtonsGO[i].SetActive(true);
        }
    }

    public void ChosenCharacter(bool man){
        if(man)
            ToKeep.Gender = ValuesToKeep.GenderChosen.Man;
        else
            ToKeep.Gender = ValuesToKeep.GenderChosen.Woman;
        CamAnimator.SetTrigger("Exit");
    }

    public void Exit(){
        SceneManager.LoadScene(1);
    }
}

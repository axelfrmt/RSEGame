using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static string selectedCharacter = "None";
    public GameObject baseCharacter;
    public GameObject otherCharacter;

    public GameObject selectBaseCharacter;
    public GameObject selectOtherCharacter;
    
    public GameObject choiceCharacter;

    void Start()
    {
        if (baseCharacter != null && otherCharacter != null)
        {
            baseCharacter.SetActive(true);
            otherCharacter.SetActive(true);
        }
    }

    public void SelectBaseCharacter()
    {
        selectedCharacter = "baseCharacter";
        UpdateCharacterSelection(selectedCharacter);
    }

    public void SelectOtherCharacter()
    {
        selectedCharacter = "otherCharacter";
        UpdateCharacterSelection(selectedCharacter);
    }

    private void UpdateCharacterSelection(string character)
    {
        if (character == "baseCharacter")
        {
            baseCharacter.SetActive(character == "baseCharacter");
            selectBaseCharacter.SetActive(true);
            selectOtherCharacter.SetActive(false);
        }
        else if (character == "otherCharacter")
        {
            otherCharacter.SetActive(character == "baseCharacter");
            selectBaseCharacter.SetActive(false);
            selectOtherCharacter.SetActive(true);
        }

        choiceCharacter.SetActive(false);
    }

    public void PlayGame()
    {
        if(baseCharacter != null && otherCharacter != null)
        {
            SceneManager.LoadScene(selectedCharacter);
        }
        
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}

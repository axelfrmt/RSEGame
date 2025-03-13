using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static string selectedCharacter = "Base";
    public GameObject baseCharacter;
    public GameObject otherCharacter;

    public GameObject choiceCharacter;

    void Start()
    {
        if (baseCharacter != null && otherCharacter != null)
        {
            UpdateCharacterSelection(selectedCharacter);
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
        baseCharacter.SetActive(character == "baseCharacter");
        otherCharacter.SetActive(character == "otherCharacter");
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

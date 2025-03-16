using UnityEngine;

public class ValuesToKeep : MonoBehaviour
{
    public enum GenderChosen{
        Man, Woman
    }

    public static ValuesToKeep Instance;
    public GenderChosen Gender;

    void Awake()
    {
        // Si une instance existe déjà, on détruit ce nouvel objet
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ne pas détruire l'objet lors du changement de scène
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

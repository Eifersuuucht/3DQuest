using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{   
    public GameObject continueButton;



    void Awake()
    {
        if(FindObjectOfType<GameManager>().GetLastSave() == 0 || FindObjectOfType<GameManager>().GetLastSave() == 4)
        {
            continueButton.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        int lastSave = FindObjectOfType<GameManager>().GetLastSave();
        SceneManager.LoadScene(lastSave);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
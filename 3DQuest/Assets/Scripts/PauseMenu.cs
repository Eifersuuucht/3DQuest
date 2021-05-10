using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    bool isSettings = false;
    public Canvas cv;
    
    void Start()
    {
        cv.sortingOrder = 1; //Pause menu first above all other canvases
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && !isSettings)//if escape is pressed and settings is not on the screen
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
	}

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("Ambient");
        FindObjectOfType<AudioManager>().Stop("LevelTheme");
        FindObjectOfType<AudioManager>().Play("MainTheme");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
    }

    public void Settings()
    {
        isSettings = true;
    }

    public void OutSettings()
    {
        isSettings = false;
    }
}

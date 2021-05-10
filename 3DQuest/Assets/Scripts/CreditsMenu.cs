using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour {

	public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayFinale()
    {
        FindObjectOfType<AudioManager>().Play("Finale");
    }
}

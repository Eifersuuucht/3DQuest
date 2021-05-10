using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    string path;
    int activeScene;

    // Use this for initialization
    void Awake ()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            Cursor.visible = false;
        else
            Cursor.visible = true;

        activeScene = SceneManager.GetActiveScene().buildIndex;
        path = Application.dataPath + "/saves.txt";
        if(activeScene != 0)
        {
            File.WriteAllText(path, activeScene.ToString());
        }
	}
	
    public int GetLastSave()
    {
        path = Application.dataPath + "/saves.txt";
        return Int32.Parse(File.ReadAllText(path));
    }


}



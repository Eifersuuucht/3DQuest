using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    [SerializeField]
    GameObject completeLevelUI;

	void OnTriggerEnter()
    {
        completeLevelUI.SetActive(true);
    }
}

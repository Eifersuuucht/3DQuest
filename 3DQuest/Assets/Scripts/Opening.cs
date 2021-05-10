using UnityEngine;

public class Opening : MonoBehaviour {

    Animator an;
    // Use this for initialization
    void Start() {
        an = gameObject.GetComponent<Animator>();
    }


    void OnTriggerStay()
    {
        an.ResetTrigger("Close");
        an.SetTrigger("Open");
    }
    void OnTriggerExit()
    {
        an.ResetTrigger("Open");
        an.SetTrigger("Close");
    }

    public void PlayGateOpen()
    {
        FindObjectOfType<AudioManager>().Play("GateOpen");
    }
}

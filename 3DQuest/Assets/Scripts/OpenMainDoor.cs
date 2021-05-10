using UnityEngine;

public class OpenMainDoor : MonoBehaviour {

    Animator an;

	// Use this for initialization
	void Start () {
        an = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter()
    {
        an.SetTrigger("Action");
    }
}

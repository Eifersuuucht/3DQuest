using UnityEngine;

public class Grabbable1 : MonoBehaviour {

    public ThrowObject throbj;
    

    void OnTriggerEnter(Collider other)
    {
        //if the object which is colliding with our cube isTrigger then our cube will not touched
        if(!other.isTrigger)
            throbj.Touching(GetComponent<Collider>().name);
    }
}

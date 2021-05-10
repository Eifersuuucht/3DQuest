using UnityEngine;


public class ThrowObject : MonoBehaviour
{

    public Transform player;
    public Transform playerCam;
    [SerializeField]
    GameObject leftMouseButton;
    [SerializeField]
    GameObject rightMouseButton;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool hasAlready;
    bool beingCarried = false;
    bool touched;
    float lengthRay = 2f;
    RaycastHit hit, hitEverything;
    string tagName;
    void Start()
    {
        hasAlready = false;
        touched = false;
    }




    // Update is called once per frame
    void Update()
    {

        int layerMask = 1 << 8;
        if (!beingCarried)
        {
            hit = new RaycastHit();
            hitEverything = new RaycastHit();
            //Get info about Raycast ray, and what it collided
            Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, lengthRay, layerMask);
            Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitEverything, lengthRay);

        }

        //we compare two raycast in order to choose only our layerMask, and only if it stands in front of us without any obstacles
        if (hit.collider == hitEverything.collider && hit.collider != null)
        {
            hasPlayer = true;
            if(!beingCarried)
            {
                leftMouseButton.SetActive(true);
            }
            else
            {
                leftMouseButton.SetActive(false);
            }
                
        }
        else
        {
            hasPlayer = false;
            leftMouseButton.SetActive(false);
        }
        //Actual obtaining of a thing
        if (!hasAlready && hasPlayer && Input.GetAxis("Fire1") != 0)
        {
            touched = false;
            //in order not to create constantly new string
            if (tagName != hit.collider.name)
            {
                tagName = hit.collider.name;
            }


            hit.rigidbody.isKinematic = true;
            hit.transform.parent = player;
            //hit.transform.localScale *= 0.5f;
            hit.transform.rotation = player.rotation;
            hit.transform.position = player.position + player.forward * 1f + player.up * 0.2f; //use position.forward(this is for transforming with considering of rotation)

            beingCarried = true;
            hasAlready = true;
            rightMouseButton.SetActive(true);
        }
        // if object is carried it can be touched, thrown or relieved
        if (beingCarried)
        {
            if (touched)
            {
                hit.rigidbody.isKinematic = false;
                hit.transform.parent = null;
                beingCarried = false;
                hasAlready = false;
                touched = false;
                rightMouseButton.SetActive(false);
                FindObjectOfType<AudioManager>().Play("BoxDrop");
                //hit.transform.localScale *= 2f;
            }
            //if (Input.GetAxis("Fire1") != 0)
            //{
            //    hit.rigidbody.isKinematic = false;
            //    hit.transform.parent = null;
            //    beingCarried = false;
            //    hasAlready = false;
            //    //hit.transform.localScale *= 2f;
            //    hit.rigidbody.AddForce(playerCam.forward * throwForce);
            //}
            else if (Input.GetAxis("Fire2") != 0)
            {
                hit.rigidbody.isKinematic = false;
                hit.transform.parent = null;
                beingCarried = false;
                hasAlready = false;
                rightMouseButton.SetActive(false);
                FindObjectOfType<AudioManager>().Play("BoxDrop");
                //hit.transform.localScale *= 2f;
            }
        }
    }


    public void Touching(string name)
    {
        //if tagName(name of a cube that we are carrying) is touched then object is touched
        if (tagName == name)
        {
            touched = true;
        }
    }


}

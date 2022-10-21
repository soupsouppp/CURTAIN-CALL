using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject door;

    public void OnTriggerEnter2D(Collider2D other)
    {
        door doorCode = door.GetComponent<door>();

        if (other.tag == "Player")
        {
            Debug.Log("triggered");
            doorCode.OpenDoor();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        door doorCode = door.GetComponent<door>();

        if (other.tag == "Player")
        {
            Debug.Log("triggered");
            doorCode.CloseDoor();
        }
    }
    public void Start()
    {
        

    }
}



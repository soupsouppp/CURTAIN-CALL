using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        anim.SetTrigger("openDoor");
    }

    public void CloseDoor()
    {
        anim.SetTrigger("closeDoor");
    }
}

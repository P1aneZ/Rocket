using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DoorAnimation : MonoBehaviour
{
    private Animator anim;

    private DoorBehaviour doorBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorBehaviour = GetComponent<DoorBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        anim.SetBool("isOpen", doorBehaviour.isOpen);
    }
}

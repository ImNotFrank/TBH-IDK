using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private bool initialState;
    private bool currentState;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        currentState = initialState;
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("Open", currentState);
        coll.enabled = !currentState;
    }

    public void DoorChange(bool open)
    {
        if(initialState)
        {
            currentState = open;
            
        }
        else
        {
            currentState = !open;
        }
    }
}

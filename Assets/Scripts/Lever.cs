using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private GameObject player;
    [SerializeField] private bool flipDir = false;
    [SerializeField] private GameObject[] Connected;
    [SerializeField] private string[] messages;
    [SerializeField] private int[] ints;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("e") && Vector3.Distance(this.transform.position, player.transform.position) <= 2f)
        {
            anim.SetTrigger("LeverFlipped");
            foreach(int i in ints)
            {
                Connected[i].BroadcastMessage(messages[i], flipDir);
            }
        }
        sprite.flipX = flipDir;
    }

    private void DoneFlip()
    {
        flipDir = !flipDir;
        anim.SetTrigger("LeverNO");
    }
}

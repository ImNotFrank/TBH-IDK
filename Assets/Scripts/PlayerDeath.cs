using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool dead = false;
    [SerializeField] private AudioSource deathSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && dead == false)
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        dead = true;
    }

    private void RestartLevel()
    {
        GameObject skull = GameObject.Find("Skull");
        GameObject respawn = GameObject.Find("PlayerRespawn");
        skull.transform.position = transform.position;
        transform.position = respawn.transform.position;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("Respawn");
        this.gameObject.GetComponent<PlayerMovement>().skullDropped = true;
        dead = false;
    }
}

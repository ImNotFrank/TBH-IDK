using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NestLevel : MonoBehaviour
{
    [SerializeField] private AudioSource finishAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishAudio.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !finishAudio.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

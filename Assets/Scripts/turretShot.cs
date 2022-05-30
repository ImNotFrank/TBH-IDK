using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShot : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject bullet;
    private RaycastHit2D hit;
    private Animator anim;
    private float timeLeft = 1f;
    [SerializeField] private float timeBetween;
    private void Start()
    {
        anim = GetComponent<Animator>();
        timeLeft = timeBetween;
    }
    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, mask);
        if (hit.transform.gameObject.name == "Player" && timeLeft <= 0f)
        {
            Fire();
            timeLeft = timeBetween;
        }
        else
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
    }

    private void Fire()
    {
        anim.SetTrigger("Shot");
        Instantiate(bullet, this.transform.position, this.transform.rotation);
    }
}

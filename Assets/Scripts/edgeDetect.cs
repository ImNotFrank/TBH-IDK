using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeDetect : MonoBehaviour
{
    private BoxCollider2D coll;
    private GameObject enemy;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private string enemyName;
    [SerializeField] private float dir;
    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        enemy = GameObject.Find(enemyName);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .5f, jumpableGround) == false)
        {
            enemy.BroadcastMessage("edge", dir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            enemy.BroadcastMessage("edge", dir);
        }
    }
}

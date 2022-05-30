using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    private GameObject spawn;
    // Start is called before the first frame update
    private void Start()
    {
        spawn = GameObject.Find("player respawn spawn");
    }
    public void Change(bool on)
    {
        transform.position = spawn.transform.position;
    }
}

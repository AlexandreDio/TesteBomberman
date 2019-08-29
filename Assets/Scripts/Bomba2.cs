using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba2 : MonoBehaviour
{
    public GameObject fire;
    public int firePower;
    public float fuse;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", fuse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        Debug.Log("Boom" + firePower);

        //Create center fire
        Instantiate(fire, transform.position, Quaternion.identity);

        //create the rest of the fire
        for (int i = 0; i < firePower; i++)
        {
            SpawnFire(new Vector3(i + 1, 0, 0));
            SpawnFire(new Vector3(-i - 1, 0, 0));
            SpawnFire(new Vector3(0, i + 1, 0));
            SpawnFire(new Vector3(0, -i - 1, 0));
        }

        Destroy(gameObject);
    }

    private void SpawnFire(Vector3 offset)
    {
        if (true)
        {
            Instantiate(fire, transform.position + offset * 1.4f, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Destruivel"))
        {
            Debug.Log("passeiiiiiiii");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bloco-fogo"))
        {
            print("testandooooooooooo");
        }
    }
}

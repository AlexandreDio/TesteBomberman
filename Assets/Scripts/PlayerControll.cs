using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rigid;

    [Header("Velocidade do player")]
    [SerializeField]
    float MoveSpeed = 0.1f;

    string elementos;

    bool invencivel = false;

    public GameObject cenario;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        AguaMovimento();
    }

    public void AguaMovimento()
    {
        if (Input.GetKey("d"))
        {
            this.transform.Translate(new Vector2(MoveSpeed, rigid.velocity.y));
        }
        else if (Input.GetKey("a"))
        {
            this.transform.Translate(new Vector2(-MoveSpeed, rigid.velocity.y));
        }
        else if (Input.GetKey("w"))
        {
            this.transform.Translate(new Vector2(rigid.velocity.x, MoveSpeed));

        }
        else if (Input.GetKey("s"))
        {
            this.transform.Translate(new Vector2(rigid.velocity.x, -MoveSpeed));
        }
        else
        {
            this.rigid.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bloco-fogo"))
        {
            print("OnTrigger do PlayerControll");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("UpVelocidade"))
        {

            MoveSpeed += 0.25f;

            StartCoroutine(Tempo());
        }

        if (collision.gameObject.CompareTag("Indestrutivel"))
        {
            invencivel = true;
            print(invencivel);
            StartCoroutine(invencivel1());
        }

        if (invencivel == false)
        {
            if (collision.gameObject.CompareTag("explosao"))
            {
                Destroy(this.gameObject);
            }
        }

    }

    public IEnumerator Tempo()
    {
        yield return new WaitForSeconds(6f);
        RevertSpeed();
    }

    public IEnumerator invencivel1()
    {
        if (invencivel == true)
        {
            yield return new WaitForSeconds(5);
            mortal();
        }
    }

    private void mortal()
    {
        invencivel = false;
    }

    public void RevertSpeed()
    {
        MoveSpeed = 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bloco-fogo"))
        {
            print("OnCollision do PlayerControll");
            Destroy(gameObject);
        }
    }
}

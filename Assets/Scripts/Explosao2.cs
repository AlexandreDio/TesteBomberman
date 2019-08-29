using UnityEngine;

public class Explosao2 : MonoBehaviour
{
    public GameObject Destruivel;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bloco-fogo"))
        {
            print("passei 11111111");
            //Destruivel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bloco-fogo"))
        {
            print("destruindo o bloco-fogo");
            Destroy(collision.gameObject);
        }
    }
}

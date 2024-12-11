using UnityEngine;

public class OrangeProduct : MonoBehaviour, IFruitProduct
{
    private string name = "orange";
    private int score = 100;

    public string Name { get => name; set => name = value; }
    public int Score { get => score; set => score = value; }


    public void Behaviour()
    {

    }

    public void Initialize()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("points") || collision.gameObject.CompareTag("grospoints"))
        {
            Destroy(collision.gameObject);
        }
    }
}


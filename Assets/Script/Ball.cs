using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    private Vector2 direction;

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        // Si la balle touche une raquette ou le mur, elle change de direction
        if (collision.gameObject.tag == "Paddle")
        {
            direction.x = -direction.x; // Inverse la direction en x
        }
        else if (collision.gameObject.tag == "Wall")
        {
            direction.y = -direction.y; // Inverse la direction en y
        }
    }

    // Remet la balle au centre avec une nouvelle direction
    private void ResetBall()
    {
        transform.position = Vector2.zero; // Centre de l'écran
        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(-1f, 1f)).normalized;
    }
}

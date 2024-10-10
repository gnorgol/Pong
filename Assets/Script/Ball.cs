using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    private Vector2 direction;
    public AudioClip paddleSound; // Son de rebond sur une raquette
    public AudioClip wallSound;   // Son de rebond sur un mur

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Récupère l'AudioSource de la balle
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
            audioSource.PlayOneShot(paddleSound); // Joue le son de rebond sur une raquette
        }
        else if (collision.gameObject.tag == "Wall")
        {
            direction.y = -direction.y; // Inverse la direction en y
            audioSource.PlayOneShot(wallSound); // Joue le son de rebond sur un mur
        }
    }

    // Remet la balle au centre avec une nouvelle direction
    private void ResetBall()
    {
        transform.position = Vector2.zero; // Centre de l'écran
        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(-1f, 1f)).normalized;
    }
}

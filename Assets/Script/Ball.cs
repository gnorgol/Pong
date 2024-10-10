using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 8f; // Vitesse initiale de la balle
    public float maxSpeed = 20f;    // Vitesse maximale de la balle
    public float speedIncrease = 0.5f; // Augmentation de la vitesse à chaque frame
    public float paddleBounceAngleFactor = 0.5f; // Facteur d'inclinaison de l'angle selon le point de contact


    public float currentSpeed; // Vitesse actuelle de la balle
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
        // Déplacement de la balle avec la vitesse actuelle
        transform.Translate(direction * currentSpeed * Time.deltaTime);

        // Augmentation progressive de la vitesse (jusqu'à un maximum)
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncrease * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        // Si la balle touche une raquette ou le mur, elle change de direction
        if (collision.gameObject.tag == "Paddle")
        {
            Vector2 paddlePos = collision.transform.position;
            float hitFactor = (transform.position.y - paddlePos.y) / collision.collider.bounds.size.y;

            // Calculer un nouvel angle basé sur le facteur de collision
            direction = new Vector2(-direction.x, hitFactor).normalized;

            // Optionnel : ajouter un effet de spin si le joueur se déplace pendant l'impact
            Rigidbody2D paddleRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (paddleRb != null && Mathf.Abs(paddleRb.velocity.y) > 0.1f)
            {
                // Appliquer un léger effet sur l'axe Y selon la vitesse de la raquette
                direction.y += paddleRb.velocity.y * paddleBounceAngleFactor;
            }

            // Normaliser la direction pour s'assurer que la balle garde sa vitesse constante
            direction = direction.normalized;
            audioSource.PlayOneShot(paddleSound); // Joue le son de rebond sur une raquette
        }
        else if (collision.gameObject.tag == "Wall")
        {
            direction.y = -direction.y; // Inverse la direction en y
            audioSource.PlayOneShot(wallSound); // Joue le son de rebond sur un mur
        }
        if (collision.gameObject.tag == "PlayerGoal")
        {
            GameManager.Instance.AIScores();
        }
        else if (collision.gameObject.tag == "AIGoal")
        {
            GameManager.Instance.PlayerScores();
        }
    }

    // Remet la balle au centre avec une nouvelle direction
    public void ResetBall()
    {
        // Remet la balle au centre de l'écran
        transform.position = Vector2.zero;

        // Réinitialiser la vitesse à la vitesse initiale après chaque point
        currentSpeed = initialSpeed;

        // Choisir une direction aléatoire (vers la droite ou la gauche)
        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(-1f, 1f)).normalized;
    }
}

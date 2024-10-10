using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public float speed = 5f;  // Vitesse de déplacement de la raquette IA
    public Transform ball;    // Référence à la balle (à attribuer dans l'inspecteur)
    public float smoothFactor = 0.1f;  // Facteur de lissage pour rendre le mouvement plus fluide

    private void Update()
    {
        // Calculer la position cible de la raquette IA (suivre la balle sur l'axe Y)
        float targetY = ball.position.y;

        // Utiliser Lerp pour lisser le mouvement de l'IA vers la position de la balle
        float newY = Mathf.Lerp(transform.position.y, targetY, smoothFactor * Time.deltaTime * speed);

        // Appliquer la nouvelle position à la raquette
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Limiter le mouvement de la raquette pour qu'elle ne sorte pas de l'écran
        float yPos = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

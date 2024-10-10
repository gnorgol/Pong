using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
   

    private void Update()
    {
        float move = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Limiter le mouvement des raquettes � l'�cran
        float yPos = Mathf.Clamp(transform.position.y, -4f, 6f);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
   

    private void Update()
    {
        float move = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Limiter le mouvement des raquettes à l'écran
        float yPos = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

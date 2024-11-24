using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public InputActionReference moveAction;



    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        // Déplacement de la raquette
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        float move = moveInput.y * speed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Limiter le mouvement des raquettes à l'écran
        float yPos = Mathf.Clamp(transform.position.y, -4f, 6f);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

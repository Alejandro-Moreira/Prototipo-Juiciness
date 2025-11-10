using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public Rigidbody rb;

    private void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, 0, move) * speed * Time.deltaTime;
        transform.Translate(movement);
        transform.Rotate(0, turn * 100f * Time.deltaTime, 0);

        // Animación caminar
        bool isWalking = move != 0;
        animator.SetBool("isWalking", isWalking);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }

        // Ataque
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }
}
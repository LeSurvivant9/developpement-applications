using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersControl : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField]private float speed; //vitesse deplacement
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerDamageHandler damage;
    [SerializeField] private Transform basePoint; 


    float horizontal;
    float vertical;

    public float Speed { get => speed; set => speed = value; }


    private void Start()
    {
        damage.playerDamaged += OnPlayerDamaged;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * Speed, vertical * Speed);
        animator.SetFloat("AxeX", horizontal);
        animator.SetFloat("AxeY", vertical);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    private void OnPlayerDamaged()
    {
        transform.position = basePoint.position;    
    }

    private void OnDestroy()
    {
        damage.playerDamaged -= OnPlayerDamaged;
    }


}

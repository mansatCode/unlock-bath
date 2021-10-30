using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    [SerializeField] private float _speed = 200;

    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        transform.position = startingPosition.initalValue;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")).normalized * _speed * Time.deltaTime;

        _animator.SetFloat("moveX", _rigidBody.velocity.x);
        _animator.SetFloat("moveY", _rigidBody.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("lastMoveX", Input.GetAxis("Horizontal"));
            _animator.SetFloat("lastMoveY", Input.GetAxis("Vertical"));
        }
    }

    private void LoadInventory()
    {
        Inventory inv = gameObject.GetComponent<Inventory>();
        inv.slots = PlayerData.Instance.inventory.slots;
        inv.isFull = PlayerData.Instance.inventory.isFull;
        inv.itemButtons = PlayerData.Instance.inventory.itemButtons;
    }
}

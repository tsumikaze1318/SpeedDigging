using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private SpeedDigging _input;
    [SerializeField]
    private float _speed;
    private Vector2 _move;
    public float _holdTime;
    public bool _holding;

    // Start is called before the first frame update
    void Start()
    {
        _input = new SpeedDigging();
        _input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_holding)
        {
            _holdTime += Time.deltaTime;
        }
        Debug.Log(_holdTime.ToString("00"));
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_move.x, 0, 0) * _speed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _move = ctx.ReadValue<Vector2>();
        }
        else if (ctx.canceled)
        {
            _move = Vector2.zero;
        }
    }

    public void OnHold(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _holding = true;
            Debug.Log("’·‰Ÿ‚µ");
        }
        else
        {
            _holding = false;
            _holdTime = 0;
        }
    }

    public void OnDig(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Œ@‚é");
        }
    }
}

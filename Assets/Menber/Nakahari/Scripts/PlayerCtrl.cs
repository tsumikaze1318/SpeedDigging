using CollapseHazard;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private SpeedDigging _input;
    private PlayerInput _playerInput;
    [SerializeField]
    private float _speed;
    private Vector2 _move;
    public float _holdTime;
    public bool _holding;

    [SerializeField]
    private CollapseHazard.CollapseHazardController _collapseHazardController;
    private Animator _animatior;

    [SerializeField]
    private UIChanger _changer;

    [SerializeField]
    private Score _score;

    private const float COMPLETE_PILLAR_TIME = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _input = new SpeedDigging();
        _input.Enable();
        _animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_holding)
        {
            _holdTime += Time.deltaTime;
        }

        if (_holdTime > COMPLETE_PILLAR_TIME)
        {
            Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Cave"))
                {
                    CavePiece piece = collider.GetComponent<CavePiece>();
                    piece.SetPillar();
                    _changer.ActivatePillarUi(false);
                }
            }
        }
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
            _animatior.SetTrigger("Run");
        }
        else if (ctx.canceled)
        {
            _move = Vector2.zero;
            _animatior.SetTrigger("Idle");
            _animatior.ResetTrigger("Run");
        }
    }

    public void OnHold(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _holding = true;
            Debug.Log("長押し");
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
            Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("MineableArea"))
                {
                    CavePiece piece = collider.GetComponentInParent<CavePiece>();
                    piece.BeMined();
                    piece.LotteryEvent(_collapseHazardController.GetPresenter().Model.CurrentPercentageProperty.Value);
                    _collapseHazardController.UpdatePercentage();
                    _changer.ActivateDigUi(false);
                    _score.IncreaseScore();
                }
            }
        }
    }

    public void ActivateInput(bool active)
    {
        _playerInput.enabled = active;
    }

    public void SetAnimation(string animationName)
    {
        _animatior.SetTrigger(animationName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rock"))
        {
            GameManager.Instance._score = _score.Score_m;
            GameManager.Instance.ChangeScene(SceneType.Result);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MineableArea"))
        {
            _changer.ActivateDigUi(true);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cave"))
        {
            _changer.ActivatePillarUi(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MineableArea"))
        {
            _changer.ActivateDigUi(false);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cave"))
        {
            _changer.ActivatePillarUi(false);
        }
    }
}

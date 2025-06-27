using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _resultText;
    private PlayerInput _playerInput;

    public void OnAnyButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _playerInput.enabled = false;
            Initiate.Fade("Yokota", Color.black, 1f);
        }
    }

    public void SetScore(int score)
    {
        _playerInput ??= GetComponent<PlayerInput>();
        _playerInput.enabled = true;
        _resultText.text = score.ToString();
    }
}

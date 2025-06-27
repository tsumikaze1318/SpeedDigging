using UniRx.Triggers;
using UnityEngine;

public class CavePiece : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField]
    private Sprite[] _sprites;
    private CaveCreator _creator;
    private Collider2D _collider;

    private float _transformXFromPlayer;

    private void Start()
    {
        _renderer ??= GetComponent<SpriteRenderer>();
        _creator = GetComponentInParent<CaveCreator>();
        _collider = GetComponentInParent<Collider2D>();
    }

    private void Update()
    {
        _transformXFromPlayer = transform.position.x - _creator.TargetTransform.position.x;

        // 左の画面外に出たとき
        if (_transformXFromPlayer < 0f && !_renderer.isVisible)
        {
            // 後方に再配置
            _creator.ReplacePiece(this);
            // Spriteを土に変更
            SetSprite(PieceType.Soil);
            // 衝突判定をつける
            _collider.isTrigger = false;
        }
    }

    public void SetSprite(PieceType pieceType)
    {
        _renderer.sprite = _sprites[(int)pieceType];
    }

    public void LotteryEvent(float percentage)
    {
        float rand = Random.Range(0f, 100f);
        if (percentage > rand)
        {
            // 落石イベントを起こす
            Debug.Log("！！！落石！！！");
        }
    }

    public void BeMined()
    {
        SetSprite(PieceType.None);
        _collider.isTrigger = true;
    }
}

public enum PieceType
{
    None,
    Soil,
    Pillar
}

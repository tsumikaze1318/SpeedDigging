using UnityEngine;

public class CavePiece : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Sprite[] _sprites;

    private void Start()
    {
        _renderer ??= GetComponent<SpriteRenderer>();
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
        }
    }
}

public enum PieceType
{
    None,
    Soil,
    Pillar
}

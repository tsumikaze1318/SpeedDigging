using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CollapseHazard.CollapseHazardController _collapseHazardController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Cave"))
                {
                    CavePiece piece = collider.GetComponent<CavePiece>();
                    piece.SetSprite(PieceType.Pillar);
                    _collapseHazardController.ResetPercentage();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cave"))
        {
            CavePiece piece = collision.gameObject.GetComponent<CavePiece>();
            piece.BeMined();
            piece.LotteryEvent(_collapseHazardController.GetPresenter().Model.CurrentPercentageProperty.Value);
            _collapseHazardController.UpdatePercentage();
        }
    }
}

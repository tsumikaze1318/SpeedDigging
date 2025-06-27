using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CaveCreator : MonoBehaviour
{
    [SerializeField]
    private CavePiece _cavePiece;
    private List<CavePiece> _caveList = new List<CavePiece>();
    [SerializeField]
    private Transform _targetTransform;
    public Transform TargetTransform => _targetTransform;

    private async void Start()
    {
        await Init();
    }

    public async UniTask Init()
    {
        AsyncInstantiateOperation<CavePiece> handler
             = InstantiateAsync(_cavePiece, 5, transform);

        await handler;

        int i = 0;
        foreach (CavePiece cavePiece in handler.Result)
        {
            _caveList.Add(cavePiece);
            cavePiece.transform.position = new Vector3(i * 5, 0, 0);
            i++;
        }
    }

    public void ReplacePiece(CavePiece cavePiece)
    {
        _caveList.Remove(cavePiece);
        cavePiece.transform.position = _caveList[^1].transform.position + Vector3.right * 5;
        _caveList.Add(cavePiece);
    }
}

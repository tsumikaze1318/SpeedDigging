using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CaveCreator : MonoBehaviour
{
    [SerializeField]
    private CavePiece _cavePiece;
    private Queue<CavePiece> _cavesQueue = new Queue<CavePiece>();

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
            _cavesQueue.Enqueue(cavePiece);
            cavePiece.transform.position = new Vector3(i * 5, 0, 0);
            i++;
        }
    }
}

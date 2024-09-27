using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitaskCancellationExample : MonoBehaviour
{
    CancellationTokenSource cts = new CancellationTokenSource();
    private void Start()
    {
        // Invoca il metodo asincrono con il token di cancellazione
        MetodoAsincrono(cts.Token).Forget();
        MetodoAsincronoVoid(cts.Token).Forget();
    }

    async UniTask MetodoAsincrono(CancellationToken token)
    {
        await UniTask.WaitWhile(() => !token.IsCancellationRequested);
        Debug.Log("Cancellazione avviata");
    }

    async UniTaskVoid MetodoAsincronoVoid(CancellationToken token)
    {
        Debug.Log("Cancellazione non avviata");
        await UniTask.Delay(1000);
        cts.Cancel();
    }
}

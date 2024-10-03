using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitaskExample : MonoBehaviour
{
    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    void Start()
    {
        // Invoca il metodo asincrono con il token di cancellazione
        MetodoAsincrono(_cancellationTokenSource.Token).Forget();
        MetodoAsincronoVoid(_cancellationTokenSource.Token).Forget();

        MetodoAsincrono(_cancellationTokenSource.Token).Forget();
    }

    async UniTaskVoid StartUniTask()
    {

        // EsempioUniTask().Forget();

        _cancellationTokenSource = new CancellationTokenSource();

        string stringa = await GetRemoteData("https://example.com/data");   
    
        Debug.Log(stringa);
    }

    async UniTask MetodoAsincrono(CancellationToken token)
    {
        // await UniTask.WaitWhile(() => !token.IsCancellationRequested);

        await UniTask.WaitUntil(() => token.IsCancellationRequested);

        // while(true)
        // {
        //     if(token.IsCancellationRequested)
        //     {
        //         break;
        //     }

        //     Debug.Log("Cancellazione in corso");

        //     await UniTask.WaitForFixedUpdate();
        // }

        // try
        // {
        //     token.ThrowIfCancellationRequested();

        //     Debug.Log("Cancellazione in corso");
        // }
        // catch (OperationCanceledException)
        // {
        //     Debug.Log("Cancellazione interrotta");
        // }

        // Debug.Log("Cancellazione avviata");
    }

    async UniTask MetodoAsincronoVoid(CancellationToken token)
    {
        Debug.Log("Cancellazione non avviata");
        await UniTask.Delay(1000);
        _cancellationTokenSource.Cancel();
    }

    async UniTask<int> MetodoAsincronoInt(CancellationToken token)
    {
        await UniTask.Delay(1000);
        return 5;   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _cancellationTokenSource.Cancel();
        }
    }

    private async UniTask<string> GetRemoteData(string url)
    {
        Debug.Log("Getting data from " + url);

        await UniTask.Delay(1000);

        return "HELLO WORLD!";
    }
}

public class UniTaskExample : MonoBehaviour
{
    public int waitSeconds = 5;
    private async UniTask EsempioUniTask()
    {
        Debug.Log("Inizio EsempioUniTask");

        await UniTask.Delay(waitSeconds * 1000);

        Debug.Log("Fine EsempioUniTask");
    }
}

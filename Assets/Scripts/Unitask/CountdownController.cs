using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CountdownController : MonoBehaviour
{
    public Text countdownText;
    public Button startButton;
    public Button cancelButton;

    private CancellationTokenSource cts;

    void Start()
    {
        // Assegna i listener ai pulsanti
    }

    void StartCountdown()
    {
        // Inizializza il CancellationTokenSource
        cts = new CancellationTokenSource();

        // Avvia il conto alla rovescia
        CountdownAsync(cts.Token).Forget();
    }

    private async UniTask CountdownAsync(CancellationToken token)
    {
        // Implementa il conto alla rovescia asincrono
        await UniTask.Delay(5000, cancellationToken: token);
    }

    private void CancelCountdown()
    {
        // Richiedi la cancellazione dell'operazione
        cts.Cancel();
    }

    private void OnDestroy()
    {
        // Pulisci le risorse
        cts?.Dispose();
    }
}


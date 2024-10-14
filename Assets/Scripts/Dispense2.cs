using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System;

public class Dispense2 : MonoBehaviour 
{
    void Start()
    {
        UniTask.Create(async () => await TestCreate());
    }

    public async  UniTask TestCreate()
    {
        await UniTask.SwitchToThreadPool();
        Debug.Log("Inizio TestCreate SwitchToThreadPool");
        
        await UniTask.Delay(1000);

        await UniTask.SwitchToMainThread();
        Debug.Log("Fine TestCreate SwitchToMainThread");
    }
}



public class UnityActionExample : MonoBehaviour
{
    private UnityAction action;

    void Start()
    {
        action = MethodToCall;
        action.Invoke();
    }

    void MethodToCall()
    {
        Debug.Log("UnityAction Invoke!");
    }
}


public class UnityEventExample : MonoBehaviour
{
    public UnityEvent customEvent;

    void Start()
    {
        if (customEvent != null)
        {
            customEvent.Invoke();
        }
    }
}



public class CaricamentoScena : MonoBehaviour
{
    void Start()
    {
        CaricaScenaAsincrona().Forget();
    }

    async UniTask CaricaScenaAsincrona()
    {
        // Mostra una schermata di caricamento
        Debug.Log("Inizio caricamento scena...");

        // Carica la scena in background
        await SceneManager.LoadSceneAsync("NomeScena");

        // Nasconde la schermata di caricamento
        Debug.Log("Caricamento completato!");
    }
}

public class GetData : MonoBehaviour
{
    void Start()
    {
        GetDataAsync().Forget();
    }

    private async UniTask GetDataAsync()
    {
        string url = "https://example.com/data";
        string data = await GetRemoteData(url);
        Debug.Log(data);
    }

    private async UniTask<string> GetRemoteData(string url)
    {
        Debug.Log("Getting data from " + url);
        await UniTask.Delay(1000);
        return "HELLO WORLD!";
    }

    
}

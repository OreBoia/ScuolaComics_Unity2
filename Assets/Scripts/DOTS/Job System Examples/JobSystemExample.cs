using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobSystemExample : MonoBehaviour
{
    // Definiamo un array nativo per memorizzare i risultati
    private NativeArray<int> results;

    void Start()
    {
        // Inizializziamo un array di interi
        results = new NativeArray<int>(10, Allocator.TempJob); //spiegare altri tipi di allocatori

        // Creiamo un job
        SimpleJob job = new SimpleJob
        {
            numbers = results
        };

        // Programmiamo il job e lo mettiamo in esecuzione
        JobHandle handle = job.Schedule();

        // Aspettiamo che il job venga completato
        handle.Complete();

        // Stampiamo i risultati
        for (int i = 0; i < results.Length; i++)
        {
            Debug.Log("Result " + i + ": " + results[i]);
        }

        // Rilasciamo la memoria allocata per l'array
        results.Dispose();
    }

    // Definizione del job
    [BurstCompile] // Facoltativo, ottimizza il job con il Burst Compiler
    struct SimpleJob : IJob
    {
        public NativeArray<int> numbers;

        // Metodo Execute dove si svolge la logica del job
        public void Execute()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 10; // Operazione semplice per dimostrare il concetto
            }
        }
    }
}

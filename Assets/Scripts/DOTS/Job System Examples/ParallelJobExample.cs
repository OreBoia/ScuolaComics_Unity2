using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class ParallelJobExample : MonoBehaviour
{
    private NativeArray<int> results;
    
    void Start()
    {
        results = new NativeArray<int>(100, Allocator.TempJob);

        // Creiamo un job parallelo
        ParallelJob job = new ParallelJob
        {
            numbers = results //puntano allo stesso NativeArray
        };

        // Scheduliamo il job parallelo per 100 iterazioni
        JobHandle handle = job.Schedule(results.Length, 10);

        // Aspettiamo che il job sia completato
        handle.Complete();

        // Stampiamo i risultati
        for (int i = 0; i < results.Length; i++)
        {
            Debug.Log("Result " + i + ": " + results[i]);
        }

        results.Dispose();
    }

    // Definizione del job parallelo
    [BurstCompile] // Migliora le prestazioni del job
    struct ParallelJob : IJobParallelFor
    {
        public NativeArray<int> numbers;

        public void Execute(int index)
        {
            numbers[index] = index * 2; // Operazione su ciascun elemento in parallelo
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnityMainThreadDispatcher : MonoBehaviour {
    private static readonly Queue<Func<Task>> _executionQueue = new();
    private static UnityMainThreadDispatcher? _instance;
    // Non-async Enqueue
    public static void Enqueue(Action action) {
        CreateDispatcher();
        lock (_executionQueue) {
            _executionQueue.Enqueue(() => {
                action();
                return Task.CompletedTask; // Support Task compatibility
            });
        }
    }

    // Enqueue async methods with result (no need for lambda)
    public static Task<T> EnqueueAsync<T>(Func<Task<T>> action) {
        var tcs = new TaskCompletionSource<T>();

        Enqueue(() => {
            ExecuteAsync(action, tcs); // Handle async execution
        });

        return tcs.Task; // Return the Task directly
    }

    // Enqueue async methods without results
    public static Task EnqueueAsync(Func<Task> action) {
        var tcs = new TaskCompletionSource<bool>();

        Enqueue(() => {
            ExecuteAsync(action, tcs); // Handle async execution
        });

        return tcs.Task; // Return the Task directly
    }

    // Internal execution wrappers
    private static async void ExecuteAsync(Func<Task> action, TaskCompletionSource<bool> tcs) {
        try {
            await action();
            tcs.SetResult(true);
        }
        catch (Exception ex) {
            tcs.SetException(ex);
        }
    }

    private static async void ExecuteAsync<T>(Func<Task<T>> action, TaskCompletionSource<T> tcs) {
        try {
            var result = await action();
            tcs.SetResult(result);
        }
        catch (Exception ex) {
            tcs.SetException(ex);
        }
    }


    private static void CreateDispatcher() {
        if (_instance == null) {
            var obj = new GameObject("MainThreadDispatcher");
            _instance = obj.AddComponent<UnityMainThreadDispatcher>();
            DontDestroyOnLoad(obj);
        }
    }

    private void Update() {
        lock (_executionQueue) {
            while (_executionQueue.Count > 0) {
                var action = _executionQueue.Dequeue();
                action.Invoke(); // Execute tasks
            }
        }
    }
}

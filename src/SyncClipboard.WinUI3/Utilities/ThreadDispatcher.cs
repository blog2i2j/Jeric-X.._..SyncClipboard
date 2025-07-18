﻿using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using SyncClipboard.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace SyncClipboard.WinUI3.Utilities;

internal class ThreadDispatcher(DispatcherQueue dispatcherQueue) : IThreadDispatcher
{
    public Task<T> RunOnMainThreadAsync<T>(Func<Task<T>> func)
    {
        if (dispatcherQueue.HasThreadAccess)
        {
            return func.Invoke();
        }
        return dispatcherQueue.EnqueueAsync(func);
    }

    public Task RunOnMainThreadAsync(Func<Task> func)
    {
        if (dispatcherQueue.HasThreadAccess)
        {
            return func.Invoke();
        }
        return dispatcherQueue.EnqueueAsync(func);
    }
}

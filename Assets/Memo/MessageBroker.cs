using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace TT2023.Common
{
    public interface IMessagePublisher<T>
    {
        void Publish(T message);
    }

    public interface IMessageReceiver<T>
    {
        IObservable<T> Receive();
    }

    // pub/sub‹¤’Ê
    public interface IMessageBroker<T> : IMessagePublisher<T>, IMessageReceiver<T>
    {
        public class DefaultImpl : IMessageBroker<T>
        {
            private readonly IMessageBroker _service;
            public DefaultImpl(IMessageBroker service) => _service = service;
            public void Publish(T message) => _service.Publish(message);
            public IObservable<T> Receive() => _service.Receive<T>();
        }
    }

    public static class MessageBrokerExtensions
    {
        // pub‚ÌŽæ“¾
        public static IMessagePublisher<T> GetPublisher<T>(this IMessageBroker self)
        {
            return new IMessageBroker<T>.DefaultImpl(self);
        }
        public static IMessageReceiver<T> GetSubscriber<T>(this IMessageBroker self)
        {
            return new IMessageBroker<T>.DefaultImpl(self);
        }
        public static IDisposable Subscribe<T>(this IMessageReceiver<T> self, Action<T> action)
        {
            return self.Receive().Subscribe(action);
        }
    }
}
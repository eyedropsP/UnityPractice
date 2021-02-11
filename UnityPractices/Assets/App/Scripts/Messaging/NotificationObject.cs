using System;
using UnityEngine.Events;

namespace App.Scripts.Messaging
{
	[Serializable]
	public class NotificationObject<T> : IDisposable
	{
		public UnityEvent<T> Action;
		
		private T data;
		
		public NotificationObject(T t) => Value = t;
		
		public NotificationObject() { }
		
		~NotificationObject() => Dispose();
		
		public T Value
		{
			get => data;
			set
			{
				data = value;
				Notice();
			}
		}
		
		private void Notice() => Action?.Invoke(data);

		public void Dispose()
		{
			Action = null;
			GC.SuppressFinalize(this);
		}
	}
}
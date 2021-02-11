using UnityEngine;

namespace App.Scripts.Messaging
{
	public class Messenger : MonoBehaviour
	{
		public NotificationObject<string> NotificationObject = new NotificationObject<string>();

		private void Start()
		{
			NotificationObject.Action.AddListener(print);
		}

		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Space)) return;
			NotificationObject.Value = "うんち";
		}

		private void OnDestroy()
		{
			NotificationObject.Dispose();
		}
	}
}
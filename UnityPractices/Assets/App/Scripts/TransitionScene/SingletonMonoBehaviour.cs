using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour 
		where T : MonoBehaviour
	{
		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance != null) return instance;
				var t = typeof(T);
				instance = (T) FindObjectOfType(t);

				return instance;
			}
		}
		
		public static bool HasInstance => Instance != null;

		protected virtual void Awake()
		{
			if (this == Instance) return;
			Destroy(this);
		}

		protected virtual void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}
	}
}
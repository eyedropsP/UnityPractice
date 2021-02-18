using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public static class SceneLoader
	{
		private static TransitionManager transitionManager;

		private static TransitionManager TransitionManager
		{
			get
			{
				if(transitionManager != null)
				{
					return transitionManager;
				}

				Initialize();
				return transitionManager;
			}
		}

		public static void Initialize()
		{
			if (TransitionManager.Instance != null) return;
			var resource = Resources.Load("Prefabs/TransitionManager");
			Object.Instantiate(resource);

			transitionManager = TransitionManager.Instance;
		}

		public static bool IsTransitionRunning => TransitionManager.IsRunning;

		public static void LoadScene(GameScenes scene, GameScenes[] additiveLoadScenes = null)
		{
			TransitionManager.StartTransaction(scene, additiveLoadScenes);
		}
	}
}
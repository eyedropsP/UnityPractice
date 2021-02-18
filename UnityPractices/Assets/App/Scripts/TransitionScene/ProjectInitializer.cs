using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public static class ProjectInitializer
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			bool useDebugSystem;

#if DEBUG
			useDebugSystem = false;
#endif

			if (useDebugSystem)
			{
			}
			else
			{
				
			}
		}
	}
}
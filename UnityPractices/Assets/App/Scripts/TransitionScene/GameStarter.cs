using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public class GameStarter : MonoBehaviour
	{
		private void Start()
		{
			Locator.Register<IFade, FadeScreen>();
		}

		private void Update()
		{
			
		}
	}
}
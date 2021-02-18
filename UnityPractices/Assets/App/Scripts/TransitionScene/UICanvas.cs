using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public class UICanvas : MonoBehaviour
	{
		[SerializeField] private Fade fade;
		[SerializeField] private FadeImage image;
		public Fade Fade => fade;
		public FadeImage FadeImage => image;
	}
}
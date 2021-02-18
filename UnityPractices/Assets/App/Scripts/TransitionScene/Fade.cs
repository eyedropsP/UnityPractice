using System;
using System.Collections;
using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public class Fade : MonoBehaviour
	{
		private IFade fade;

		private void Start()
		{
			Init();
			fade.Range = cutoutRange;
		}

		private float cutoutRange;

		private void Init()
		{
			fade = GetComponent<IFade>();
			fade = Locator.Resolve<IFade>();
		}

		private void OnValidate()
		{
			Init();
			fade.Range = cutoutRange;
		}

		private IEnumerator FadeoutCoroutine(float time, Action action)
		{
			var endTime = Time.timeSinceLevelLoad + time * (cutoutRange);
			var endFrame = new WaitForEndOfFrame();

			while (endTime >= Time.timeSinceLevelLoad)
			{
				fade.Range = cutoutRange = (endTime - Time.timeSinceLevelLoad) / time;
				yield return endFrame;
			}

			fade.Range = cutoutRange = 0;
			action?.Invoke();
		}

		private IEnumerator FadeinCoroutine(float time, Action action)
		{
			var endTime = Time.timeSinceLevelLoad + time * (1 - cutoutRange);
			var endFrame = new WaitForEndOfFrame();

			while (endTime >= Time.timeSinceLevelLoad)
			{
				fade.Range = cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
				yield return endFrame;
			}

			fade.Range = cutoutRange = 1;
			action?.Invoke();
		}

		public Coroutine FadeOut(float time, Action action)
		{
			StopAllCoroutines();
			return StartCoroutine(FadeoutCoroutine(time, action));
		}

		public Coroutine FadeIn(float time, Action action)
		{
			StopAllCoroutines();
			return StartCoroutine(FadeinCoroutine(time, action));
		}
		
		public Coroutine FadeOut(float time) => FadeOut(time, null);
		public Coroutine FadeIn(float time) => FadeIn(time, null);
	}
}
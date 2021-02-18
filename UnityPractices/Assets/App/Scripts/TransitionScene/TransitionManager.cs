using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.TransitionScene
{
	public class TransitionManager : SingletonMonoBehaviour<TransitionManager>
	{
		// 蓋絵のアニメーションを実行中か
		private bool isFading;

		// アクティブなシーンが切り替わったか
		private bool isSwitchedScene;
		
		[SerializeField] UICanvas uiCanvas;
		
		public static UICanvas UI => Instance.uiCanvas;
		public GameScenes CurrentGameScene { get; private set; }
		// シーン繊維処理実行中フラグ
		public bool IsRunning { get; private set; }

		protected override void Awake()
		{
			DontDestroyOnLoad(gameObject);

			try
			{
				CurrentGameScene = (GameScenes)Enum.Parse(typeof(GameScenes), SceneManager.GetActiveScene().name, false);
			}
			catch (Exception)
			{
				CurrentGameScene = GameScenes.Title;
			}

			SceneManager.activeSceneChanged += (arg0, scene) => isSwitchedScene = true;
		}

		private void TransitionReset()
		{
			IsRunning = false;
			isFading = false;
			isSwitchedScene = false;
			UI.FadeImage.raycastTarget = false;
		}

		public void StartTransaction(GameScenes nextScene, GameScenes[] additiveLoadScenes)
		{
			if (IsRunning) return;
			TransitionReset();
			StartCoroutine(TransitionCoroutine(nextScene, additiveLoadScenes));
		}

		private IEnumerator TransitionCoroutine(GameScenes nextScene, GameScenes[] additiveLoadScenes)
		{
			IsRunning = true;
			UI.FadeImage.raycastTarget = true;

			isFading = true;
			UI.Fade.FadeIn(1f, () => isFading = false);

			while (isFading)
			{
				yield return null;
			}

			SceneManager.LoadSceneAsync(nextScene.ToString());

			if (additiveLoadScenes == null) yield break;
			foreach (var item in additiveLoadScenes)
			{
				SceneManager.LoadSceneAsync(item.ToString(), LoadSceneMode.Additive);
			}

			Resources.UnloadUnusedAssets();
			GC.Collect();
			yield return null;

			CurrentGameScene = nextScene;

			while (!isSwitchedScene)
			{
				yield return null;
			}

			isFading = true;
			UI.Fade.FadeOut(1f, () => isFading = false);
			TransitionReset();
		}
	}
}
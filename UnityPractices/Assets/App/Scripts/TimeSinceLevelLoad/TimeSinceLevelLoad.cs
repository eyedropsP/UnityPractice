using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace App.Scripts.TimeSinceLevelLoad
{
	public class TimeSinceLevelLoad : MonoBehaviour
	{
		public Button button;
		public Text text;

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
			
			DontDestroyOnLoad(GameObject.Find("Canvas"));

			if (button == null) return;
			button.onClick.AddListener(LoadSceneButton);
		}

		private void Update()
		{
			text.text = $"Time Since Loaded : {Time.timeSinceLevelLoad:0000}";
		}

		private static void LoadSceneButton()
		{
			SceneManager.LoadSceneAsync("Scene2");
		}
	}
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.SceneReference.Scripts
{
	[CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Database")]
	public class ScenesData : ScriptableObject
	{
		public List<Level> Levels = new List<Level>();
		public List<Menu> Menus = new List<Menu>();
		public int CurrentLevelIndex = 1;

		public void LoadLevelWithIndex(int index)
		{
			if (index <= Levels.Count)
			{
				// レベルに対応したGamePlayシーンを読み込む
				SceneManager.LoadSceneAsync("Gameplay" + index.ToString());
				// 追加モードでレベルの最初のパートを読み込む
				SceneManager.LoadSceneAsync("Level" + index.ToString() + "Part1", LoadSceneMode.Additive);
			}
			else
			{
				CurrentLevelIndex = 1;
			}
		}

		public void NextLevel()
		{
			CurrentLevelIndex++;
			LoadLevelWithIndex(CurrentLevelIndex);
		}

		public void RestartLevel()
		{
			LoadLevelWithIndex(CurrentLevelIndex);
		}

		public void NewGame()
		{
			LoadLevelWithIndex(1);
		}

		public void LoadMainMenu()
		{
			SceneManager.LoadSceneAsync(Menus[(int) Type.MainMenu].sceneName);
		}

		public void LoadPauseMenu()
		{
			SceneManager.LoadSceneAsync(Menus[(int) Type.PauseMenu].sceneName);
		}
	}
}
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace App.Scripts.SceneReferenceTest.Scripts
{
	public class GameScene : ScriptableObject
	{
		[Header("Information")] public string sceneName;
		public string shortDescription;

		[Header("Sounds")] public AudioClip music;
		[Range(0.0f, 1.0f)] public float musicVolume;
		public PostProcessProfile postprocess;
	}
}
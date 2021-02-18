using App.Scripts.SceneReferenceTest.Scripts;
using UnityEngine;

namespace App.Scripts.SceneReference.Scripts
{
	[CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
	public class Level : GameScene
	{ 
		// レベルのみに固有の設定
		[Range(0, 100)]
		[Header("Level specific")] public int enemiesCount;
	}
}
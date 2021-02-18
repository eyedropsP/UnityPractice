using App.Scripts.SceneReferenceTest.Scripts;
using UnityEngine;

namespace App.Scripts.SceneReference.Scripts
{
	[CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
	public class Menu : GameScene
	{
		[Header("Menu specific")] public Type type;
	}
}
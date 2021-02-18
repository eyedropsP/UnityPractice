using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.TimeSinceLevelLoad
{
	public class CurrentTimeSinceLevelLoad : MonoBehaviour
	{
		public Button Button;
		public Text TimeText;

		private void Awake()
		{
			Button.onClick.AddListener(CurrentTime);
			TimeText.text = "Click Button";
		}

		private void CurrentTime()
		{
			TimeText.text = $"TimeSinceLevelLoad : {Time.timeSinceLevelLoad}";
		}
	}
}
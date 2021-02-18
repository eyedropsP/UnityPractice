using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public class FadeImage : UnityEngine.UI.Graphic, IFade
	{
		[SerializeField] private Texture maskTexture;
		[SerializeField, Range(0, 1)] private float cutoutRange;

		private static readonly int Color = Shader.PropertyToID("_Color");
		private static readonly int MaskTex = Shader.PropertyToID("_MaskTex");
		private static readonly int Range1 = Shader.PropertyToID("_Range");

		public float Range
		{
			get => cutoutRange;
			set
			{
				cutoutRange = value;
				UpdateMaskCutout();
			}
		}

		protected override void Start()
		{
			base.Start();
			UpdateMaskTexture();
		}

		public void UpdateMaskTexture()
		{
			material.SetTexture(MaskTex, maskTexture);
			material.SetColor(Color, color);
		}

		private void UpdateMaskCutout()
		{
			enabled = true;
			material.SetFloat(Range1, 1 - Range);

			if (Range <= 0)
			{
				enabled = false;
			}
		}

#if UNITY_EDITOR
		protected override void OnValidate()
		{
			base.OnValidate();
			UpdateMaskCutout();
			UpdateMaskTexture();
		}
#endif
	}
}
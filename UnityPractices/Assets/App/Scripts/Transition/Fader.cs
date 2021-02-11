using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Transition
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        [Range(0.001f, 1f)]
        [SerializeField] private float transitionRatio = 0.01f;

        private void Start()
        {
            image.color = new Color(0, 0, 0, 0);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.T)) return;
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            image.enabled = true;

            var color = image.color;

            while (color.a <= 1f)
            {
                // 1フレーム待つ
                yield return null;

                color.a += transitionRatio;
                image.color = color;
            }

            color.a = 1;
            image.color = color;
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            var color = image.color;

            while (color.a >= 0f)
            {
                yield return null;

                color.a -= transitionRatio;
                image.color = color;
            }

            color.a = 0;
            image.color = color;
            image.enabled = false;
        }
    }
}

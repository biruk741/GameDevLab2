using System.Collections;
using UnityEngine;

namespace KingdomOfNight
{
    public class WorldSpriteLoop : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Sprite[] sprites;
        public float fps;
        public bool randomStart = false;

        private Coroutine animateRoutine = null;
        private void OnEnable()
        {
            OnDisable();
            animateRoutine = StartCoroutine(Co_Animate());
        }

        private void OnDisable()
        {
            if(animateRoutine != null)
            {
                StopCoroutine(animateRoutine);
                animateRoutine = null;
            }
        }

        IEnumerator Co_Animate()
        {
            yield return null;
            yield return null;
            yield return null;
            float timePerFrame = 1f / fps;
            if (randomStart)
            {
                float waitTime = Random.Range(0f, timePerFrame * 3.5f);
                yield return new WaitForSeconds(waitTime);
            }

            while (true)
            {
                for (int i = 0; i < sprites.Length; i++)
                {
                    spriteRenderer.sprite = sprites[i];
                    float elapsedTime = 0;
                    while (elapsedTime < timePerFrame)
                    {
                        elapsedTime += Time.unscaledDeltaTime; //WaitForSecondsRealtime can't be used without creating garbage every time it's used.
                        yield return null;
                    }
                }
            }
        }
    }
}

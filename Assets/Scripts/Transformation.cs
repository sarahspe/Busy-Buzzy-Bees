using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transformation : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Sprite initialSprite;
    [SerializeField] private Sprite transformedSprite;
    private float flashDuration = 4.0f;
    private float flashInterval = 0.1f;
    private float startDelay = 3.0f;
    private float fadeDuration = 1.0f;
    private Vector3 transformedScale = new Vector3(1.6f, 1.6f, 1.6f);

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on targetObject.");
            return;
        }

        originalScale = targetObject.transform.localScale;
        originalColor = spriteRenderer.color;

        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        // Wait for the start delay
        yield return new WaitForSeconds(startDelay);

        // Fade to black
        yield return StartCoroutine(FadeToColor(Color.black, fadeDuration));

        // Start the evolution animation
        yield return StartCoroutine(EvolutionAnimation());

        // Fade back to the original color
        yield return StartCoroutine(FadeToColor(originalColor, fadeDuration));

        // Wait for 3 seconds before transitioning to the new scene
        yield return new WaitForSeconds(3.0f);

        // Transition to the new scene
        SceneManager.LoadScene("Level 3 - Flappy Bird");
    }

    private IEnumerator EvolutionAnimation()
    {
        float elapsedTime = 0f;
        bool showingInitialSprite = true;

        // Keep the sprite fully black during the animation
        spriteRenderer.color = Color.black;

        while (elapsedTime < flashDuration)
        {
            if (showingInitialSprite)
            {
                spriteRenderer.sprite = initialSprite;
                targetObject.transform.localScale = originalScale;
            }
            else
            {
                spriteRenderer.sprite = transformedSprite;
                targetObject.transform.localScale = transformedScale;
            }

            showingInitialSprite = !showingInitialSprite;
            yield return new WaitForSeconds(flashInterval);
            elapsedTime += flashInterval;
        }

        // Ensure the final sprite is the transformed one
        spriteRenderer.sprite = transformedSprite;
        targetObject.transform.localScale = transformedScale;
    }

    private IEnumerator FadeToColor(Color targetColor, float duration)
    {
        Color startColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHighlightFlasher : MonoBehaviour
{
    public Image targetImage; // Assign this in the inspector
    public float flashDuration = 1f; // Duration of one flash cycle (fade in and fade out)
    public float maxAlpha = 0.8f; // Maximum alpha value to reach
    public float minAlpha = 0.2f; // Minimum alpha value to start from

    public void RunFlashEffect()
    {
        // Start the flashing effect when triggered
        if (targetImage != null)
        {
            StartCoroutine(FlashEffect());
        }
    }

    private IEnumerator FlashEffect()
    {
        // Fade in
        float halfDuration = flashDuration / 2;
        for (float t = 0; t <= halfDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / halfDuration;
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, Mathf.Lerp(minAlpha, maxAlpha, normalizedTime));
            yield return null;
        }

        // Set to maxAlpha explicitly to avoid any precision errors.
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, maxAlpha);

        // Fade out
        for (float t = 0; t <= halfDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / halfDuration;
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, Mathf.Lerp(maxAlpha, minAlpha, normalizedTime));
            yield return null;
        }

        // Ensure it ends with minAlpha
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, minAlpha);
    }
}

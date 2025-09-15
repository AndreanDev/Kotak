using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    private TextMeshProUGUI tmpText;
    public float fadeSpeed = 1f;
    public float moveSpeed = 20f; // pixels per second

    private bool isFading = false;
    private Vector3 originalPosition;
    private RectTransform rectTransform;

    // void Awake()
    // {
    //     tmpText = GetComponent<TextMeshProUGUI>();
    //     rectTransform = GetComponent<RectTransform>();
    //     if (rectTransform != null)
    //     {
    //         originalPosition = rectTransform.anchoredPosition;
    //         StartFade();
    //     }
    // }

    void OnEnable()
    {
        if (tmpText == null)
            tmpText = GetComponent<TextMeshProUGUI>();
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        originalPosition = rectTransform.anchoredPosition;
        StartFade(); // Or ShowAndFade() depending on what behavior you want
    }

    void Update()
    {
        if (isFading && tmpText != null)
        {
            // Fade
            Color color = tmpText.color;
            color.a -= fadeSpeed * Time.deltaTime;
            tmpText.color = color;

            // Move Up
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition += new Vector2(0f, moveSpeed * Time.deltaTime);
            }

            // Check if done fading
            if (color.a <= 0f)
            {
                tmpText.color = color;
                isFading = false;

                color.a = 255f;

                // Reset position
                if (rectTransform != null)
                    rectTransform.anchoredPosition = originalPosition;

                gameObject.SetActive(false);
            }
        }
    }

    public void StartFade()
    {
        if (tmpText == null)
            tmpText = GetComponent<TextMeshProUGUI>();
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        // Reset alpha
        Color color = tmpText.color;
        color.a = 1f;
        tmpText.color = color;

        // Reset position
        rectTransform.anchoredPosition = originalPosition;

        isFading = true;
        gameObject.SetActive(true);
    }

    public void ShowAndFade()
    {
        if (tmpText == null)
            tmpText = GetComponent<TextMeshProUGUI>();
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        gameObject.SetActive(true);

        // Reset alpha
        Color color = tmpText.color;
        color.a = 1f;
        tmpText.color = color;

        // Reset position
        rectTransform.anchoredPosition = originalPosition;

        isFading = true;
    }
}

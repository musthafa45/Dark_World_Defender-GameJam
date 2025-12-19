using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour {
    [SerializeField] private Image healthUiImage;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private float hideDelay = 5f;

    private int maxHealth;
    private int lastHealth;
    private float timer;
    private bool shouldFade;

    private IHealth iHealth;

    private void Awake() {
        iHealth = transform.root.GetComponent<IHealth>();
        maxHealth = iHealth.GetMaxHealth();
        lastHealth = iHealth.GetCurrentHealth();

        canvasGroup.alpha = 1f;
    }

    private void Update() {
        int currentHealth = iHealth.GetCurrentHealth();
        UpdateHealth(currentHealth);

        // Detect health change
        if (currentHealth != lastHealth) {
            lastHealth = currentHealth;
            timer = 0f;
            shouldFade = false;
            canvasGroup.alpha = 1f; // instantly show UI again
        }
        else {
            timer += Time.deltaTime;

            if (timer >= hideDelay)
                shouldFade = true;
        }

        // Fade logic
        if (shouldFade) {
            canvasGroup.alpha = Mathf.Lerp(
                canvasGroup.alpha,
                0f,
                Time.deltaTime * fadeSpeed
            );
        }
    }

    private void UpdateHealth(int currentHealth) {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthUiImage.fillAmount = healthPercentage;
    }
}

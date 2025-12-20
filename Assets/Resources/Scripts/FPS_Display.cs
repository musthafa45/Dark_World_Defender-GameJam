using UnityEngine;

public class FPS_Display : MonoBehaviour
{
    public bool isOn = false;

    float deltaTime = 0.0f;

    void Update() {
        if (isOn)
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    public void SetIsOn(bool value) {
        this.isOn = value;
    }

    public bool IsOn() => isOn;

    void OnGUI() {
        if (isOn) {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = Color.white;

            float msec = deltaTime * 1000.0f;
            float fps = (deltaTime > 0f) ? 1.0f / deltaTime : 0f;

            // Clamp and format FPS
            int clampedFps = Mathf.Clamp(Mathf.RoundToInt(fps), 0, 999);
            string text = string.Format("{0:000} fps", clampedFps);

            GUI.Label(rect, text, style);
        }
    }
}

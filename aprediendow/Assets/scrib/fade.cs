using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public DatosGlobales datosGlobales;
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    private void Start()
    {
        alpha = 0f; // Comenzar con la pantalla visible
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Mathf.Clamp01(Curve.Evaluate(time));
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();

            if (time <= 0f || time >= 1f)
                direction = 0; // Detener la transición al final del fade
        }
    }

    private void OnGUI()
    {
        if (alpha > 0f)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
    }

    // Métodos públicos para iniciar el fade
    public void StartFadeIn()
    {
        direction = -1;
        time = 1f;
    }

    public void StartFadeOut()
    {
        direction = 1;
        time = 0f;
    }

    public IEnumerator FadeAndExecute(System.Action action)
    {
        StartFadeOut();
        yield return new WaitUntil(() => direction == 0); // Esperar a que termine el fade out
        action?.Invoke();
        StartFadeIn();
        yield return new WaitUntil(() => direction == 0); // Esperar a que termine el fade in
    }
}

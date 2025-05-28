using UnityEngine;

public class CamaraLenta : MonoBehaviour
{
    [Tooltip("Factor de cámara lenta (1 = normal, 0.5 = mitad de velocidad, etc.)")]
    [Range(0f, 1f)]
    public float velocidadLenta = 0.2f;

    void Start()
    {
        Time.timeScale = velocidadLenta;
        Time.fixedDeltaTime = velocidadLenta * Time.timeScale;
    }
}

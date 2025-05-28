using UnityEngine;

public class RafagaDisparo : MonoBehaviour
{
    [Tooltip("Frecuencia de parpadeo en ráfagas por segundo")]
    public float frecuenciaPorSegundo = 5f;

    private float intervalo;
    private float temporizador;

    private MeshRenderer meshRenderer;
    private Light luz;

    void Start()
    {
        intervalo = 1f / frecuenciaPorSegundo;
        temporizador = 0f;

        meshRenderer = GetComponent<MeshRenderer>();
        luz = GetComponent<Light>();
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= intervalo)
        {
            if (meshRenderer != null)
                meshRenderer.enabled = !meshRenderer.enabled;

            if (luz != null)
                luz.enabled = !luz.enabled;

            temporizador = 0f;
        }
    }
}

using UnityEngine;

public class RayosTormenta : MonoBehaviour
{
    public int numeroDestellos = 3;
    public float velocidadDestellos = 10f; // en parpadeos por segundo
    public float tiempoEspera = 2f;

    private float intervalo;
    private float temporizador;
    private int destellosRealizados;
    private bool enEspera;

    private MeshRenderer meshRenderer;
    private Light luz;

    void Start()
    {
        intervalo = 1f / velocidadDestellos;
        temporizador = 0f;
        destellosRealizados = 0;
        enEspera = false;

        meshRenderer = GetComponent<MeshRenderer>();
        luz = GetComponent<Light>();
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        if (enEspera)
        {
            if (temporizador >= tiempoEspera)
            {
                temporizador = 0f;
                destellosRealizados = 0;
                enEspera = false;
            }
            return;
        }

        if (temporizador >= intervalo)
        {
            if (meshRenderer != null)
                meshRenderer.enabled = !meshRenderer.enabled;

            if (luz != null)
                luz.enabled = !luz.enabled;

            temporizador = 0f;
            destellosRealizados++;

            if (destellosRealizados >= numeroDestellos * 2) // *2 porque cada destello implica on/off
            {
                enEspera = true;
            }
        }
    }
}

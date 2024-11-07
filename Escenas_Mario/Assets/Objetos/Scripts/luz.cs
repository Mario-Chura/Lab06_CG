using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luz : MonoBehaviour
{
    // Variable booleana para controlar si la luz está titilando o no
    public bool titila = false;
    // Variable que almacena el tiempo de espera entre los parpadeos
    public float timeDelay;

    // Update se ejecuta una vez por frame
    void Update()
    {
        // Si la luz no está titilando, inicia la corrutina para hacerla parpadear
        if (titila == false)
        {
            StartCoroutine(LuzQueTitila());
        }
    }

    // Corrutina que controla el parpadeo de la luz
    IEnumerator LuzQueTitila()
    {
        titila = true; // Establece titila en true para evitar múltiples llamadas simultáneas
        this.gameObject.GetComponent<Light>().enabled = false; // Apaga la luz
        timeDelay = Random.Range(0.01f, 0.2f); // Genera un tiempo de espera aleatorio
        yield return new WaitForSeconds(timeDelay); // Espera el tiempo aleatorio con la luz apagada
        this.gameObject.GetComponent<Light>().enabled = true; // Enciende la luz nuevamente
        timeDelay = Random.Range(0.01f, 0.2f); // Genera otro tiempo de espera aleatorio
        yield return new WaitForSeconds(timeDelay); // Espera el tiempo aleatorio con la luz encendida
        titila = false; // Restablece titila a false para permitir que la corrutina se llame de nuevo
    }
}
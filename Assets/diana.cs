using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class diana : MonoBehaviour
{
    public SplineContainer[] splineContainers;
    float velocidad;
    float distance = 0f;
    private int currentSplineIndex = 0;
    private float splineLenght;
    public Vagones vagon;
    public ParticleSystem particulas;

    private void Start()
    {
        velocidad = vagon.velocidadDianas;

        if (splineContainers.Length == 0)
        { 
            return;
        }
        splineLenght = splineContainers[currentSplineIndex].CalculateLength();
    }

    private void Update()
    {
        if (splineContainers.Length == 0)
        { 
            return;
        }

        distance += velocidad * Time.deltaTime / splineLenght;

        Vector3 currentPosition = splineContainers[currentSplineIndex].EvaluatePosition(distance);
        transform.position = currentPosition;

        if (distance > 1f)
        {
            distance = 0f;
            currentSplineIndex++;

            if (currentSplineIndex >= splineContainers.Length)
            {
                currentSplineIndex = 0;
            }

            splineLenght = splineContainers[currentSplineIndex].CalculateLength();
        }

        Vector3 nextPosition = splineContainers[currentSplineIndex].EvaluatePosition(distance + 0.05f);
        Vector3 direction = nextPosition - currentPosition;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            particulas.Play();
            Debug.Log("Entrando");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionColeccionable : MonoBehaviour
{
    float seconds;
    [SerializeField] float durationSeconds;
    [SerializeField] Vector3 tama�oMax;
    Vector3 tama�oEscalado;
    Vector3 tama�oInicial = new Vector3(1, 1, 1);
    [SerializeField] AnimationCurve curve;
    [SerializeField] Vector3 velocidadRotacion;
    void Start()
    {
        transform.localScale = tama�oInicial;
        tama�oEscalado = tama�oMax;
        StartCoroutine(ScaleChanger());
    }

    void Update()
    {
        transform.Rotate(velocidadRotacion * Time.deltaTime);
    }

    public IEnumerator ScaleChanger()
    {
        while (true)
        {
            while(seconds < durationSeconds)
            {
                seconds += Time.deltaTime;
                transform.localScale = Vector3.Lerp(
                    tama�oInicial,
                    tama�oEscalado,
                    curve.Evaluate(seconds / durationSeconds));

                yield return new WaitForEndOfFrame();

            }
            seconds = 0;
            transform.localScale = tama�oInicial;

            yield return null;
        }
    }
}

using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = -5;
    public float flipTime = 8;

    void Start()
    {
        InvokeRepeating("Flip", flipTime, flipTime);    // Fica repetindo 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    void Flip()
    {
        speed *= -1;                            // Inverte valor apra negativo e positivo
        Vector3 scale = transform.localScale;   // Declara uma var de transforme e seta com valor do transform do Player
        scale.x *= -1;                          // Inverte o valor de x para Positivo ou Negativo, depende do estado atual do valor
        transform.localScale = scale;           // Seta o novo valor no transform do Player
    }
}

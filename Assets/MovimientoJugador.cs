using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavidadDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
    }

    private void FixedUpdate()
    {//MOVER
        Mover(movimientoHorizontal * Time.fixedDeltaTime);  
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjeto = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjeto, ref velocidad, suavidadDeMovimiento );

        if (mover > 0 && !mirandoDerecha)
        {
            //GIRAR
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //GIRAR
            Girar();
        }
    }
    private void Girar ()
    {
        mirandoDerecha &= !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= 1;
        transform.localScale = escala;
    }
}

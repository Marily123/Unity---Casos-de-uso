using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectable : MonoBehaviour
{
    public enum TipoItem { Normal, Escudo, Velocidad, Moneda }
    public TipoItem tipo;

    private void OnTriggerEnter(Collider other)
    {
        move myObject = other.GetComponent<move>();
        if (myObject == null) return;

        switch (tipo)
        {
            case TipoItem.Escudo:
                myObject.ActivarEscudo();
                break;

            case TipoItem.Velocidad:
                myObject.ActivarVelocidad();
                break;

            case TipoItem.Moneda:
                myObject.SumarMoneda();
                break;

            default:
                myObject.cambioObjeto = true;
                break;
        }

        Destroy(this.gameObject);
    }
}

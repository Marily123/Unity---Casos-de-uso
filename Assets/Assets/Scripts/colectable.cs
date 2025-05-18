using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        move myObject = other.GetComponent<move>();
        if (myObject != null)
        {
            myObject.cambioObjeto = true;

            UIManager ui = FindObjectOfType<UIManager>();
            if (ui != null)
            {
                ui.AgregarMoneda();
            }
        }
    }

}

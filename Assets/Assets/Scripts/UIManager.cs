using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI monedaTexto;
    private int monedas = 0;

    public void AgregarMoneda()
    {
        monedas++;
        monedaTexto.text = "Probiciones balas adquiridas: " + monedas;
    }
}

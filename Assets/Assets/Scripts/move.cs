using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para mostrar texto UI

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    public float horizontalInput;
    public float verticalInput;

    public GameObject miObjeto;
    public GameObject miOtroObjeto;

    public bool cambioObjeto = false;

    // Escudo
    public GameObject escudoVisual;
    public float duracionEscudo = 5f;

    // Velocidad temporal
    private bool velocidadActiva = false;
    public float velocidadExtra = 2f;
    public float duracionVelocidad = 5f;

    // Monedas
    public int cantidadMonedas = 0;
    public TextMeshProUGUI contadorMonedasText;

    // Salto
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contadorMonedasText.text = "Monedas: " + cantidadMonedas;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float velocidadActual = velocidadActiva ? speed + velocidadExtra : speed;

        transform.Translate(Vector3.right * Time.deltaTime * velocidadActual * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * velocidadActual * verticalInput);

        // Disparo
        if (Input.GetKeyDown(KeyCode.F)) // Usamos "F" para disparar
        {
            cambiaMiObjeto();
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        // Límites del escenario
        if (transform.position.z > 15.6f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15.6f);
        }
        if (transform.position.z < -23.18279f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -23.18279f);
        }
        if (transform.position.x < -22.70373f)
        {
            transform.position = new Vector3(-22.70373f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 22.65776f)
        {
            transform.position = new Vector3(22.65776f, transform.position.y, transform.position.z);
        }
    }

    private void cambiaMiObjeto()
    {
        if (cambioObjeto)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }

    public void ActivarEscudo()
    {
        escudoVisual.SetActive(true);
        Invoke("DesactivarEscudo", duracionEscudo);
    }

    private void DesactivarEscudo()
    {
        escudoVisual.SetActive(false);
    }

    public void ActivarVelocidad()
    {
        if (!velocidadActiva)
        {
            velocidadActiva = true;
            Invoke("DesactivarVelocidad", duracionVelocidad);
        }
    }

    private void DesactivarVelocidad()
    {
        velocidadActiva = false;
    }

    public void SumarMoneda()
    {
        cantidadMonedas++;
        contadorMonedasText.text = "Monedas: " + cantidadMonedas;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

}

//Nota: la f junto a los numeros indica el tipo de dato "float".
//Quaternion: unidades que controlan la rotacion en un momento determinado de tiempo
//cualquier clase PUBLICA puede ser llamada desde otra.
//objetos para coleccionar: requisitos:
//1. personaje y objeto con collider
//2. personaje con RigidBody
//3. objeto con isTrigger activado
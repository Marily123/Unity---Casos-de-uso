using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    public float fuerzaSalto = 5f;

    public float horizontalInput;
    public float verticalInput;

    public GameObject miObjeto;
    public GameObject miOtroObjeto;

    public bool cambioObjeto = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Movimiento horizontal y vertical
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Límites del escenario vertical
        if (transform.position.z > 15.6f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 15.6f);

        if (transform.position.z < -23.18279f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -23.18279f);

        // Límites del escenario horizontal
        if (transform.position.x < -22.70373f)
            transform.position = new Vector3(-22.70373f, transform.position.y, transform.position.z);

        if (transform.position.x > 22.65776f)
            transform.position = new Vector3(22.65776f, transform.position.y, transform.position.z);

        // SALTAR siempre que se presione espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reinicia la velocidad vertical para mejor control del salto
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            // Aplica fuerza hacia arriba
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

        // Cambiar objeto con Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cambiaMiObjeto();
        }
    }

    private void cambiaMiObjeto()
    {
        if (cambioObjeto == true)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }
}


//Nota: la f junto a los numeros indica el tipo de dato "float".
//Quaternion: unidades que controlan la rotacion en un momento determinado de tiempo
//cualquier clase PUBLICA puede ser llamada desde otra.
//objetos para coleccionar: requisitos:
//1. personaje y objeto con collider
//2. personaje con RigidBody
//3. objeto con isTrigger activado
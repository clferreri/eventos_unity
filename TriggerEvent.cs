using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    private bool rotar = false;
    public UnityEvent eventos;
    public UnityEvent eventos2;
    [SerializeField]
    public bool acomode = false;
    private System.Random rand;
    private float tiempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.rand = new System.Random();
    }

    public void YaAcomode()
    {
        this.acomode = true;
    }

    public void PermitirAcomodar()
    {
        this.acomode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotar)
        {
            this.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }

        tiempo += Time.deltaTime;
        double tiempito = Math.Round(tiempo / 10, 0);
        //Debug.Log(tiempo);;
        if(tiempito == 1 || tiempito == 2 || tiempito == 3)
        {
            if (!acomode)
            {
                this.eventos.Invoke();
            }
        }
        else
        {
            this.eventos2.Invoke();
        }
    }


    public void toggleRotar()
    {
        string mensaje = (!rotar) ? "Me mandaron a rotar por evento de click" : "Me mandaron a detener la rotacion por evento de click";
        Debug.Log(mensaje);
        this.rotar = !this.rotar;
    }


    public void Acomodar()
    {
        Debug.Log("me mandaron a acomodar. soy del evento 1");
        this.transform.Rotate(new Vector3(rand.Next(-20, 20), this.transform.rotation.y, rand.Next(-20, 20)));
    }
}

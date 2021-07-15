using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamiaoDriver : MonoBehaviour
{

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] transforms = new Transform[4];
    public Animator animDaCarroseria;


    public float Velocidade = 350;
    public float AnguloMaximo = 45;


    private void Update()
    {
        AbrirEFecharCarroseria();
    }

    void AbrirEFecharCarroseria()
    {
        if (Input.GetKey("x"))
        {
            animDaCarroseria.SetBool("Aberto", true);
        }
        if (Input.GetKeyUp("z"))
        {
            animDaCarroseria.SetBool("Aberto", false);
        }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < wheelColliders.Length; i++)
        {
            Quaternion quat;
            Vector3 vector;

            wheelColliders[i].GetWorldPose(out vector, out quat);

            transforms[i].rotation = quat;
            transforms[i].position = vector;
        }

        wheelColliders[0].steerAngle = AnguloMaximo * Input.GetAxis("Horizontal");
        wheelColliders[1].steerAngle = AnguloMaximo * Input.GetAxis("Horizontal");
        wheelColliders[2].motorTorque = Velocidade * Input.GetAxis("Vertical");
        wheelColliders[3].motorTorque = Velocidade * Input.GetAxis("Vertical");
        wheelColliders[0].brakeTorque = Input.GetAxis("Jump") * 1000;
        wheelColliders[1].brakeTorque = Input.GetAxis("Jump") * 1000;
        wheelColliders[2].brakeTorque = Input.GetAxis("Jump") * 1000;
        wheelColliders[3].brakeTorque = Input.GetAxis("Jump") * 1000;
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikecontrlloer : MonoBehaviour
{
    //Angle of streeing
    public int Streeingangle;
    //Force Applied on bike
    public int motortorque;

    //Tilt angle Z axis for animation
    public int TILTangle_z;
    //Tilt angle y axis for animation
    public int TILTangle_y;
    
    //Bike Body for animation
    public GameObject bike; 
    //Both wheel collider
    public WheelCollider frontWHL;
    public WheelCollider backWHL;
    
    float hvalue;
    float vvalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        vvalue = Input.GetAxis("Vertical");
        hvalue = Input.GetAxis("Horizontal");
        animation();
        streeing();
        torque();
    }
    public void torque()
    {
        backWHL.motorTorque = motortorque * Input.GetAxis("Vertical");
        frontWHL.motorTorque = motortorque * Input.GetAxis("Vertical");
    }
    public void streeing()
    {
        frontWHL.steerAngle = Streeingangle * Input.GetAxis("Horizontal");
    }
    public void animation()
    {
        bike.transform.rotation = Quaternion.Lerp(bike.transform.rotation,Quaternion.Euler(-87, TILTangle_y * hvalue, TILTangle_z * hvalue),10 * Time.deltaTime);
        bike.transform.rotation = Quaternion.Lerp(Quaternion.Euler(-87, TILTangle_y * hvalue, TILTangle_z * hvalue),bike.transform.rotation,  10 * Time.deltaTime);
    }

    //link of bike 3d model 
    //sketchfab.com/3d-models/generic-fictional-bike-2-lpstylized-5b33cc9f9f924a90a13652f8941276d5

    }

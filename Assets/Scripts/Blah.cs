using UnityEngine;
using System.Collections;

public class Blah : MonoBehaviour {

    public float allowedSpeed;
    public float maxSpeed = 30f;
    public float boostMaxSpeed;

    public GameObject EnergyBar;
    public float energyMin;
    public float energyMax;
    public float energyUsage;

    public float boostEnergy;
    public float boostUsageRate;

    private float startTime;

    // Use this for initialization
    void Start () {
        boostEnergy = 1;
        energyMax = 5;
        
	}



    void Update()
    {
        
        if (GetComponent<Rigidbody>().velocity.magnitude > allowedSpeed)
        {
            GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, allowedSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift) && boostEnergy > 0 && allowedSpeed < boostMaxSpeed)
        {
            boostEnergy -= Time.deltaTime * boostUsageRate;

            if (boostEnergy > 0 && allowedSpeed < boostMaxSpeed)
            {
                allowedSpeed += Time.deltaTime * 12;
            }

        }

        if (!Input.GetKey(KeyCode.LeftShift) && allowedSpeed > maxSpeed)
        {
            Debug.Log("reduce allowed speed");
            allowedSpeed -= Time.deltaTime;
        }

        if (boostEnergy < 1 && !Input.GetKey(KeyCode.LeftShift))
        {
            boostEnergy += Time.deltaTime * 0.1f;
        }

        EnergyBar.transform.localScale = new Vector3(boostEnergy, EnergyBar.transform.localScale.y, EnergyBar.transform.localScale.z);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 200), "rigidbody velocity: " + GetComponent<Rigidbody>().velocity);
        GUI.Label(new Rect(20, 40, 200, 200), "Boost Energy " + boostEnergy);
        GUI.Label(new Rect(20, 60, 200, 200), "allowedSpeed " + allowedSpeed);
    }
}



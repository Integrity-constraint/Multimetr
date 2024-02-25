using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum Mode { None, Resistance, Current, Voltage, ACVoltage };
public class krutilka : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI screen;
    public GameObject emptyObject;

    private Mode currentMode = Mode.None;

    public float rotationAmount;
    private int currentStep = 0;
    private static readonly Mode[] modes = { Mode.None, Mode.Resistance, Mode.Current, Mode.ACVoltage, Mode.Voltage};
    private static readonly string[] modeNames = { "None", "Сопротивление", "Напряжение", "Вольтаж", "ACVoltage" };

    public double resistance = 1000f; // Ом
    public double power = 400f; // Вт

    private double current; // А
    private double voltage; // В
    private double AcVoltage; 


   
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float rotation = scroll > 0 ? rotationAmount : -rotationAmount;
            transform.Rotate(Vector3.up, rotation);

            
            if (scroll > 0)
                currentStep = (currentStep + 1) % modes.Length;
            else
                currentStep = (currentStep - 1 + modes.Length) % modes.Length;

            SetMode(modes[currentStep], modeNames[currentStep]);
        }

        if (currentMode == Mode.Current)
        {
            current = Math.Sqrt(power / resistance);
            screen.text = $"A {current:0.00}";
        }
        if (currentMode == Mode.Voltage)
        {
            voltage = power / (Math.Sqrt(power / resistance));
            screen.text = $"V {voltage:0.00}";
        }
        if (currentMode == Mode.ACVoltage)
        {
            AcVoltage = 0.01f;
            screen.text = $"V~ {AcVoltage:0.00}";
        }
        if(currentMode == Mode.None)
        {
            screen.text = $"0";
            current = 0;
            AcVoltage = 0;
            voltage = 0;

        }

        if (currentMode == Mode.Resistance)
        {
            screen.text = $"{resistance}";
            

        }
    }
    
   
    void SetMode(Mode mode, string displayText)
    {
       
       
        if (currentMode != mode)
        {
            currentMode = mode;
            text.text =  $"Режим: {displayText}" +
                "\n Данные:" +
                $"\nΩ= {resistance:0.00}" +
                $"\nA= {current:0.00}" +
                $"\nV= {voltage:0.00}" +
                $"\nV~= {AcVoltage:0.00}";
            Debug.Log("Switched to mode: " + mode.ToString());
           
        }
    }
   

}

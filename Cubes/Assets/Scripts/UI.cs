using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] UnityEvent changeSpeed;
    [SerializeField] TextMeshProUGUI textSpeed;
    [HideInInspector] Data data;
    float sliderCurrent;
    Coroutine coroutine;

    void Awake(){
        data = FindObjectOfType<Data>();
    }

    void Start(){
        slider.minValue = data.cubeMinSpeed;
        slider.maxValue = data.cubeMaxSpeed;
        slider.value = data.cubeSpeed;
        sliderCurrent = slider.value;
        textSpeed.text = data.cubeSpeed.ToString();
    }

    void Update(){
        if (sliderCurrent != slider.value){
            if (coroutine == null){
                coroutine = StartCoroutine(ChangeSpeedCoroutine());
            }
        }
    }

    IEnumerator ChangeSpeedCoroutine(){
        data.cubeSpeed = slider.value;
        changeSpeed.Invoke();
        sliderCurrent = slider.value;
        textSpeed.text = System.Math.Round(slider.value,2).ToString();
        yield return new WaitForSeconds(0.1f);
        coroutine = null;
    }
}

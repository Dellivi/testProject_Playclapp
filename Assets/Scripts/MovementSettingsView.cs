using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MovementSettingsView : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField_SpawnDelay;
    [SerializeField] private TMP_InputField inputField_Distance;
    [SerializeField] private TMP_InputField inputField_Speed;

    private Spawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        inputField_Distance.onValueChanged.AddListener(delegate { OnChangeDistance(); });
        inputField_Speed.onValueChanged.AddListener(delegate { OnChangeSpeed(); });
        inputField_SpawnDelay.onValueChanged.AddListener(delegate { OnChangeSpawnDelay(); });

        SetStartValue(inputField_Speed, spawner.Speed.ToString());
        SetStartValue(inputField_SpawnDelay, spawner.Delay.ToString());
        SetStartValue(inputField_Distance, spawner.Distance.ToString());
    }

    public void SetStartValue(TMP_InputField inputField, string _text)
    {
        inputField.text = _text;
    }

    public void OnChangeSpawnDelay()
    {
        float delayTemp = float.Parse(inputField_SpawnDelay.text);
        spawner.Delay = delayTemp;
    }

    public void OnChangeDistance()
    {
        float distance = float.Parse(inputField_Distance.text);
        spawner.Distance = distance;
    }

    public void OnChangeSpeed()
    {
        float speedTemp = float.Parse(inputField_Speed.text);
        spawner.Speed = speedTemp;
    }

}


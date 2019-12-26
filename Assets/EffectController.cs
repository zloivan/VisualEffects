using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleSystems;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private RectTransform rootForButtons;

    private Button[] listOfButtons;

    void Start()
    {
        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        var numberOfParticleSystem = particleSystems.Length;
        listOfButtons = new Button[numberOfParticleSystem];


        for (var i = 0; i < numberOfParticleSystem; i++)
        {
            var ps = particleSystems[i];
            var newButton = Instantiate(buttonPrefab, rootForButtons);
            newButton.GetComponentInChildren<Text>().text = particleSystems[i].gameObject.name;
            
            newButton.onClick.AddListener(() =>
                {
                    if (ps.isEmitting)
                    {
                        ps.Stop();
                    }
                    else
                    {
                        ps.Play(); 
                    }
                    
                }
            );
            listOfButtons[i] = newButton; 
        }
    }
}

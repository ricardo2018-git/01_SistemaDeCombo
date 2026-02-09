using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    // Scripts
    public Combo[] combos;          // Pode ter varios combos
    // ------------------------

    // Componentes
    private Animator anim;          // Referencia do animetor
    // ------------------------

    // Controle lógico
    private bool startCombo;        // Controla combo
    public List<string> currentCombo;   // Vai guardando os imputs pressionado
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------

    private void Awake()
    {
        anim = GetComponent<Animator>();    // Acessa animator do obj
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckInputs();  // Verifica qual botão foi pressionado
    }

    void CheckInputs()         // Verifica os inputs de entrada
    {
        for(int i = 0; i < combos.Length; i++)  // Percorre todos combos
        {
            if (Input.GetButtonDown(combos[i].hits[currentCombo.Count].inputButton))  // Verifica se esta pressionando botão do hit correspondente
            {
                if(currentCombo.Count == 0)     // Verifica se é o primeiro 
                {
                    Debug.Log("Primeiro hit foi adicionado");        // Log
                    PlayHit(combos[i].hits[currentCombo.Count]);     // Chama função para executar animação do hit
                    break;                                           // Finaliza loop
                }
                else
                {
                    bool comboMatch = false;                        // Controla se sequencia de combo esta igual ou não
                    for(int y = 0; y < currentCombo.Count; y++)     // Percorre todo combo por outro index
                    {
                        if(currentCombo[y] != combos[i].hits[y].inputButton)    // Verifica se na lista de combos o Combo i no hit y são diferentes
                        {
                            Debug.Log("Input não pertence ao hit atual");   // Log
                            comboMatch = false;                             // Sinaliza que não é uma combinação valida
                            break;                                          // Finaliza loop
                        }
                        else
                        {
                            comboMatch = true;  // Sinaliza que combinação é valida
                        }
                    }

                    if (comboMatch) // Verifica se comboMatch é verdadeiro
                    {
                        PlayHit(combos[i].hits[currentCombo.Count]);    // Executa animação do combo i do ultimo hit
                    }
                }
                
            }
        }
    }

    void PlayHit(Hit hit)              // Ataque
    {
        anim.Play(hit.animation);           // Roda animação que recebeu
        startCombo = true;                  // Sinaliza que iniciou combo
        currentCombo.Add(hit.inputButton);  // Adiciona na lista de o imput pressionado
    }

    void ResetCombo()           // Reseta sequencia
    {
        startCombo = false;              // Sinaliza que finalizou combo
    }
}

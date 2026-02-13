using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
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
    private bool startCombo;            // Controla combo
    public List<string> currentCombo;   // Vai guardando os imputs pressionado
    private float comboTimer;           // Cronometro
    private bool canHit = true;         // Controla se pode aperta o btn de Hit ou não
    private bool resetCombo;            // Reset do combo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    private Hit currentHit;     // Hit atual
    private Hit nextHit;        // Proximo hit
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
        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !canHit)   // Verifica se apertou btn esquerdo ou direito do mouse E btn do hit esta falso
        {
            resetCombo = true;      // Sinaliza para resetar combo
        }

        for(int i = 0; i < combos.Length; i++)  // Percorre todos combos
        {
            if (combos[i].hits.Length >= currentCombo.Count)     // Filtro para ele olhar apenas os que for igual ou maior na quantidade de hits. Caso tenha menos ele nem perde tempo em olhar ja vai para proximo
            {
                if (currentCombo.Count < combos[i].hits.Length && Input.GetButtonDown(combos[i].hits[currentCombo.Count].inputButton))  // Verifica se esta pressionando botão do hit correspondente
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

                        if (comboMatch && canHit) // Verifica se comboMatch é verdadeiro E se pode aperta o btn de hit
                        {
                            Debug.Log("Hit adicionado ao combo");           // Log
                            nextHit = combos[i].hits[currentCombo.Count];   // Set proximo hit com animação do combo i do ultimo hit
                            canHit = false;                                 // Não deixa aperta o btn de hit
                            break;                                          // Sai do loop
                        }
                    }
                    
                }
            }
        }

        if (startCombo)     // Verifica se é verdadeiro
        {
            comboTimer += Time.deltaTime;   // Inicia cronometro
            if(comboTimer >= currentHit.animationTime && !canHit)  // Verifica se o cronometro é maior ou igual ao tempo da animação do hit atual E se Não pode aperta o btn de hit
            {
                PlayHit(nextHit);   // Executa proximo hit
                if (resetCombo)     // Verifica se pode resetar o combo
                {
                    canHit = false;     // Não deixa apertar btn de hit
                    CancelInvoke();     // Cancela qualquer invoke q ja tenha sido chamado
                    Invoke("ResetCombo", currentHit.animationTime); // Executa função em x tempo
                }
            }
            if(comboTimer >= currentHit.resetTime)  // Verifica se cronometro é maior ou igual ao resetTime do hit atual
            {
                ResetCombo();   // Reseta combo
            }
        }
    }

    void PlayHit(Hit hit)              // Ataque
    {
        comboTimer = 0;                     // Reseta cronometro
        anim.Play(hit.animation);           // Roda animação que recebeu
        startCombo = true;                  // Sinaliza que iniciou combo
        currentCombo.Add(hit.inputButton);  // Adiciona na lista de o imput pressionado
        currentHit = hit;                   // Set hit atual com hit recebido no parametro
        canHit = true;                      // Pode aperta btn de hit
    }

    void ResetCombo()           // Reseta sequencia
    {
        startCombo = false;              // Sinaliza que finalizou combo
        comboTimer = 0;                  // Reseta cronometro
        currentCombo.Clear();            // Limpa lista de combos
        anim.Rebind();                   // Volta para valor padrão do animation
        canHit = true;                      // Pode aperta btn de hit
    }
}

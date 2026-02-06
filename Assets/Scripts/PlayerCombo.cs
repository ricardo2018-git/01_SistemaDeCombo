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
            if (Input.GetButtonDown(combos[i].hits[0].inputButton))  // Verifica se esta pressionando botão do hit correspondente
            {
                PlayHit(combos[i].hits[0]);     // Chama função para executar animação do hit
                break;                          // Finaliza loop
            }
        }
    }

    void PlayHit(Hit hit)              // Ataque
    {
        anim.Play(hit.animation);       // Roda animação que recebeu
    }

    void ResetCombo()           // Reseta sequencia
    {
        
    }
}

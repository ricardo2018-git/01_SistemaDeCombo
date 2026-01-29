using UnityEngine;
using TMPro;            // Responsavel por manipular componente de Texto do canvas
using UnityEngine.UI;   // Responsavel pelos componentes de UI

public class UIManager : MonoBehaviour
{
    // Scripts
    private Player playerInstance;          // Referencia do script player
    private Inventory inventoryInstance;    // Referencia do script do inventario
    // ------------------------

    // Componentes
    // ------------------------

    // Controle lógico
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    public TMP_Text healthText;     // Qts de Vidas Player
    // ------------------------

    void Awake()
    {
        
    }

    void Start()
    {
        // Associa Scripts
        playerInstance = GameObject.Find("Player").GetComponent<Player>();  // Associa Player em tempo de execução

        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }
    
    public void Score(int amount)   // Atualiza pontuação na UI
    {
        //points += amount;                       // Soma pontos atuais mais pontos recebidos
        //pointsText.text = points.ToString();    // Atualiza pontuação na UI
    }
}
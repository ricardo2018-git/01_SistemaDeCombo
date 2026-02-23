using UnityEngine;
using TMPro;            // Responsavel por manipular componente de Texto do canvas
using UnityEngine.UI;   // Responsavel pelos componentes de UI

public class UIManager : MonoBehaviour
{
    // Scripts
    public static UIManager instance;       // Referencia o proprio script
    private Player playerInstance;          // Referencia do script player
    private Inventory inventoryInstance;    // Referencia do script do inventario
    // ------------------------

    // Componentes
    private Animator combotextAnimator;     // Vai guardar animator do combo text
    // ------------------------

    // Controle lógico
    private int totalCombo;                 // Pontuação total
    public float resetTime = 2f;            // Tempo para reset combo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    //public TMP_Text healthText;     // Qts de Vidas Player
    public TMP_Text comboText;      // Pontiação
    // ------------------------

    void Awake()
    {
        instance = this;    // Passa propria class para var
    }

    void Start()
    {
        // Associa Scripts
        playerInstance = GameObject.Find("Player").GetComponent<Player>();  // Associa Player em tempo de execução

        // Associa Componentes
        comboText = GameObject.Find("ComboText").GetComponent<TMP_Text>();  // Procura obj na cena pelo nome e acessa seu texto
        combotextAnimator = comboText.GetComponent<Animator>();     // Acessa animator

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

    public void SetCombo()
    {
        totalCombo++;       // Adiciona +1
        comboText.text = "x" + totalCombo;   // Atualiza UI com novo valor
        combotextAnimator.SetTrigger("Hit");    // Ativa animação pelo trigger
        CancelInvoke();         // Cancela todos invike. Obs: para garantir que foi chamado uma unica vez
        Invoke("ResetCombo", resetTime);        // Executa função dentro de x segundos
    }

    void ResetCombo()
    {
        totalCombo = 0;     // Reset combo
    }
}
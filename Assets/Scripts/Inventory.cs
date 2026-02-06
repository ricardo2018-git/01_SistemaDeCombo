using UnityEngine;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    // Scripts
    public static Inventory inventoryInstance;  // Referencia desse script
    private UIManager uiManagerInstance;        // Referencia script uimanager
    // ------------------------

    // Componentes
    // ------------------------

    // Controle lógico
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------
    
    void Awake()
    {
        // Sistema para não ser destruido esse script entre cenas
        if (inventoryInstance == null)        // Verifica se a instancia é nula
        {
            inventoryInstance = this;         // Gera instancia desse script
            transform.parent = null;
            DontDestroyOnLoad(gameObject);  // Não deixa destruir esse script entre cena ou quando recarregar cena
        }
        else if (inventoryInstance != this)   // Verifica se a instancia é diferente desse obj
        {
            Destroy(gameObject);        // Destroi obj de cena
        }
    }

    void Start()
    {
        // Associa Scripts
        uiManagerInstance = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject
        
        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        LoadInventory();    // Carrega todos itens do inventario

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }

    void LoadInventory()    // Carrega todos itens no inventario, isso é para quando o player para de jogar e reiniciar o jogo outro dia
    {
        
    }

    public void AddItem01(/*Item item*/)    // Mudar nome do item01 e nome do parametro tambem
    {
        
    }

    public bool CheckItemName(/*Item item*/)    // Verifica se existe item na lista do item, retorna valor boleano caso ache ou não
    {/*
        for (int i = 0; i < itens.Count; i++)    // Percorre toda lista de chaves
        {
            if (itens[i] == item)                 // Verifica na posição i se é a chave que estamos procurando
            {
                return true;                    // Retorna que achou a chave procurada
            }
        }
        */
        return false;                           // Seguinifica que não existe essa chave no lista de chaves
    }

    public void RemoveItem(/*Item item*/)       // Remove item ja usado
    {
        
    }

    public int CountItems(/*Item item*/)
    {
        int qtsItem = 0;
        // For na lista
        return qtsItem;
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{

    // Scripts
    private GameManager gameManagerInstance;    // Referencia script game manager
    private UIManager uiManagerInstance;        // Referencia script uimanager
    // ------------------------

    // Componentes
    private Transform groundCheck;      // Vai acessar posição do player
    private SpriteRenderer sprite;      // Vai acessar sprite do player
    private Rigidbody2D rb;             // Vai acessar física do player
    private Animator anim;              // Vai acessar animações do player
    // ------------------------

    // Controle lógico
    public int health;                  // Vida atual
    public int maxHealth;               // Maximo de vida player

    private float speed;                // Velocidade atual   
    public float jumpForce;             // Força do pulo

    private bool isDead;                // Sinaliza se player esta morto
    private bool jump;                  // Sinaliza se player esta pulando
    private bool facingRight = true;    // Sinaliza se player esta olhando para direita
    private bool onGround;              // Sinaliza se player esta no chão
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------
    
    void Awake()
    {
        
    }

    void Start()
    {
        // Associa Scripts
        gameManagerInstance = GameManager.gameManagerInstance;                              // Inicia acesso ao script static
        uiManagerInstance = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject

        // Associa Componentes
        //sprite = GetComponent<SpriteRenderer>();    // Acessa componente
        //rb = GetComponent<Rigidbody2D>();           // Acessa componente
        //anim = GetComponent<Animator>();            // Acessa componente

        // Inicia: Controle lógico, metodos e funções
        health = gameManagerInstance.health;        // Recebe qts de vidas
        maxHealth = gameManagerInstance.maxHealth;   // Recebe qts de vida maxima
        
        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        if (!isDead || !gameManagerInstance.gameOver)    // Verifica se Player esta Vivo
        {
            
        }
        else
        {
            gameManagerInstance.gameOver = isDead;		// Sinaliza que player morreu para game manager
        }
    }

    private void FixedUpdate()
    {
        if (!isDead || !gameManagerInstance.gameOver)    // Verifica se Player esta Vivo
        {
            
        }
        else
        {
            gameManagerInstance.gameOver = isDead;		// Sinaliza que player morreu para game manager
        }
    }

    void Flip()                                 // Vira corpo do player
    {
        facingRight = !facingRight;             // Seta var para o valor oposto
        Vector3 scale = transform.localScale;   // Declara uma var de transforme e seta com valor do transform do Player
        scale.x *= -1;                          // Inverte o valor de x para Positivo ou Negativo, depende do estado atual do valor
        transform.localScale = scale;           // Seta o novo valor no transform do Player
    }
}
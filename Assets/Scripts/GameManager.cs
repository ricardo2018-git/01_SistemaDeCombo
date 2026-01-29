using UnityEngine;
using UnityEngine.SceneManagement;  // Para carregar telas

public class GameManager : MonoBehaviour
{
    // Scripts
    public static GameManager gameManagerInstance;  // Referencia desse script
    private UIManager uiManagerInstance;            // Referencia do script UI
    private Player playerInstance;                  // Referencia do script player
    // ------------------------

    // Componentes
    // ------------------------

    // Controle lógico
    public int health = 50;                 // Vida atual
    public int maxHealth = 100;              // Maximo de vida player
    public bool isDead = false;              // Sinaliza que player esta vivo
    public bool gameOver = true;           	 // Sinaliza se jogo acabou, Vai iniciar como true para o player não se mover antes de clicar no btn start game
    

    public float playerPosX, playerPosY;                // Posição do player
    public float minCamX, maxCamX, minCamY, maxCamY;    // Posição da camera
    private string filePath;                            // Caminho onde vai ser salvo arquivo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------
    
    void Awake()
    {/*
        // Sistema para não ser destruido esse script entre cenas
        if (gameManager == null)        // Verifica se a instancia é nula
        {
            gameManager = this;         // Gera instancia desse script
        }
        else if (gameManager != this)   // Verifica se a instancia é diferente desse obj
        {
            Destroy(gameObject);        // Destroi obj de cena
        }
        DontDestroyOnLoad(gameObject);  // Não deixa destruir esse script entre cena ou quando recarregar cena
    */
        //filePath = Application.persistentDataPath + "/playerInfo.dat";  // Passa o caminho e nome do arquivo que deve ser salvo os dados do Player
        //Path onde vai esta o arquivo: C:\Users\rp_mi\AppData\LocalLow\DefaultCompany\90_Snake_vs_Blocks\playerInfo.dat
        //Load();     // Carrega dados salvo Fase etc..
    }

    void Start()
    {
        // Associa Scripts
        playerInstance = GameObject.Find("Player").GetComponent<Player>();          // Associa Player em tempo de execução
        uiManagerInstance = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject
        
        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }
    
    public void StartGame()     // Inicia jogo
    {
        //AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);    // Toca son, na posição da camera, pode passar volume no proximo parametro que vai de 0 até 1. *Obs sem parametro toca no valor maximo = 1
        //gamePanel.SetActive(true);      // Ativa painel em cena
        //startPanel.SetActive(false);    // Desativa painel de cena
        gameOver = false;               // Libera player para inicio do jogo
    }
    
    public void GameOver()      // Fim de jogo
    {
        gameOver = true;                // Sinaliza que player morreu
        //gameSpeed = 0;                  // Zera velocidade do jogo
        //gameOverPanel.SetActive(true);  // Ativa painel game over
    }
    
    public void ReloadScene()   // Recarregar propria cena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Recarrega cena atual pelo index
    }
    
    public void SaveGame()  // Salva todos dados do jogo
    {
        
    }

    public void LoadGame()  // Carrega todos os dados do jogo
    {
        
    }
}
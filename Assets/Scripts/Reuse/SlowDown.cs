using UnityEngine;

public class SlowDown : MonoBehaviour
{
    // Scripts
    public static SlowDown instance;    // Referencia unica desse escript
    // ------------------------

    // Componentes
    // ------------------------

    // Controle lógico
    private float timer;                // Cronometro
    public float slowDownTime = 1f;     // Tempo do SlowDown
    private bool canSlowDown;           // Controla se pode ou não rodar SlowDown
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------

    private void Awake()
    {
        instance = this;    // Cria instancia desse script
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (canSlowDown)    // Verifica se esta rodando SlowDown
        {
            timer += Time.unscaledDeltaTime;                            // Incrementa o tempo no cronometro. Foi usado unscaledDeltaTime, pq o timeScale esta em pause
            Time.timeScale += Time.unscaledDeltaTime / slowDownTime;    // 
            if(timer >= slowDownTime)                                   // Verifica se ja passou o tempo do SlowDown
            {
                canSlowDown = false;    // Sinaliza que acabou SlowDown
                Time.timeScale = 1;     // Despausa jogo
            }
        }
    }

    public void SetSlowDown()
    {
        Time.timeScale = 0;     // Para o jogo ou pausa o jogo
        canSlowDown = true;     // Sinaliza que esta rodando SlowDown 
        timer = 0;              // Reseta cronometro
    }
}

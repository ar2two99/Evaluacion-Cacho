using System;
using System.Linq;

public class ControladorDados
{
    public int[] Dados { get; private set; } = new int[5] { 1, 1, 1, 1, 1 };
    private Random rnd = new Random();
    public int Tiros { get; private set; } = 0;
    public bool FueDeMano { get; private set; } = false;

    public void Lanzar(bool[] guardados)
    {
        if (Tiros >= 2) return;

        // Validar si el tiro es de mano (ningun dado debe estar guardado)
        FueDeMano = Tiros == 0 && !guardados.Contains(true);

        for (int i = 0; i < 5; i++)
        {
            if (!guardados[i])
            {
                Dados[i] = rnd.Next(1, 7);
            }
        }
        Tiros++;
    }

    public void Voltear(int indice)
    {
        Dados[indice] = 7 - Dados[indice];
    }

    public void ResetearTurno()
    {
        Tiros = 0;
        FueDeMano = false;
    }
}

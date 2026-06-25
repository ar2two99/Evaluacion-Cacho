using System;
using System.Linq;
using System.Collections.Generic;

public class CalculadoraPuntajes
{
    // cpmbinaciones
    private List<int[]> GenerarVariantesConVuelcos(int[] dados)
    {
        List<int[]> variantes = new List<int[]>();

        // Sin volcar
        variantes.Add((int[])dados.Clone());

        // Volcar 1 dado
        for (int i = 0; i < dados.Length; i++)
        {
            int[] copia = (int[])dados.Clone();
            copia[i] = 7 - copia[i];
            variantes.Add(copia);
        }

        // Volcar 2 dados
        for (int i = 0; i < dados.Length; i++)
        {
            for (int j = i + 1; j < dados.Length; j++)
            {
                int[] copia = (int[])dados.Clone();
                copia[i] = 7 - copia[i];
                copia[j] = 7 - copia[j];
                variantes.Add(copia);
            }
        }

        return variantes;
    }

    // metodos de ayuda
    private bool EsEscaleraNatural(int[] dados)
    {
        int[] ordenados = dados.Distinct().OrderBy(d => d).ToArray();

        return ordenados.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) ||
               ordenados.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }) ||
               ordenados.SequenceEqual(new int[] { 1, 3, 4, 5, 6 });
    }

    private bool EsFullNatural(int[] dados)
    {
        var grupos = dados.GroupBy(d => d)
                          .Select(g => g.Count())
                          .OrderBy(c => c)
                          .ToArray();

        return grupos.SequenceEqual(new int[] { 2, 3 });
    }

    // estructura 123456
    public int CalcularNumeros(int[] dados, int numero)
    {
        int cantidadNaturales = dados.Count(d => d == numero);

        int numeroOpuesto = 7 - numero;
        int cantidadVolteables = dados.Count(d => d == numeroOpuesto);

        // Máximo se pueden volcar 2 dados
        int volcadosUsados = Math.Min(cantidadVolteables, 2);

        int cantidadTotal = cantidadNaturales + volcadosUsados;

        return cantidadTotal * numero;
    }

    // escala
    public int CalcularEscalera(int[] dados, bool fueDeMano, bool permitirVuelcos)
    {
        if (EsEscaleraNatural(dados))
        {
            return fueDeMano ? 25 : 20;
        }

        if (!permitirVuelcos)
        {
            return 0;
        }

        foreach (int[] variante in GenerarVariantesConVuelcos(dados))
        {
            if (EsEscaleraNatural(variante))
            {
                return 20;
            }
        }

        return 0;
    }

    //logicafull
    public int CalcularFull(int[] dados, bool fueDeMano, bool permitirVuelcos)
    {
        if (EsFullNatural(dados))
        {
            return fueDeMano ? 35 : 30;
        }

        if (!permitirVuelcos)
        {
            return 0;
        }

        foreach (int[] variante in GenerarVariantesConVuelcos(dados))
        {
            if (EsFullNatural(variante))
            {
                return 30;
            }
        }

        return 0;
    }

    // logicapoker
    public int CalcularPoker(int[] dados, bool fueDeMano, bool permitirVuelcos)
    {
        // Primero revisamos Poker natural
        bool esPokerNatural = dados.GroupBy(d => d).Any(g => g.Count() >= 4);

        if (esPokerNatural)
        {
            return fueDeMano ? 45 : 40;
        }

        // Si todavía no se permiten vuelcos, devuelve 0
        if (!permitirVuelcos)
        {
            return 0;
        }

        // Revisamos Poker usando máximo 2 vuelcos
        foreach (int[] variante in GenerarVariantesConVuelcos(dados))
        {
            bool esPoker = variante.GroupBy(d => d).Any(g => g.Count() >= 4);

            if (esPoker)
            {
                return 40;
            }
        }

        return 0;
    }



    // grandeishon
    public bool EsGrande(int[] dados)
    {
        return dados.Distinct().Count() == 1;
    }

    // grandeishon 2
    public int CalcularGrande(int[] dados, bool fueDeMano, bool permitirVuelcos)
    {
        if (EsGrande(dados))
        {
            return 50;
        }

        if (!permitirVuelcos)
        {
            return 0;
        }

        foreach (int[] variante in GenerarVariantesConVuelcos(dados))
        {
            if (variante.Distinct().Count() == 1)
            {
                return 50;
            }
        }

        return 0;
    }
}
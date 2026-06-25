using System.Linq;

public class CalculadoraPuntajes
{
    public int CalcularNumeros(int[] dados, int numero)
    {
        return dados.Count(d => d == numero) * numero;
    }

    public int CalcularEscalera(int[] dados, bool fueDeMano)
    {
        int[] ordenados = dados.Distinct().OrderBy(d => d).ToArray();
        bool esEscalera = ordenados.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) ||
                          ordenados.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }) ||
                          ordenados.SequenceEqual(new int[] { 1, 3, 4, 5, 6 });

        if (!esEscalera) return 0;
        return fueDeMano ? 25 : 20;
    }

    public int CalcularFull(int[] dados, bool fueDeMano)
    {
        var grupos = dados.GroupBy(d => d).ToList();
        bool esFull = grupos.Count == 2 && (grupos[0].Count() == 3 || grupos[0].Count() == 2);

        if (!esFull) return 0;
        return fueDeMano ? 35 : 30;
    }

    public int CalcularPoker(int[] dados, bool fueDeMano)
    {
        var grupos = dados.GroupBy(d => d).ToList();
        bool esPoker = grupos.Any(g => g.Count() >= 4);

        if (!esPoker) return 0;
        return fueDeMano ? 45 : 40;
    }

    public bool EsGrande(int[] dados)
    {
        return dados.Distinct().Count() == 1;
    }

    public int CalcularGrande(int[] dados)
    {
        return EsGrande(dados) ? 50 : 0;
    }
}
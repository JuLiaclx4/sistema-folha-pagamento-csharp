using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("--- FOLHA DE PAGAMENTO ---");

            Console.Write("Digite o Nome: ");
            string nomeFunc = Console.ReadLine();

            Console.Write("Digite o Salário Bruto: ");
            decimal SB = Convert.ToDecimal(Console.ReadLine());

            if (SB <= 0)
            {
                Console.WriteLine("Valor incorreto! Digite valores acima de 0.");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("\n... processando ...\n");

            decimal descINSS = CalcularINSS(SB);
            decimal descIRRF = CalcularIRRF(SB - descINSS);
            decimal SL = SB - descINSS - descIRRF;

            ExibirHolerite(nomeFunc, SB, descINSS, descIRRF, SL);

            Console.Write("\nNovo cálculo? [S/N]: ");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta != "S")
                continuar = false;
        }
    }
    static decimal CalcularINSS(decimal SB)
    {
        if (SB <= 1300)
            return SB * 0.075m;
        else if (SB <= 2500)
            return SB * 0.09m;
        else if (SB <= 3900)
            return SB * 0.12m;
        else
            return SB * 0.14m;
    }

    static decimal CalcularIRRF(decimal calculo)
    {
        if (calculo > 1900)
            return calculo * 0.075m;
        else
            return 0m;
    }
    static void ExibirHolerite(string nomeFunc, decimal bruto, decimal inss, decimal irrf, decimal liquido)
    {
        CultureInfo br = new CultureInfo("pt-BR");

        Console.WriteLine("======================================");
        Console.WriteLine($"FOLHA: {nomeFunc.ToUpper()}");
        Console.WriteLine($"(+) Salário Bruto: {bruto.ToString("C", br)}");
        Console.WriteLine($"(-) Desconto INSS: {inss.ToString("C", br)}");
        Console.WriteLine($"(-) Desconto IRRF: {irrf.ToString("C", br)}");
        Console.WriteLine("======================================");
        Console.WriteLine($"(=) Salário Líquido: {liquido.ToString("C", br)}");
    }
}
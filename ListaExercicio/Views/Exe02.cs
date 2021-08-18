using System;
using System.Net;
using System.Text.Json;

namespace ListaExercicio.Views
{
    public class Exe02
    {
        public static void Renderizar()
        {
            const double VALOR_DOLAR_ATUAL = 5.17;
            double real, dolar;
            Console.WriteLine("Digite o valor em R$:");
            real = Convert.ToDouble(Console.ReadLine());
            dolar = real / VALOR_DOLAR_ATUAL;
            Console.WriteLine($"Dolar: { dolar.ToString("F2") } ");
            // WebClient client = new WebClient();
            // dynamic cep = client.DownloadString("https://viacep.com.br/ws/01001000/json/");
            // Console.WriteLine(cep);
        }
    }
}
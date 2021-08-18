using System;

namespace ListaExercicio.Views
{
    public class Exe06
    {
        const int VALOR_MAXIMO = 1001;
        const int TAMANHO_VETOR = 100;
        public static void Renderizar()
        {
            Random random = new Random();
            int[] numeros = new int[TAMANHO_VETOR];

            //Popular o vetor com valores aleatórios
            for (int i = 0; i < TAMANHO_VETOR; i++)
            {
                numeros[i] = random.Next(VALOR_MAXIMO);
            }

            //Imprimir o vetor sem ordenação
            foreach (int numero in numeros)
            {
                Console.Write($"{ numero } ");
            }
            Console.WriteLine("\n");

            //Ordenar o vetor automaticamente
            //Array.Sort(numeros);

            //Ordenar o vetor utilizando o bubble sort
            bool troca = false;
            do
            {
                troca = false;
                for (int i = 0; i < TAMANHO_VETOR - 1; i++)
                {
                    if (numeros[i] > numeros[i + 1])
                    {
                        int aux = numeros[i];
                        numeros[i] = numeros[i + 1];
                        numeros[i + 1] = aux;
                        troca = true;
                    }
                }
            } while (troca);

            //Imprimir o vetor ordenado
            foreach (int numero in numeros)
            {
                Console.Write($"{ numero } ");
            }
        }
    }
}
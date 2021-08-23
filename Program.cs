using Refit;
using System;
using System.Threading.Tasks;
namespace ApiRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {

            while (true)
            {
                try
                {
                    
                    var cepClient = RestService.For<ConsumeApi>("https://brasilapi.com.br/api");
                    Console.Write("Informe o CEP: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string cepInformado = Console.ReadLine().ToString();
                    Console.ResetColor();

                    var address = await cepClient.GetAddressAsync(cepInformado);
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Estado: {address.State}");
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Cidade: {address.City}");
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Bairro: {address.Neighborhood}");
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Logradouro: {address.Street}");
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine($"Serviço utilizado: {address.Service}");
                    Console.WriteLine("".PadRight(60, '-'));
                    Console.WriteLine("\n\nDeseja continuar? [Y/N] ");
                    char opc = Convert.ToChar(Console.ReadLine());
                    if (opc == 'Y' || opc == 'y')
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Erro na consulta do CEP\n{e.Message}\n");
                    Console.ResetColor();
                }
            }
        }
    }
}

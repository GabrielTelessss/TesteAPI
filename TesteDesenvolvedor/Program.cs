using System.Text;
using Newtonsoft.Json;
using TesteDesenvolvedor;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Por favor, selecione uma opção:");
        Console.WriteLine("1. Cliente");
        Console.WriteLine("2. Condutor");
        Console.WriteLine("3. Deslocamento");
        Console.WriteLine("4. Veiculo");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                await Cliente();
                break;
            case "2":
                Condutor();
                break;
            case "3":
                Deslocamento();
                break;
            case "4":
                Veiculo();
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, selecione uma opção entre 1 e 4.");
                break;
        }
    }

    static async Task Cliente()
    {
        HttpClient client = new HttpClient();
        Console.WriteLine("Você selecionou Cliente.");

        Console.WriteLine("Você prefere realizar um GET(1), POST(2), PUT(3) ou DELETE(4)?");
        string metodo = Console.ReadLine();

        var url = "https://api-deslocamento.herokuapp.com/api/v1/Cliente";

        if (metodo.ToUpper() == "1")
        {
            Console.WriteLine("Por favor, digite o ID do Cliente");
            string idCliente = Console.ReadLine();

            var urlCliente = $"{url}/{idCliente}";

            var respotaGet = await client.GetAsync(urlCliente);

            if (respotaGet.IsSuccessStatusCode)
            {
                string resultaGet = await respotaGet.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta GET: ");
                Console.WriteLine(resultaGet);
            }
            else
            {
                Console.WriteLine($"Erro na requisição GET: {respotaGet.StatusCode}");
            }
        }
        else if (metodo.ToUpper() == "2")
        {
            Console.WriteLine("Por favor, insira o número do documento:");
            string numeroDocumento = Console.ReadLine();

            Console.WriteLine("Por favor, insira o tipo do documento:");
            string tipoDocumento = Console.ReadLine();

            Console.WriteLine("Por favor, insira o nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Por favor, insira o logradouro:");
            string logradouro = Console.ReadLine();

            Console.WriteLine("Por favor, insira o número:");
            string numero = Console.ReadLine();

            Console.WriteLine("Por favor, insira o bairro:");
            string bairro = Console.ReadLine();

            Console.WriteLine("Por favor, insira a cidade:");
            string cidade = Console.ReadLine();

            Console.WriteLine("Por favor, insira a UF:");
            string uf = Console.ReadLine();

            var cliente = new TesteDesenvolvedor.HttpCliente
            {
                NumeroDocumento = numeroDocumento,
                TipoDocumento = tipoDocumento,
                Nome = nome,
                Logradouro = logradouro,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf
            };

            var jsonData = JsonConvert.SerializeObject(cliente);
            var conteudo = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var respostaPost = await client.PostAsync(url, conteudo);

            if (respostaPost.IsSuccessStatusCode)
            {
                string resultadoPost = await respostaPost.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta POST:");
                Console.WriteLine(resultadoPost);
            }
            else
            {
                Console.WriteLine($"Erro na requisição POST: {respostaPost.StatusCode}");
            }
        }
        else if (metodo.ToUpper() == "3")
        {
            Console.WriteLine("Por favor, digite o ID do Cliente");
            string id = Console.ReadLine();
            string idCliente = Console.ReadLine();

            var urlCliente = $"{url}/{id}";

            Console.WriteLine("Por favor, insira o novo número do documento:");
            string numeroDocumento = Console.ReadLine();

            Console.WriteLine("Por favor, insira o novo tipo do documento:");
            string tipoDocumento = Console.ReadLine();

            Console.WriteLine("Por favor, insira o novo nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Por favor, insira o novo logradouro:");
            string logradouro = Console.ReadLine();

            Console.WriteLine("Por favor, insira o novo número:");
            string numero = Console.ReadLine();

            Console.WriteLine("Por favor, insira o novo bairro:");
            string bairro = Console.ReadLine();

            Console.WriteLine("Por favor, insira a nova cidade:");
            string cidade = Console.ReadLine();

            Console.WriteLine("Por favor, insira a nova UF:");
            string uf = Console.ReadLine();

            var cliente = new TesteDesenvolvedor.HttpCliente
            {
                NumeroDocumento = numeroDocumento,
                TipoDocumento = tipoDocumento,
                Nome = nome,
                Logradouro = logradouro,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                UF = uf,
                Id = id
            };

            var jsonData = JsonConvert.SerializeObject(cliente);
            var conteudo = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var respostaPut = await client.PutAsync(urlCliente, conteudo);

            if (respostaPut.IsSuccessStatusCode)
            {
                string resultadoPut = await respostaPut.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta PUT:");
                Console.WriteLine(resultadoPut);
            }
            else
            {
                Console.WriteLine($"Erro na requisição PUT: {respostaPut.StatusCode}");
            }
        }
    }

    static async Task Condutor()
    {
        HttpCondutor contudor = new HttpCondutor();
        Console.WriteLine("Você selecionou Condutor");

        Console.WriteLine("Você prefere realizar um GET(1), POST(2) ou PUT(3)");
        string metodo = Console.ReadLine();

        var url = "https://api-deslocamento.herokuapp.com/api/v1/Condutor";
        if (metodo.ToUpper() == "1")
        {
            Console.WriteLine("Por gentileza, digita o ID do Contudor");
            string idContudor = Console.ReadLine();

            var urlContudor = $"{url}/{idContudor}";

            var respostaGet = await contudor.GetAsync(urlContudor);
            if (respostaGet.IsSuccessStatusCode)
            {
                string resultaGet = await respostaGet.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta Get: ");
            }

        }
    }

    static void Deslocamento()
    {
        Console.WriteLine("Você selecionou Deslocamento.");
        // Insira aqui o código para lidar com a opção Deslocamento
    }

    static void Veiculo()
    {
        Console.WriteLine("Você selecionou Veiculo.");
        // Insira aqui o código para lidar com a opção Veiculo
    }
}

using ControlF.Services;

Console.WriteLine("Informe o caminho do arquivo:");
string caminho = Console.ReadLine();
;

int opcao = 0;


bool verificarExistencia = File.Exists(caminho);
while (verificarExistencia == false)
{
    Console.WriteLine("O arquivo não foi encontrado, informe novamente:");
    caminho = Console.ReadLine();
    verificarExistencia = File.Exists(caminho);
}

Buscador busca = new Buscador(caminho);


while (opcao != 4)
{
    Console.WriteLine("Digite a opção que você deseja:\n1- Buscar texto;\n2- Buscar linha do texto;\n3- Substituir texto do arquivo;\n4- Sair do programa.");
    opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            Console.WriteLine("Informe o texto que você deseja buscar: ");
            busca.VerificarExistencia(Console.ReadLine());
            break;
        case 2:
            Console.WriteLine("Digite o texto que você deseja buscar a linha:");
            busca.BuscarPorLinhas(Console.ReadLine());
            break;
        case 3:
            Console.WriteLine("Digite o texto que você alterar:");
            string textoAntigo = Console.ReadLine();
            Console.WriteLine("Digite o texto que deve ser inserido:");
            string novoTexto = Console.ReadLine();
            busca.SubstituirTudo(textoAntigo, novoTexto);
            break;
        case 4:
            Console.WriteLine("Programa finalizado.");
            break;
        default:
            break;
    }
}




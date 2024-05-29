using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlF.Services
{
    public class Buscador
    {
        private string _caminho;
        public string Caminho
        {
            get => _caminho;
            set
            {
                if (value == "")
                {
                    throw new Exception("O caminho do arquivo não pode ser vazio");
                }
                else
                {
                    _caminho = value;
                }
            }
        }

        public List<string> Linhas { get; private set; }
        public Buscador(string caminho)
        {
            Caminho = caminho;
            Linhas = new List<string>(File.ReadAllLines(_caminho));
        }

        public bool VerificarArquivo()
        {
            if (!File.Exists(_caminho))
            {
                return false;
            }
            return true;
        }
        public void VerificarExistencia(string texto)
        {
            texto = texto.ToLower();
            int quantidade = 0;
            foreach (string linha in Linhas)
            {
                if (linha.ToLower().Contains(texto))
                {
                    quantidade += 1;
                }
            }
            if (quantidade > 0)
                Console.WriteLine($"\nO texto foi encontrado, ele foi identificado {quantidade} vezes no arquivo.\n");
            else
                Console.WriteLine("\nO texto não foi encontrado\n");
        }

        public void BuscarPorLinhas(string texto)
        {
            texto = texto.ToLower();
            List<int> lns = new List<int>();
            for (int i = 0; i < Linhas.Count; i++)
            {
                if (Linhas[i].ToLower().Contains(texto))
                {
                    lns.Add(i + 1);
                }
            }
            if (lns.Count > 0)
            {
                Console.WriteLine($"\nO texto foi identificado nas linhas:");
                foreach (int item in lns)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("\nO texto não foi encontrado");
        }

        public void SubstituirTudo(string textoAntigo, string novoTexto)
        {
            for (int i = 0; i < Linhas.Count; i++)
            {
                Linhas[i] = Linhas[i].Replace(textoAntigo, novoTexto);
            }

            File.WriteAllLines(_caminho, Linhas);
            Console.WriteLine("\nAlteração realizada com sucesso.");
        }
    }


}
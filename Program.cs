using System;
using System.Text;

class Program
{
    // Função para gerar a senha com base nas opções do usuário
    static string GerarSenha(int tamanho, bool usarNumeros, bool usarLetras, bool usarEspeciais)
    {
        string caracteres = "";
        
        // Incluir números
        if (usarNumeros)
            caracteres += "0123456789";
        
        // Incluir letras
        if (usarLetras)
            caracteres += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        // Incluir caracteres especiais
        if (usarEspeciais)
            caracteres += "!@#$%^&*()-_=+[]{}|;:'\",.<>?/~`";
        
        // Garantir que pelo menos um tipo de caractere foi escolhido
        if (caracteres.Length == 0)
            throw new ArgumentException("Pelo menos um tipo de caractere deve ser selecionado!");
        
        StringBuilder senha = new StringBuilder();
        Random random = new Random();

        // Gerar a senha aleatória
        for (int i = 0; i < tamanho; i++)
        {
            int index = random.Next(caracteres.Length);
            senha.Append(caracteres[index]);
        }

        return senha.ToString();
    }

    // Função principal
    static void Main()
    {
        Console.WriteLine("Gerador de Senhas Seguras");

        // Solicitar ao usuário o tamanho da senha
        Console.Write("Digite o tamanho da senha desejada: ");
        int tamanho = int.Parse(Console.ReadLine());

        // Perguntar se o usuário quer incluir números, letras e caracteres especiais
        Console.Write("Deseja incluir números (0-9)? (S/N): ");
        bool usarNumeros = Console.ReadLine().Trim().ToLower() == "s";
        
        Console.Write("Deseja incluir letras (a-zA-Z)? (S/N): ");
        bool usarLetras = Console.ReadLine().Trim().ToLower() == "s";
        
        Console.Write("Deseja incluir caracteres especiais (@, !, #, etc)? (S/N): ");
        bool usarEspeciais = Console.ReadLine().Trim().ToLower() == "s";

        try
        {
            // Gerar a senha com as especificações fornecidas
            string senha = GerarSenha(tamanho, usarNumeros, usarLetras, usarEspeciais);
            Console.WriteLine($"Senha gerada: {senha}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

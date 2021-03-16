using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace files_module
{
    class Program
    {
        /*
        **** https://docs.microsoft.com/pt-br/learn/modules/dotnet-files/ ****

        //*Determinar o diretório atual
        Console.WriteLine(Directory.GetCurrentDirectory());
        //
        //*Trabalhar com diretórios especiais
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //
        //*Trabalhar com caminhos
        Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
        //
        //*Caminhos de junção
        Console.WriteLine(Path.Combine("stores", "201")); // outputs: stores/201
        //
        //*Determinar as extensões de nome de arquivo
        Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json
        //
        //*Tudo que você precisa saber sobre um arquivo ou caminho
        string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
        FileInfo info = new FileInfo(fileName);
        Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
        //
        */
        static void Main(string[] args)
        {
            //Criar diretórios
            //Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));

            //Verificar se os diretórios existem
            //bool doesDirectoryExists = Directory.Exists(filePath);

            //Criar arquivos
            //File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
            var currentDirectory = Directory.GetCurrentDirectory();

            var storesDirectory = Path.Combine(currentDirectory, "stores");

            //Criar o diretório SalesTotals
            var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
            Directory.CreateDirectory(salesTotalDir);

            var salesFiles = FindFiles(storesDirectory);

            //Chamar o método CalculateSalesTotals
            var salesTotal = CalculateSalesTotal(salesFiles);

            //Gravar o arquivo totals.txt, Gravar o total no arquivo totals.txt
            File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

            /*foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }
            */

        }
        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
            {
                var extension = Path.GetExtension(file);

                if (extension == ".json")
                {
                    salesFiles.Add(file);
                }
            }

            return salesFiles;
        }

        //Preparação para dados de vendas
        class SalesData
        {
            public double Total { get; set; }
        }

        //Criar um método para calcular os totais de vendas
        static double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            // Loop over each file path in salesFiles
            foreach (var file in salesFiles)
            {
                // Read the contents of the file
                string salesJson = File.ReadAllText(file);

                // Parse the contents as JSON
                SalesData data = JsonConvert.DeserializeObject<SalesData>(salesJson);

                // Add the amount found in the Total field to the salesTotal variable
                salesTotal += data.Total;
            }

            return salesTotal;
        }


    }
}

using CommandLine;
using System;

namespace FileProptelin
{
    class Program
    {
        public class Options
        {
            [Option('f', "file", Required = true, HelpText = "ファイル指定")]
            public string FilePath { get; set; }

            [Option('d', "date", Required = true, HelpText = "対象のファイルの更新後の日付指定")]
            public DateTime DateTime { get; set; }
        }

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    var creationTime = System.IO.File.GetCreationTime(o.FilePath);

                    Console.WriteLine($"対象ファイル: {o.FilePath}");
                    Console.WriteLine($"作成日: {creationTime}");
                    Console.WriteLine("+-------+-------+-------+-------+");
                    System.IO.File.SetCreationTime(o.FilePath, o.DateTime);
                    Console.WriteLine($"成功: {creationTime} -> {o.DateTime}");
                });
        }
    }
}

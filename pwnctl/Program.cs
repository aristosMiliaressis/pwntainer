using Cocona;
using pwnctl.Persistence;
using pwnctl.Importers;
using pwnctl.Services;
using System;
using System.Collections.Generic;

var app = CoconaApp.Create();

app.AddCommand("query", () => 
    { 
        var queryRunner = new QueryRunner(PwntainerDbContext.ConnectionString);
        var input = new List<string>();

        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            input.Add(line);
        }

        queryRunner.Run(string.Join("\n", input));
    }
).WithDescription("Query mode (reads SQL from stdin executes and prints output to stdout)");

app.AddCommand("process", async () => 
    {
        var assetService = new AssetService();

        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            await assetService.ProcessAsync(line);
        }
    }
).WithDescription("Asset processing mode (reads assets from stdin)");

app.AddSubCommand("import", x =>
    {  
        x.AddCommand("csv-burp", async ( [Argument(Description = "path to burp csv file.")] string file ) 
        => {
            await BurpSuiteImporter.ImportAsync(file);
        }).WithDescription("BurpSuite CSV Import mode");
    }
).WithDescription("Import mode");

// app.AddSubCommand("list", x => 
// {
//     x.AddCommand("ips", () => );
//     x.AddCommand("urls", () => );
//     x.AddCommand("domains", () => );
//     x.AddCommand("ports", () => );
// }
// ).WithDescription("Import mode");

app.Run();

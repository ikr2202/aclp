var logicFiles = new List<string>();
var files = Directory.GetFiles(Environment.CurrentDirectory, "*.*", SearchOption.AllDirectories);

foreach (var f in files)
{
    if (f.EndsWith(".acl"))
    {
        logicFiles.Add(f);
    }
}

if (args.Length > 0)
{
    if (args[0] == "-h")
    {
        PrintHelp();
    }
    else if (args[0] == "-b")
    {
        var distPath = $"{Environment.CurrentDirectory}/output.txt";
        if (args.Length > 1)
            distPath = args[1];

        if (File.Exists(distPath))
            File.Delete(distPath);

        using (var stream = new FileStream(distPath, FileMode.OpenOrCreate))
        {
            using (var writer = new StreamWriter(stream))
            {
                var i = 0;
                foreach (var lf in logicFiles)
                {
                    using (var reader = new StreamReader(lf))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            int commentIndex = line.IndexOf("//");
                            if (commentIndex != -1)
                            {
                                line = line.Substring(0, commentIndex);
                            }

                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                Console.WriteLine($"[{i + 1}] " + line + "");
                                writer.WriteLine(line);
                                i++;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Compiled");
    }
}
else
    PrintHelp();

void PrintHelp()
{
    Console.Write("""
    ACLP v1.0.0

    -h: help
    -b: build

    -b can also have another optional argument
    where you specify the output path. see examples

    examples:
    aclp -h
    aclp -b
    aclp -b "C:\Documents\Aottg2\CustomLogic\Cl.txt"
    """);
}
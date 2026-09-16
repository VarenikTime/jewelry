using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace projectsoftserve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string jsonFilePath = "input.json";

                if (!File.Exists(jsonFilePath))
                {
                    return;
                }

                string jsonContent = File.ReadAllText(jsonFilePath);
                List<JewelryShop> shops = JsonSerializer.Deserialize<List<JewelryShop>>(jsonContent);

                if (shops == null)
                {
                    return;
                }

                Dictionary<string, int> metalCounts = new Dictionary<string, int>();

                foreach (var shop in shops)
                {
                    foreach (var item in shop.Items)
                    {
                        if (metalCounts.ContainsKey(item.Metal))
                        {
                            metalCounts[item.Metal]++;
                        }
                        else
                        {
                            metalCounts[item.Metal] = 1;
                        }
                    }
                }

                List<string> metalReportLines = new List<string>();
                foreach (var pair in metalCounts)
                {
                    metalReportLines.Add($"{pair.Key}: {pair.Value}");
                }

                File.WriteAllLines("metals_report.txt", metalReportLines);

                List<string> sortedItemsLines = new List<string>();

                foreach (var shop in shops)
                {
                    double totalSum = shop.Items.Sum(x => x.Price);

                    if (totalSum >= 500)
                    {
                        sortedItemsLines.Add($"Shop Address: {shop.Address} (Total Sum: {totalSum})");

                        var sortedItems = shop.Items.OrderBy(x => x.Name).ToList();

                        foreach (var item in sortedItems)
                        {
                            sortedItemsLines.Add($"   Name: {item.Name}, Metal: {item.Metal}, Weight: {item.Weight}, Price: {item.Price}");
                        }

                        sortedItemsLines.Add("");
                    }
                }

                File.WriteAllLines("filtered_items.txt", sortedItemsLines);

                Process.Start(new ProcessStartInfo
                {
                    FileName = AppDomain.CurrentDomain.BaseDirectory,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.log", ex.ToString());
            }
        }
    }
}
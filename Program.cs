using Newtonsoft.Json;
using PaymentsReconciliation.Model;
using PaymentsReconciliation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PaymentsReconciliation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            View.View.PrintWelcomeMessage();

            string workingDirectory = SystemGeneral.GetWorkingDirectory();
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string projectDirectory = SystemGeneral.GetProjectDirectory();
            const string dataFolderName = "Data";
            string dataFolderPath = Path.Combine(projectDirectory, dataFolderName);


            // Payments.json
            const string filenamePaymentsJson = "Payments.json";
            string paymentsJsonFilePath = Path.Combine(dataFolderPath, filenamePaymentsJson);
            string paymentsJsonFile = System.IO.File.ReadAllText(paymentsJsonFilePath);
            List<Payment> payments = JsonConvert.DeserializeObject<List<Payment>>(paymentsJsonFile);


            // Prices.xml
            string pricesFile = System.IO.File.ReadAllText("C:\\Dev\\CSharp\\PaymentsReconciliation\\PaymentsReconciliation\\Data\\Prices.xml");
            string path = @"C:\Dev\CSharp\PaymentsReconciliation\PaymentsReconciliation\Data\Prices.xml";
            ItemPricesRoot itemPriceRoot = new ItemPricesRoot();
            XmlSerializer xs = new XmlSerializer(typeof(ItemPricesRoot));
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                itemPriceRoot = (ItemPricesRoot)xs.Deserialize(stream);
            }

            // Purchases.dat
            string purchasesFile = System.IO.File.ReadAllText("C:\\Dev\\CSharp\\PaymentsReconciliation\\PaymentsReconciliation\\Data\\Purchases.dat");
            string filename = @"C:\Dev\CSharp\PaymentsReconciliation\PaymentsReconciliation\Data\Purchases.dat";
            List<Purchase> purchases = new List<Purchase>();
            using (var reader = new StreamReader(filename))
            {
                //int codeStringLastPosition = 3;

                int purchasesPosition = 0;
                while (!reader.EndOfStream)
                {
                    var textLine = reader.ReadLine();
                    var code = textLine.Substring(0, 4);
                    var value = textLine.Substring(4, textLine.Length - 4);

                    switch (code)
                    {
                        case "CUST":
                            purchases.Add(new Purchase());
                            purchases[purchasesPosition].Cust = value;
                            purchasesPosition++;
                            break;
                        case "DATE":
                            purchases[purchasesPosition - 1].Date = DateTime.ParseExact(value.Substring(0, 8), "ddMMyyyy", CultureInfo.InvariantCulture);

                            purchases[purchasesPosition - 1].Month = purchases[purchasesPosition - 1].Date.Month;
                            purchases[purchasesPosition - 1].Year = purchases[purchasesPosition - 1].Date.Year;
                            break;
                        case "ITEM":
                            purchases[purchasesPosition - 1].Item.Add(value);
                            break;
                        default:
                            break;

                    }
                }
            }

            // Add Amount (dued) to purchases
            foreach (var purhchase in purchases)
            {
                foreach (var i in purhchase.Item)
                {
                    purhchase.Amount += itemPriceRoot.ItemPricesList[int.Parse(i) - 1].Price;
                }
            }


            // Calculate Amount (payed) by customers
            var customersPays = payments.GroupBy(p => p.Customer)
                .Select(tab => new Payment
                {
                    Customer = tab.First().Customer,
                    Month = tab.Last().Month,
                    Year = tab.Last().Year,
                    Amount = tab.Sum(p => p.Amount),
                });

            // Calculate Amount (dued) by customers
            var customersAmountDued = purchases.GroupBy(p => p.Cust)
                .Select(tab => new Payment
                {
                    Customer = tab.First().Cust,
                    Month = tab.Last().Month,
                    Year = tab.Last().Year,
                    Amount = tab.Sum(p => p.Amount),
                });


            var paymentsNotMatchedNotFiltered =
                from dued in customersAmountDued
                join pays in customersPays
                on dued.Customer equals pays.Customer
                select new
                {
                    id = pays.Customer,
                    year = dued.Year >= pays.Year ? dued.Year : pays.Year,
                    month = dued.Month >= pays.Month ? dued.Month : pays.Month,
                    amountDued = dued.Amount,
                    amountPayed = pays.Amount,
                    differenceAmount = dued.Amount - pays.Amount
                };

            var paymentsNotMatchedFiltered =
                from pos in paymentsNotMatchedNotFiltered
                where pos.differenceAmount != 0
                orderby pos.differenceAmount descending
                select pos;

            const string paymentsNotMatchedJson = "PaymentsNotMatched.json";
            string downloadFolderPath = System.IO.Path.Combine(GetHomePath(), "Downloads");
            string paymentsNotMatchedFilteredJsonFilePath = System.IO.Path.Combine(downloadFolderPath, paymentsNotMatchedJson);
            Model.DataSerializer.JsonSerialize(paymentsNotMatchedFiltered, paymentsNotMatchedFilteredJsonFilePath);

            View.View.PrintWait();


        }



        public static string GetHomePath()
        {
            // NOTE Not in .NET 2.0
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                return System.Environment.GetEnvironmentVariable("HOME");

            return System.Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        }


        public static string GetDownloadFolderPath()
        {
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            {
                string pathDownload = System.IO.Path.Combine(GetHomePath(), "Downloads");
                return pathDownload;
            }

            return System.Convert.ToString(
                Microsoft.Win32.Registry.GetValue(
                     @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
                    , "{374DE290-123F-4565-9164-39C4925E467B}"
                    , String.Empty
                )
            );
        }


        //private static void JsonSerialize(object data, string filePath)
        //{
        //    JsonSerializer jsonSerializer = new JsonSerializer();

        //    if (File.Exists(filePath))
        //    {
        //        File.Delete(filePath);
        //    }

        //    StreamWriter sw = new StreamWriter(filePath);
        //    JsonWriter jsonWriter = new JsonTextWriter(sw);

        //    jsonSerializer.Serialize(jsonWriter, data);

        //    sw.Close();

        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace RegexPractice
{
    class Program
    {
        int item_count = 0;

        public void MatchEngine(string text, ItemLog log)
        {
            Item item = new Item();
            item.Name = "";
            item.Price = 0;
            item.Adress = "";
            int price = 0;
            string adress;


            Console.WriteLine("\n\n\n---------------------"+(++item_count)+"----------------------------");
            /*
             *Item  Name 
             * 
             */

            string pattern = "<span\\sclass=\"num-icon\\snum-[beds|baths|reception].*?\\stitle=\"(?<data>.*?)\">";

            Regex regixObj = new Regex(pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);
            foreach (Match i in regixObj.Matches(text))
            {
                
                item.Name += i.Groups["data"].Value.Replace(",", "-");

            }
            Console.WriteLine("Name:" + item.Name );
            /*
             * Adding Price Here
             * 
             */


            pattern = "class=\"listing-results-price.*?(?<data>&pound;[,|\\d]*).*?</a>";
            regixObj = new Regex(pattern, RegexOptions.Singleline);
            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Price : " + i.Groups["data"].Value + "\n\n");
                string temp = i.Groups["data"].Value.Replace("&pound;", "");
                string tempstring = temp.Replace(",", "");

                int.TryParse(tempstring, out price);
                item.Price = price;
            }







            /*
             * Adding Item Adress
             * 
             * 
             */
            pattern = "<a itemprop=\"streetAddress\"";
            string AppendingPattern = @".*?>(?<data>.*?)</a>";

            regixObj = new Regex(pattern + AppendingPattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);
            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Adress : " + i.Groups["data"].Value + "\n\n");
                adress = i.Groups["data"].Value.Replace(",", "-");
                item.Adress = adress;

            }





            /*Adding Item Company
             * 
             */

            pattern = "<img src=\".*?alt=\"(?<data>.*?)\".*?>";

            regixObj = new Regex(pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);
            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Company : " + i.Groups["data"].Value + "\n\n");
                item.Description = i.Groups["data"].Value.Replace(",", "-");


            }








            /*Adding Item Image
            * 
            */

            pattern = "<img src=\"(?<data>http://st.zoocdn.com/zoopla_static_agent_logo.*?)\"";

            regixObj = new Regex(pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);

            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Image: " + i.Groups["data"].Value + "\n\n");
                item.Image = i.Groups["data"].Value.Replace(",", "-");
                item.Image.Replace(",", "-");
            }
            Console.WriteLine("-------------------------------------------------------------");

            log.Add(item);

        }




        static void Main(string[] args)
        {
            Program p = new Program();
            ItemLog log = new ItemLog();

            using (WebClient w = new WebClient())
            {
                w.Headers["User-Agent"] =

        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
        "(compatible; MSIE 6.0; Windows NT 5.1; " +
        ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                // Download data.
                string uri = w.DownloadString("http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&include_shared_ownership=true&new_homes=include&q=BL9&results_sort=newest_listings&search_source=for-sale&page_size=24&pn=1&view_type=grid");
                string Checking = @"(<li data-listing-id=.*?>(?<data>.*?)</li>)";


                Regex r = new Regex(Checking, RegexOptions.Singleline);



                foreach (Match i in r.Matches(uri))
                {
                    //      Console.WriteLine("DIV FOUND Successfully.." + i.Groups["data"].Value + "\n\n\n\n");
                    p.MatchEngine(i.Groups["data"].Value, log);
                }

                string filePath = "d://" + "TASK1_ITEMS.csv";

                File.Delete(filePath);
                File.Create(filePath).Close();


                StringBuilder sb = new StringBuilder();
                string headerLine = "name,Company,Image Source,Adress,price(Euro),\n";

                File.AppendAllText(filePath, headerLine);


                foreach (Item i in log.itemList)
                {
                    sb = null;
                    sb.AppendLine(i.Name + "," + i.Description + "," + i.Image + "," + i.Adress + "," + i.Price);
                    File.AppendAllText(filePath, sb.ToString());

                }


            }

            //    Console.WriteLine(uri);

        }


    }
}


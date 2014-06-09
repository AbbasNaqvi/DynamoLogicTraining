using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.IO;


/*DynamoLogic
 * Author :Abbas Naqvi
 * Created: 4th May,2014
 * Last Modified :6th May 2014
 */

namespace TaskTwo
{
    class ScrapingWorker
    {
        WebClient w;
        String locked = "false";
        readonly string uri;
        readonly string Checking;
        string filePath;

        public ScrapingWorker()
        {

        }
        public ScrapingWorker(string filepath, string link)
        {

            w = new WebClient();
            try
            {
                uri = w.DownloadString(link);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            Checking = @"(<li data-listing-id=.*?>(?<data>.*?)</li>)";
            filePath = filepath;
        }
        public void MatchEngine(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }

            Item item = new Item();
            item.Name = "";
            item.Price = 0;
            item.Adress = "";
            int price = 0;
            string adress;



            /*
             *Item  Name 
             * 
             */

            string pattern = "<span\\sclass=\"num-icon\\snum-[beds|baths|reception].*?\\stitle=\"(?<data>.*?)\">";

            Regex regixObj = new Regex(pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);
            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Name Found   .... " + i.Groups["data"].Value + "\n\n\n\n");
                item.Name += i.Groups["data"].Value.Replace(",", "-");

            }

            /*
             * Adding Price Here
             * 
             */


            pattern = "class=\"listing-results-price.*?(?<data>&pound;[,|\\d]*).*?</a>";
            regixObj = new Regex(pattern, RegexOptions.Singleline);
            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Price Matched   .... " + i.Groups["data"].Value + "\n\n\n\n");
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
                Console.WriteLine("Adress Found   .... " + i.Groups["data"].Value + "\n\n\n\n");
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
                Console.WriteLine("Company Matched   .... " + i.Groups["data"].Value + "\n\n\n\n");
                item.Description = i.Groups["data"].Value.Replace(",", "-");
            }
            /*Adding Item Image
            * 
            */

            pattern = "<img src=\"(?<data>http://st.zoocdn.com/zoopla_static_agent_logo.*?)\"";

            regixObj = new Regex(pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant);

            foreach (Match i in regixObj.Matches(text))
            {
                Console.WriteLine("Image Matched   .... " + i.Groups["data"].Value + "\n\n\n\n");
                item.Image = i.Groups["data"].Value.Replace(",", "-");
                item.Image.Replace(",", "-");
            }

            //Critical Section because it can be accessed while File Writing by any other Thread 
            lock (ItemLog.itemList)
            {
                if (ItemLog.itemList.Contains(item) == false)
                    ItemLog.itemList.Add(item);
            }
        }

        /*
         * 
         * Critical Section
         * Reason :It is called at two places .It may be accessed Concurrently.
         * 
         */ 

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string WriteTheList()
        {

            /*
             * File Managment
             * 
             */


            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var ThisFile = File.Create(filePath);
                ThisFile.Close();
            }
            catch (IOException e)
            {
                return e.Message;
            }



            /*
             * 
             * Writing CSV file
             * 
             */


            StringBuilder sb = new StringBuilder();
            string headerLine = "name,Company,Image Source,Adress,price(Euro),\n";

            File.AppendAllText(filePath, headerLine);
            try
            {
                lock (ItemLog.itemList)
                {
                    foreach (Item i in ItemLog.itemList)
                    {
                        sb.Clear();

                        sb.AppendLine(i.Name + "," + i.Description + "," + i.Image + "," + i.Adress + "," + i.Price);
                        lock (locked)
                        {
                            locked = "true";
                            File.AppendAllText(filePath, sb.ToString());
                            locked = "false";
                        }
                    }

                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
            return "true";
        }
        public string Maine()
        {
            if (String.IsNullOrEmpty(uri) || String.IsNullOrEmpty(Checking))
            {
                return null;
            }
            else
            {


            }
            using (w)
            {
                w.Headers["User-Agent"] =
        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
        "(compatible; MSIE 6.0; Windows NT 5.1; " +
        ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                // Download data.
                Regex r = new Regex(Checking, RegexOptions.Singleline);

                foreach (Match i in r.Matches(uri))
                {
                    //      Console.WriteLine("DIV FOUND Successfully.." + i.Groups["data"].Value + "\n\n\n\n");
                    MatchEngine(i.Groups["data"].Value);
                }
                WriteTheList();

                return null;
            }
        }
    }
}





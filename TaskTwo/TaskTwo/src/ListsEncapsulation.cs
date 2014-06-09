using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


/*DynamoLogic
 * Author :Abbas Naqvi
 * Created: 4th May,2014
 * Last Modified :6th May 2014
 */



namespace TaskTwo
{
    static class ListsEncapsulation
    {
        public static int DistributedPages;
        public static int DistributionLimit;
        private static List<string> pagesLinks;




        public static void Init()
        {
            pagesLinks = new List<string>();


            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&pn=1&page_size=24&view_type=grid");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=2");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=3");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=4");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=5");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=6");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=7");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=8");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=9");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=10");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=11");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=12");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=13");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=14");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=15");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=16");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=17");
            pagesLinks.Add(@"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=18");
            //endingPage
        }


        public static List<string> PagesLinks
        {
            get { return pagesLinks; }
            set { pagesLinks = value; }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string IsAnyLeft()
        {
                if (DistributedPages<=DistributionLimit)
            {
                string link = PagesLinks[DistributedPages];
                pagesLinks[DistributedPages] = "";
                DistributedPages++;
                return link;
            }
            else
            {
              
                return null;
            }
        }

    }

}

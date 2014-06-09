using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*DynamoLogic
 * Author :Abbas Naqvi
 * Created: 4th May,2014
 * Last Modified :4th May 2014
 */




namespace TaskTwo
{
    //    class ItemLog :ICollection<Item>
    static class ItemLog
    {
        public static HashSet<Item> itemList = new HashSet<Item>();

        public static void Add(string name, string description, int price, string adress, string image)
        {
            Item item = new Item();
            item.Name = name;
            item.Image = image;
            item.Description = description;
            item.Price = price;
            item.Adress = adress;
            foreach (var x in itemList)
            {
                if (x.Adress.Equals(adress))
                {
                    return;
                }
            }
            itemList.Add(item);
        }
    }
}

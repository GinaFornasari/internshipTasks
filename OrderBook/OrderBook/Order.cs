using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook
{
    public class Order
    {
        string symbol;
        long id;
        string side;
        string timestamp;
        long size; 
        long price;
        public Order(string symbol, long id, string side,string timestamp, long size, long price)
        {
            this.symbol = symbol;
            this.id = id;
            this.side = side;   
            this.timestamp = timestamp;
            this.size = size;
            this.price = price;
        }
        public string getOrder()
        {
            return symbol +" (ID: " + id +")"+ Environment.NewLine+side + " at " + price
                + Environment.NewLine+timestamp + "\tSize: " + size +Environment.NewLine; 
        }
    }
}

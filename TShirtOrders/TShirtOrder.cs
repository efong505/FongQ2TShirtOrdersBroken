// Edward Fong
// efong@cnm.edu
// TShirtOrder.cs
// Quiz 2
using System;

namespace TShirtOrders
{
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {
        public TShirtOrder(string firstName="",string lastName = "", string address = "", DateTime? orderDate=null,bool isLocalPickup=true, 
            double printAreaInSqIn=1, int numColors=1,int numShirts=1) //TODO: EF printAreaInSqIn had no value. Added 1 
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            OrderDate = orderDate;
            IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;
            this.numColors = numColors;
            this.numShirts = numShirts;
            Calc();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsLocalPickup { get; set; }
        private double printAreaInSqIn;
        public double PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }

        private int numColors;
        public int NumColors
        {
            get { return NumColors; }
            set { numColors = value; Calc(); } // TODO: EF NumColors set to NumColors. Should be set to the backing field. Created infinate loop
        }

        private int numShirts;
        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }
        public decimal Price {  get; set; } // TODO: EF Price get is set to private which has made it inaccessible. Removed private accessor
        private void Calc()
        {
            Price = (decimal)(numShirts * (numColors * 2.25 + printAreaInSqIn * .05)); //TODO: EF printAreaInSqIn is a double but Price is decimal. Cast calculated result to decimal 
        }
        public override string ToString()
        {
            
            return FirstName+" "
                +LastName+" "
               // +OrderDate.ToString()+" "
                +OrderDate?.ToString("MM/dd/yyyy HH:mm:ss")+" " // TODO: EF missing ? after OrderDate
                +" Price: "+Price.ToString("c");
        }
    }

}

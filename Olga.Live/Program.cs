namespace Olga.Live
{
    class Program
    {
        static void Main()
        {

            //int userAge = 25;
            //decimal productPrice = 99.99m;
            //bool isPaid = false;
            //char firstLetterName = 'O';

            //Console.WriteLine("Enter number");
            //var msg = Console.ReadLine();
            //bool isNumber = int.TryParse(msg, out var value);
            //if (isNumber==true)
            //{
            //    if (value > 0)
            //    {
            //        Console.WriteLine("Number positive");
            //    }
            //    else { Console.WriteLine("Number negative"); }
            //}
            //else {
            //    Console.WriteLine("Not number");
            //}

            decimal productPrice;
            int productCount;
            const int discountPercent = 15;
            decimal totalPrice;
            Console.WriteLine("Enter product price");
            string msg=Console.ReadLine();
            productPrice=decimal.Parse(msg);
            Console.WriteLine("Enter product count");
            msg=Console.ReadLine(); 
            productCount=int.Parse(msg);
            var subtotal = productPrice * productCount;
            var discount = subtotal * discountPercent / 100;
            var total = subtotal - discount;
            Console.WriteLine("discount= "+discount +" total= "+total); 


        }
    }
}
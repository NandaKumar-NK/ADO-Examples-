using Ado_Project;

class Program{ 
public static void Main(string[] args)
{

        //string region, branch, type_opt, trans_date;
        //int region_Id, customer_id, cust_balance;
        //Console.WriteLine("Enter Bank Region name:");
        //region = Console.ReadLine();
        //Console.WriteLine("Enter Bank Region id:");
        //region_Id = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter Customer id:");
        //customer_id = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter current balance:");
        //cust_balance = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter Bank branch name:");
        //branch= Console.ReadLine();
        //Console.WriteLine("Enter Bank type option debit/credit:");
        //type_opt = Console.ReadLine();
        //Console.WriteLine("Enter transaction date in yyyy/mm/dd");
        //trans_date = Console.ReadLine();
        //region, branch, type_opt, trans_date, region_Id, customer_id, cust_balance

        Connect connect = new Connect();
        connect.OpenConnection();
        //connect.CreateTable();
        // connect.InsertValues();
        //connect.calculation();
        //connect.qtn3();
        connect.qtn3();


}
}
using System.Data.SqlClient;
using System.Text;
namespace Ado_Project
{
    internal class Connect
    {
        SqlConnection conn;
        //private string region,branch,type_opt,trans_date;
        //private int region_Id,customer_id,cust_balance;
        //public Connect(string region,string branch,string type_opt,string trans_date, int region_Id,int customer_id,int cust_balance) 
        //{ 
        //    this.Region = region;
        //    this.Branch = branch;
        //    this.Type_opt = type_opt;
        //    this.Trans_date = trans_date;
        //    this.Region_Id = region_Id;
        //    this.Customer_id = customer_id; 
        //}    
        

        //public string Region { get => region; set => region = value; }
        //public string Branch { get => branch; set => branch = value; }
        //public string Type_opt { get => type_opt; set => type_opt = value; }
        //public string Trans_date { get => trans_date; set => trans_date = value; }
        //public int Region_Id { get => region_Id; set => region_Id = value; }
        //public int Customer_id { get => customer_id; set => customer_id = value; }
        //public int Cust_balance { get => cust_balance; set => cust_balance = value; }

        public void OpenConnection()
        {
            conn = new SqlConnection(@"data source = LAPTOP-KR3SF32I\SQLEXPRESS; " +
            "database=Bank;" +
            "integrated security=SSPI");
            try
            {
                conn.Open();
                Console.WriteLine("Opened");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        public void CreateTable()
        {
            SqlCommand cmd = new SqlCommand("Create table Region(region nvarchar(20) not null PRIMARY KEY,region_Id int )", conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Create table Customer_nodes(branch nvarchar(20) not null,region nvarchar(20) FOREIGN KEY REFERENCES Region," +
                "Customer_id  int PRIMARY KEY, Cust_balance int)", conn);
            cmd.ExecuteNonQuery();
             cmd = new SqlCommand("Create table Customer_Transaction( Customer_id  int FOREIGN KEY REFERENCES Customer_nodes,Transaction_Amt int," +
                "balance int , Trans_date date not null, type_opt nvarchar(20))", conn);

            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created");
            }

        }

       

        public void InsertValues()
        {
            SqlCommand cmd = new SqlCommand();
            //cmd = new SqlCommand("Insert into  Region values('Chennai',101),('coimbatore',102),('trichy',103),('madurai',104),('thirunelveli',105)", conn);
            //cmd = new SqlCommand("Insert into Customer_nodes  values('guindy','chennai',1001,15000),('maduravoyal','chennai',1002,25000)," +
              //  "('anna nagar','madurai',1003,5000),('rs puram','coimbatore',1004,17000),('alangulam','thirunelveli',1005,35000)," +
                //"('gandhi nagar','trichy',1006,27000),('mettupalayam','coimbatore',1007,15500)", conn);
           cmd = new SqlCommand("insert into Customer_Transaction values (1001,15000,'2023/01/02',5000,'credit'),(1002,5000,'2023/01/06',500,'debit)," +
               "(1003,500,'2022/01/16',500,'debit'),(1004,2500,'2022/01/05',5500,'debit'),(1005,1200,'2022/01/14',3500,'credit')," +
               "(1006,200,'2022/01/29',5500,'credit'),(1007,8500,'2022/01/09',6500,'credit')", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Values Inserted");
            }

        }

        public void qtn1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select r.region, count( distinct branch) node_counts from Customer_nodes c " +
                "inner join region r on c.region=r.region group by r.region",conn);
            
            SqlDataReader r=cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine(r[0] + " " + r[1]);
            }
        }

        public void qtn2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select r.region, count(distinct c.Customer_id) customer_counts from Customer_nodes c " +
                "inner join region r on c.region=r.region group by r.region",conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine(r[0] + " " + r[1]);
            }
        }

        public void qtn3()
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select count(*) Total_count , AVG(balance) Average_amount from " +
                "Customer_transaction where Type_of_Transaction='debit'", conn);
           
            SqlDataReader r = cmd.ExecuteReader();
            
            while (r.Read())
            {
                Console.WriteLine(r[0] + " " + r[1]);
            }
            r.Close();
            cmd = new SqlCommand("UPDATE Customer_Transaction  SET transaction_amount =  transaction_amount - balance  WHERE Type_of_Transaction='debit'", conn);
            cmd = new SqlCommand("UPDATE Customer_Transaction  SET transaction_amount =  transaction_amount + balance WHERE Type_of_Transaction='credit'", conn);

        }
        public void calculation()
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select*from Customer_Transaction", conn);
            //SqlDataReader r = cmd.ExecuteReader();
            // while(r.Read()){
           
                
                cmd = new SqlCommand("UPDATE Customer_Transaction  SET transaction_amount =  transaction_amount-balance  WHERE Type_of_Transaction='debit'", conn);
                cmd = new SqlCommand("UPDATE Customer_Transaction  SET transaction_amount =  transaction_amount + balance WHERE Type_of_Transaction='credit'", conn);

            
        }
        public void qtn4()
        {
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("select customer_id,transaction_amount from Customer_Transaction where Month(Date_of_Transaction)=01", conn);
            SqlDataReader r = cmd.ExecuteReader();
            
            while (r.Read())
            {
                Console.WriteLine(r[0] + " " + r[1]);
            }
            r.Close();
        }

        public void qtn5()
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(" select count(balance) increased_accounts from Customer_Transaction where Type_of_Transaction='credit';",conn);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                Console.WriteLine("Increased accounts count "+r[0] );
            }
            r.Close();
        }
    }
}

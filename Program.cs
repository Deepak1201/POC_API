using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POCAPI.Model;
using System.Data;

//var ConnectionString = ConfigurationBinder.("APIDB");
//Create the object of SqlConnection cl.ass to connect with database sql server
//using (SqlConnection conn = new SqlConnection()) {
//    //prepare conectio string
//    conn.ConnectionString = "Server =  CDC2-L93LDZ93; Database = assignment; Integrated Security = True; TrustServerCertificate=True; ";
//    try
//    { //Prepare SQL command that we want to query
//        SqlCommand cmd = new SqlCommand();
//        cmd.CommandType = CommandType.Text;
//        // cmd.CommandText = "SELECT * FROM MYTABLE";
//        cmd.CommandText = "SELECT ProductID FROM Product";
//        cmd.Connection = conn;
//        conn.Open(); Console.WriteLine("Connection Open ! "); //Execute the query
//        SqlDataReader sdr = cmd.ExecuteReader(); ////Retrieve data from table and Display result
//        while (sdr.Read())
//        {
//            int ProductID = (int)sdr["ProductID"];
//            Console.WriteLine(ProductID);
//        } //Close the connection
//        conn.Close();
//    }
    
//    catch (Exception ex) { }

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var ConnectionString = builder.Configuration.GetConnectionString("APIDB");
        builder.Services.AddDbContext<ProductDBContext>(option =>
        option.UseSqlServer(ConnectionString));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
  

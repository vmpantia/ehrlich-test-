How to set up database and run the Web API:
1. Update the database connection string value that is set on **appsettings.Development.json**
   - Connection string Name: **MigrationDb**
   ![image](https://github.com/user-attachments/assets/71027fdd-972e-4383-81e1-a35afbf9e1e7)
2. Make sure that the **PizzaPlace.Api** is **Set as Startup Project**.
   ![image](https://github.com/user-attachments/assets/618f5375-b810-4425-82f8-16274d721ff6)
3. Go to **Package Manager Console** and make sure that the **PizzaPlace.Infrastructure** is selected on the **Default Project**.
   ![image](https://github.com/user-attachments/assets/897c83e7-8f5a-4082-bcde-f90f8050a474)
4. Run the command **Update-Database** to apply the migrations in your own database.
5. Run the Web Api by clicking the **F5** or **Start** in Visual Studio.
   ![image](https://github.com/user-attachments/assets/0e5374c7-51a5-4cb6-933b-ca8a63781373)
6. Make sure to follow the sequence of importing test data.
   1. Import Pizza Types (POST api/Data/import/pizza-types)
   2. Import Pizzas (POST api/Data/import/pizzas)
   3. Import Orders (POST api/Data/import/orders)
   4. Import Order Details (POST api/Data/import/orders-details)
   ![image](https://github.com/user-attachments/assets/adf1acc8-0d23-4452-8727-f0e6c2d05cd0)
7. Execute some GET methods below:
   ![image](https://github.com/user-attachments/assets/77105a3e-a7c2-4e6f-b69b-e14fc73c5b62)

   


   

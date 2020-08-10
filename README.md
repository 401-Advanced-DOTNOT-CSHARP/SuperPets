# ECommerce Application


# Author: Lami Beach, Lesley Rivera, Bryant Davis

---

# Description :

ECommerce Application that displays cereal products.

---

# Program Specifications: 

Buid out an application that has the folowing pages:

Home Page
Products Page
Home Page
Clean and simple home page design with CSS. Include on this home page a link to the “Products” page.

Products Page
The products page will display for the user a list of the data provided inside the cereal.csv file. Include a link to return to the home page. The page’s functionality should acheive the following:

Display all of the products to the page
Allow to search by name
Sort the data by ascending or descending
A few things to note:

You do not need to display pictures of the products, just line items will suffice.
CSS is required. Use Bootstrap if you can.
No database exists in today’s lab. Your data source will be your csv file
Use the repository design pattern and dependency injection within the ProductsController.cs. Keep note that as we move through this project we will be chnging the data source. The interface should be generic enough to support both the products in the cereal dataset and any future products. Consider the use of abstract classes and inheritence.
Some hints on reading in the CSV file:

Look at the header of the csv file to determine the properties required for the class
Hardcoding the field number with the property is allowed.
Logic to read a file from the wwwroot folder is:
string path = Environment.CurrentDirectory;
string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
string[] myFile = File.ReadAllLines(newPath);





# How it works:














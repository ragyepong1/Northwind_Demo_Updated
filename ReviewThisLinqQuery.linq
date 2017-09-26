<Query Kind="Statements">
  <Connection>
    <ID>d2680611-0859-4122-802a-895fe15d73e6</ID>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Users\ragyepong1\Documents\GitHub\Northwind_Demo_Updated\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Northwind.Data.NorthwindContext</CustomTypeName>
    <AppConfigPath>C:\Users\ragyepong1\Documents\GitHub\Northwind_Demo_Updated\Northwind.Data\App.config</AppConfigPath>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\GitHub\Northwind_Demo_Updated\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPathEncoded>
  </Connection>
</Query>

// Get the following from the Orders/OrderDetails for the last month of business data
// OrderDate, OrderID, # Items, Subtotal of all items, Total with freight
var maxDate = Orders.Max(row => row.OrderDate);
//maxDate.Value.Month.Dump();
var lastMonthOrders = 	from data in Orders
						where data.OrderDate.Value.Month == maxDate.Value.Month 
							&& data.OrderDate.Value.Year == maxDate.Value.Year
						orderby data.OrderDate
						select new
						{
							OrderDate = data.OrderDate,
							OrderID = data.OrderID,
							NumberOfItems = data.OrderDetails.Count(),
							ItemSubTotals = (from item in data.OrderDetails
											select item.UnitPrice * item.Quantity).Sum(),
							FreightCost = data.Freight,
							Total = data.Freight + (from item in data.OrderDetails
													select item.UnitPrice * item.Quantity).Sum()
						};
lastMonthOrders.Dump();
var totalIncome = lastMonthOrders.Sum(x => x.Total);
var count = lastMonthOrders.Count();
totalIncome.Dump("Total Income");
count.Dump("Orders Processed");
						


/*
Orders.Take(5); // get the first 5 orders
Orders.Count();
from data in Orders
orderby data.OrderDate descending // newest to oldest 
select new
{
	OrderDate = data.OrderDate;
};
*/
<Query Kind="Program">
  <Connection>
    <ID>d2680611-0859-4122-802a-895fe15d73e6</ID>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Users\ragyepong1\Documents\GitHub\Northwind_Demo_Updated\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPath>
    <CustomTypeName>Northwind.Data.NorthwindContext</CustomTypeName>
    <AppConfigPath>C:\Users\ragyepong1\Documents\GitHub\Northwind_Demo_Updated\Northwind.Data\App.config</AppConfigPath>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\GitHub\Northwind_Demo_Updated\Northwind.Data\bin\Debug\Northwind.Data.dll</CustomAssemblyPathEncoded>
  </Connection>
</Query>

void Main()
{
	var result = 	from cat in Categories
					orderby cat.CategoryName
					select new ProductCategory
					{
						Name = cat.CategoryName,
						Description = cat.Description,
						Picture = cat.Picture,
						Products = 	from item in cat.Products // build subquery off of the cat item
									orderby item.ProductName
									where item.Discontinued == false
									select new ProductInfo
									{
										ID = item.ProductID,
										Name = item.ProductName,
										QuantityPerUnit = item.QuantityPerUnit,
										Price = item.UnitPrice,
										InStock = item.UnitsInStock
									}
					};
	result.Dump();
}

// Define other methods and classes here
public class ProductCategory
{
	public string Name {get; set;}
	public string Description {get; set;}
	public byte[] Picture {get; set;}
	public IEnumerable<ProductInfo> Products {get; set;}
}

public class ProductInfo
{
	public int ID {get; set;}
	public string Name {get; set;}
	public string QuantityPerUnit {get; set;}
	public decimal? Price {get; set;}
	public short? InStock {get; set;}
}
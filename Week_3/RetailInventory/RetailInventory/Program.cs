using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();


if (!await context.Categories.AnyAsync())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2);
    await context.SaveChangesAsync();

    Console.WriteLine("Initial data inserted successfully.");
}

// Now run your queries

// 1️⃣ Retrieve all products
var products = await context.Products.Include(p => p.Category).ToListAsync();
Console.WriteLine("All Products:");
foreach (var p in products)
    Console.WriteLine($"{p.Id}: {p.Name} - ₹{p.Price} ({p.Category.Name})");

// 2️⃣ Find product by ID
var productById = await context.Products.FindAsync(1);
Console.WriteLine($"\nFound by ID 1: {productById?.Name}");

// 3️⃣ First product with price > ₹50,000
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"\nExpensive Product: {expensive?.Name}");

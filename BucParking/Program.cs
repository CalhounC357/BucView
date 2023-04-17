using BucParking.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

List<ParkingLot> parkingLotData = File.ReadAllLines("~/data/Parking_Lots.csv")
    .Skip(1)
    .Select(v => ParkingLot.LotFromCsv(v))
    .ToList();

List<ParkingSpot> parkingSpotData = File.ReadAllLines("~/data/Parking_Spots.csv")
    .Skip(1)
    .Select(v => ParkingSpot.SpotsFromCsv(v))
    .ToList();

Debug.WriteLine(parkingSpotData.Count);
Debug.WriteLine(parkingLotData.Count);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

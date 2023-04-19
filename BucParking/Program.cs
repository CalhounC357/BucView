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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

List<ParkingSpot> parkingSpotData = File.ReadAllLines(@"wwwroot/data/Parking_Spots.csv")
			.Skip(1)
			.Select(v => ParkingSpot.SpotsFromCsv(v))
			.ToList();

List<ParkingLot> parkingLotData = File.ReadAllLines(@"wwwroot/data/Parking_Lots.csv")
	.Skip(1)
	.Select(v => ParkingLot.LotFromCsv(v))
	.ToList();

Debug.WriteLine(parkingLotData);
Debug.Write(parkingLotData.Count);
Debug.WriteLine(parkingLotData[2].ParkingSpots.Count);	
app.Run();

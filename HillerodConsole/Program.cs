using hillerodLib;
using Microsoft.VisualBasic;

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
EventRepo eventRepo = new EventRepo();
eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11,30,0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen"));
eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12,00,0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense"));
eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22,12, 00, 0), new DateTime(2025, 7, 29, 12,00,0), "Vi kæmper om Danmarks mesterskaberne"));


foreach (var item in eventRepo.SearchEventByDate(new DateTime(2024, 12, 1, 12, 00, 0)))
{
    Console.WriteLine(item);
}
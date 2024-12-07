using hillerodLib;

// Adds Events to the Dictionary
EventRepo eventRepo = new EventRepo();
eventRepo.AddEvent(new Event("Båd oprydning", "7/12-24", "Vi skal ryder op på havnen"));
eventRepo.AddEvent(new Event("SejlTur til Odense", "17/7-25", "Vi tager en tur til Odense"));
eventRepo.AddEvent(new Event("Kamp", "8/10-25", "Vi kæmper om Dm"));

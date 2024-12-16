﻿using hillerodLib;
using Microsoft.VisualBasic;

// Creates a new instance of the BoatRepo class, and adds Boats to the dictionary 
BoatRepo repo = new BoatRepo();
repo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018")); // Boat test
repo.AddBoat(new(2, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014")); // Boat test
repo.AddBoat(new(3, "Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020")); // Boat test

// Creates an Admin object
Admin admin = new Admin("Henrik", "758@gmail.com", "98723141");

// Creates a new instance of the MemberRepo class, and adds Members to the dictionary 
MemberRepo memberRepo = new MemberRepo();
Member member = new Member("Thomas", "123@gmail.com", "12345678"); //create member test
Member member1 = new Member("Jens", "456@gmail.com", "87654321"); //create member test
Member member2 = new Member("thomas", "798@gmail.com", "94629562"); //create member test
Member member3 = new Member("dsfg", "asdfasdf8@gmail.com", "834257234"); //create member test

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
EventRepo eventRepo = new EventRepo();
eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen")); // Event test
eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12, 00, 0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense")); // Event test
eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22, 12, 00, 0), new DateTime(2025, 7, 29, 12, 00, 0), "Vi kæmper om Danmarks mesterskaberne")); // Event test


BookingRepo bookingRepo = new BookingRepo();
bookingRepo.AddBooking(new Booking(new List<Member>() { member, member1 }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven"));
bookingRepo.AddBooking(new Booking(new List<Member>() { member2, member3 }, new DateTime(2025, 7, 1, 11, 30, 0), new DateTime(2025, 7, 5, 12, 00, 0), "Odense"));


#region Test EventRepo

foreach (var item in eventRepo.SearchEventsByDateTime(new DateOnly(2025, 12, 1)))
{
    Console.WriteLine(item);
}
#endregion

#region Members that joins an event
Console.WriteLine();
eventRepo.GetEventById(1).MemberJoin(member);
eventRepo.GetEventById(1).MemberJoin(member1);
foreach (var mj in eventRepo.GetEventById(1).MemberJoined)
{
    Console.WriteLine(mj);
}
Console.WriteLine();
#endregion

#region testing booking
foreach (var item in bookingRepo.GetAllBookings())
{
    Console.WriteLine(item);
}
#endregion

#region Testing Member
foreach (Member m in memberRepo.GetAllMembers())
{
    Console.WriteLine(m.ToString());
}

memberRepo.CreateMember(member);
memberRepo.CreateMember(member2);
memberRepo.CreateMember(member1);

Console.WriteLine("member by id: " + memberRepo.FindMemberById(2).ToString());
Console.WriteLine("\nFilter by name thomas");
foreach (Member m in memberRepo.FilterMembersByName("thOmas"))
{
    Console.WriteLine(m.ToString());
}
Console.WriteLine();

foreach (Member m in memberRepo.GetAllMembers())
{
    Console.WriteLine(m.ToString());
}
Console.WriteLine();

Console.WriteLine("\nUpdate member");
memberRepo.UpdateMember(2, member3);
foreach (Member m in memberRepo.GetAllMembers())
{
    Console.WriteLine(m.ToString());
}
Console.WriteLine();

Console.WriteLine("\nDeleted member");
memberRepo.DeleteMember(3, out member3);
foreach (Member m in memberRepo.GetAllMembers())
{
    Console.WriteLine(m.ToString());
}
#endregion

#region Admin
// Create repositories
EventRepo adminEventRepo = new EventRepo();
BoatRepo adminBoatRepo = new BoatRepo();
MemberRepo adminMemberRepo = new MemberRepo();
MaintenanceLog adminMaintenanceLog = new MaintenanceLog();

// Create objects for testing
#region Boat Objects
Boat adminBoat1 = new Boat(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018");
adminBoat1.MaintenanceLog = adminMaintenanceLog;
Boat updatedBoat = new Boat(1, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014");
Boat deletionBoat = new Boat(3, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018");
#endregion
#region Report Objects
DamageReport adminTestReport = new DamageReport(1, "110125", "Test Report");
DamageReport updatedReport = new DamageReport(1, "20251607", "Updated test report");
DamageReport deletionReport = new DamageReport(3, "12132025", "Test Description");
#endregion
#region Member Objects
Member adminMember = new Member("Thomas", "123@gmail.com", "12345678");
Member updatedMember = new Member("Marley", "Marley@gmail.com", "27272727");
Member deletionMember = new Member("Zikki", "zikke@gmail.com", "12132025");
#endregion
#region Event Objects
Event testEvent = new Event("Test Event", new DateTime(2025, 1, 1), new DateTime(2025, 1, 2), "Test Description");
Event updatedEvent = new Event("Updated Event", new DateTime(2025, 2, 1), new DateTime(2025, 2, 2), "Updated Description");
Event deletionEvent = new Event("Event for deletion", new DateTime(2025, 5, 1), new DateTime(2025, 6, 1), "Event for deletion test");
#endregion
Console.WriteLine("Testing Admin Class Methods with Exception Handling\n");
#region Event Exception Testing 
// Test Event Methods
Console.WriteLine("---- Event Methods ----");

// Add Event
Console.WriteLine("Adding Event...");

try
{
    Console.WriteLine("Adding Event...");
    admin.AddEventInRepo(testEvent, adminEventRepo);

    Console.WriteLine("Trying to add the same Event again (should throw an exception)...");
    admin.AddEventInRepo(testEvent, adminEventRepo); // Should throw exception
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Update Non-Existing Event
try
{
    Console.WriteLine("Updating a non-existing Event (should throw an exception)...");

    admin.UpdateEventInRepo(999, updatedEvent, adminEventRepo); // Non-existing ID
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}


// Delete Non-Existent Event
try
{
    Console.WriteLine("Deleting a non-existent Event (Should throw an Exception)...");

    admin.DeleteEventInRepo(999, deletionEvent, adminEventRepo);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught exception: {ex.Message}");
}
#endregion
#region DamageReport Exception Testing
// Test DamageReport Methods
Console.WriteLine("---- DamageReport Methods ----");


// Add DamageReport
try
{
    Console.WriteLine("Adding DamageReport...");
    admin.AddDamageReportInLog(adminBoat1, adminTestReport);

    Console.WriteLine("Trying to add the same DamageReport again (should throw an exception)...");
    admin.AddDamageReportInLog(adminBoat1, adminTestReport); // Should throw exception
}
catch (BadReport.DuplicateReport ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Update Non-Existing DamageReport
try
{
    Console.WriteLine("Updating a non-existing DamageReport (should throw an exception)...");

    admin.UpdateDamageReportInLog(999, adminBoat1, updatedReport); // Non-existing ID
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Delete Non-Existent DamageReport
try
{
    Console.WriteLine("Deleting a non.existent DamageReport (Should throw an Exception)...");

    admin.DeleteDamageReportInLog(999, adminBoat1, deletionReport);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught exception: {ex.Message}");
}
#endregion
#region Member Exception Testing
// Test Member Methods
Console.WriteLine("---- Member Methods ----");


// Add Member
try
{
    Console.WriteLine("Adding Member...");
    admin.AddMemberInRepo(adminMember, adminMemberRepo);

    Console.WriteLine("Trying to add the same Member again (should throw an exception)...");
    admin.AddMemberInRepo(adminMember, adminMemberRepo); // Should throw exception
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Update Non-Existing Member
try
{
    Console.WriteLine("Updating a non-existing Member (should throw an exception)...");

    admin.UpdateMemberInRepo(999, updatedMember, adminMemberRepo); // Non-existing ID
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Delete Non-Existent Member
try
{
    Console.WriteLine("Deleting a non.existent Member (Should throw an Exception)...");

    admin.DeleteMemberInRepo(999, deletionMember, adminMemberRepo);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught exception: {ex.Message}");
}
#endregion
#region Boat Exception Testing
// Test Boat Methods
Console.WriteLine("---- Boat Methods ----");


// Add Boat
try
{
    Console.WriteLine("Adding Boat...");
    admin.AddBoatInRepo(adminBoat1, adminBoatRepo);

    Console.WriteLine("Trying to add the same Boat again (should throw an exception)...");
    admin.AddBoatInRepo(adminBoat1, adminBoatRepo); // Should throw exception
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Update Non-Existing Boat
try
{
    Console.WriteLine("Updating a non-existing Boat (should throw an exception)...");
    admin.UpdateBoatInRepo(999, updatedBoat, adminBoatRepo); // Non-existing ID
}
catch (Exception ex)
{
    Console.WriteLine($"Caught Exception: {ex.Message}");
}

// Delete Non-Existent Boat
try
{
    Console.WriteLine("Deleting a non.existent Member (Should throw an Exception)...");

    admin.DeleteBoatInRepo(999, deletionBoat, adminBoatRepo);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught exception: {ex.Message}");
}

#endregion
#region Testing Actual Methods
Console.WriteLine("Testing the update methods for each repository");
//Updating Event

Console.WriteLine("EventRepo updated:");
try
{ admin.UpdateEventInRepo(testEvent.Id, updatedEvent, adminEventRepo); }
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
List<Event> currentEvents = adminEventRepo.GetAllEvents();
foreach (Event e in currentEvents)
{
    Console.WriteLine(e.ToString());
}
//Updating Boat
Console.WriteLine("BoatRepo updated:");
admin.UpdateBoatInRepo(adminBoat1.Id, updatedBoat, adminBoatRepo);
List<Boat> currentBoats = adminBoatRepo.GetAllBoats();
foreach (Boat boat in currentBoats)
{
    Console.WriteLine(boat.ToString());
}
//Updating Member
Console.WriteLine("MemberRepo Updated:");
admin.UpdateMemberInRepo(adminMember.Id, updatedMember, adminMemberRepo);
List<Member> currentMembers = adminMemberRepo.GetAllMembers();
foreach (Member m in currentMembers)
{
    Console.WriteLine(m.ToString());
}
//Updating Report
Console.WriteLine("Damagereport Updated:");
admin.UpdateDamageReportInLog(adminTestReport.Id, adminBoat1, updatedReport);
List<DamageReport> currentReports = adminBoat1.MaintenanceLog.GetAllReports();
foreach (var report in currentReports)
{
    Console.WriteLine(report);
}
Console.WriteLine("Testing the Delete methods for each repository");
//Deleting Event
Console.WriteLine("Deleting Event");
admin.DeleteEventInRepo(updatedEvent.Id, updatedEvent, adminEventRepo);
List<Event> currentEvents2 = adminEventRepo.GetAllEvents();
if (currentEvents2.Count == 0)
{
    Console.WriteLine("EventRepo is empty");
}

// Deleting Boat
Console.WriteLine("Deleting boat");
admin.DeleteBoatInRepo(updatedBoat.Id, updatedBoat, adminBoatRepo);
List<Boat> currentBoats2 = adminBoatRepo.GetAllBoats();
if (currentBoats2.Count == 0)
{
    Console.WriteLine("BoatRepo is empty");
}

//Deleting Member
Console.WriteLine("Deleting Member");
admin.DeleteMemberInRepo(updatedMember.Id, updatedMember, adminMemberRepo);
List<Member> currentMembers2 = adminMemberRepo.GetAllMembers();
if (currentMembers2.Count == 0)
{
    Console.WriteLine("MemberRepo is empty");
}
//Deleting Report
Console.WriteLine("Deleting DamageReport");
admin.DeleteDamageReportInLog(updatedReport.Id, adminBoat1, updatedReport);
List<DamageReport> currentReports2 = adminBoat1.MaintenanceLog.GetAllReports();
if (currentReports2.Count == 0)
{
    Console.WriteLine("MaintenanceLog is empty");
}




#endregion
#endregion

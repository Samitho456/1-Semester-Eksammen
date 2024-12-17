using hillerodLib;
using Microsoft.VisualBasic;




//intialize repos
MemberRepo memberRepo = new MemberRepo();
EventRepo eventRepo = new EventRepo();
BookingRepo bookingRepo = new BookingRepo();

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
PopulateRepos();

TestEvent();


// Function that runs the user imput to test tests
void RunTest()
{
    Console.WriteLine("What do you want to test?");
    Console.WriteLine("\n1. Member/MemberRepo");
    Console.WriteLine("\n2. Booking/BookingRepo");
    Console.WriteLine("\n3. Events/EventRepo");

    int classTest = Int32.Parse(Console.ReadLine());

    switch (classTest)
    {
        case 1:
            PopulateRepos();
            TestMember();
            break;
        case 2:
            PopulateRepos();
            TestBooking();
            break;
        case 3:
            PopulateRepos();
            TestEvent();
            break;
        case 4:
            PopulateRepos();
            TestMemberEvent();
            break;
        default:
            RunTest();
            break;
    }
}




// Function to test Members
void TestMember()
{

    //print all members
    Console.WriteLine("Printing all Members\n");
    foreach (Member m in memberRepo.GetAllMembers())
    {
        Console.WriteLine(m.ToString());
    }

    //search member by id
    Console.WriteLine("member by id: " + memberRepo.FindMemberById(2).ToString());

    //filter members by name
    Console.WriteLine("\n\nFilter by name thomas");
    foreach (Member m in memberRepo.FilterMembersByName("thOmas"))
    {
        Console.WriteLine(m.ToString());
    }
    Console.WriteLine();


    //print all members
    foreach (Member m in memberRepo.GetAllMembers())
    {
        Console.WriteLine(m.ToString());
    }

    //updates member and print member list

    Member updatedmember = new("new member", "newmember.dk@gmail.com", "12312332");
    Console.WriteLine("\nUpdate member");
    memberRepo.UpdateMember(2, updatedmember);

    Console.WriteLine("List with updated member");
    foreach (Member m in memberRepo.GetAllMembers())
    {
        Console.WriteLine(m.ToString());
    }

    //Delete member and print member list
    Console.WriteLine("\nDeleted member");
    memberRepo.DeleteMemberById(3);
    foreach (Member m in memberRepo.GetAllMembers())
    {
        Console.WriteLine(m.ToString());
    }
}

// Function to test Booking
void TestBooking()
{
    // Get all bookings and print them out
    Console.WriteLine("Printing all Bookings\n");
    foreach (Booking b in bookingRepo.GetAllBookings())
    {
        Console.WriteLine(b);
    }

    // Get booking by id
    Console.WriteLine($"\nFinding a booking by {bookingRepo.GetBookingById(1)}");
    Console.WriteLine();

    // Delete booking by id
    if (bookingRepo.DeleteBooking(1, out Booking deletedBooking))
    {
        Console.WriteLine($"Booking deleted: Id = {deletedBooking.Id}");
        foreach (var membersInBooking in deletedBooking.Members)
        {
            Console.WriteLine($"Member: {membersInBooking.Name}");
        }
    }
    else 
    {
        Console.WriteLine("Booking not found");
    }
    Console.WriteLine();
    Console.WriteLine("Printing all Bookings\n");
    foreach (Booking b in bookingRepo.GetAllBookings())
    {
        Console.WriteLine(b);
    }

    //update Booking
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(1), memberRepo.FindMemberById(2) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven"));
    Console.WriteLine($"\nFinding a booking by {bookingRepo.GetBookingById(3)} \n");
    bookingRepo.UpdateBooking(3, new Booking(new List<Member>() { memberRepo.FindMemberById(2), memberRepo.FindMemberById(3) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Berlin"));
    Console.WriteLine($"\nFinding a booking by {bookingRepo.GetBookingById(3)}");


}

// Function to test Events
void TestEvent()
{
    Event newEvent = new Event("Sejladskursus", new DateTime(2024, 3, 5, 9, 00, 0), new DateTime(2024, 3, 10, 16, 00, 0), "Et kursus for begyndere i sejlads"); // Event test

    //print all events
    Console.WriteLine("print all events");
    foreach (Event e in eventRepo.GetAllEvents())
    {
        Console.WriteLine(e.ToString());
    }

    //Delete events
    string delete = eventRepo.DeleteEvent(1, out Event deletedEvent) ? delete = deletedEvent.ToString() : delete = "Event not found";
    Console.WriteLine("\n" + delete);

    //print all events
    Console.WriteLine("print all events");
    foreach (Event e in eventRepo.GetAllEvents())
    {
        Console.WriteLine(e.ToString());
    }

    //update Event
    string update = eventRepo.UpdateEvent(3, newEvent) ? update = "Event Updated" : update = "Failed to update event";
    Console.WriteLine("\n" + update);

    //print all events
    Console.WriteLine("print all events");
    foreach (Event e in eventRepo.GetAllEvents())
    {
        Console.WriteLine(e.ToString());
    }

    Console.WriteLine("\n" + eventRepo.GetEventById(3).ToString());
    Console.WriteLine("\n" + eventRepo.GetEventById(4).ToString());

    // Search Event by Name
    Console.WriteLine("\nSearch event by name");
    foreach (Event e in eventRepo.SearchEventByName("Træningslejr"))
    {
        Console.WriteLine(e.ToString());
    }

    // Search Event by Date
    Console.WriteLine("\nSearch event by date");
    foreach (var e in eventRepo.SearchEventsByDate(new DateOnly(2024, 8, 10)))
    {
        Console.WriteLine(e);
    }

    // Search Event by description
    Console.WriteLine("\nSearch event by description");
    foreach (var e in eventRepo.SearchEventByDescription("træningslejr"))
    {
        Console.WriteLine(e.ToString());
    }
}

void TestMemberEvent()
{

    // get all members that have joined an Event
    Console.WriteLine();
    eventRepo.GetEventById(1).Members.AddMember(memberRepo.FindMemberById(1));
    eventRepo.GetEventById(1).Members.AddMember(memberRepo.FindMemberById(2));
    foreach (var mE in eventRepo.GetEventById(1).Members.Members)
    {
        Console.WriteLine(mE);
    }
    Console.WriteLine();
}

void PopulateRepos()
{
    // Adds Boats to the repo
    boatRepo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018")); // Boat test
    boatRepo.AddBoat(new(2, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014")); // Boat test
    boatRepo.AddBoat(new(3, "Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020")); // Boat test

    // Adds Members to the repo
    memberRepo.CreateMember(new Member("Thomas", "123@gmail.com", "12345678"));
    memberRepo.CreateMember(new Member("Jens", "456@gmail.com", "87654321"));
    memberRepo.CreateMember(new Member("thomas", "798@gmail.com", "94629562"));
    memberRepo.CreateMember(new Member("dsfg", "asdfasdf8@gmail.com", "834257234"));

    // Add booking to the repo
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(1), memberRepo.FindMemberById(2) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven"));
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(3), memberRepo.FindMemberById(4) }, new DateTime(2025, 7, 1, 11, 30, 0), new DateTime(2025, 7, 5, 12, 00, 0), "Odense"));

    //add events to repo
    eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen")); // Event test
    eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12, 00, 0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense")); // Event test
    eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22, 12, 00, 0), new DateTime(2025, 7, 29, 12, 00, 0), "Vi kæmper om Danmarks mesterskaberne")); // Event test
    eventRepo.AddEvent(new Event("Sommerfest", new DateTime(2024, 6, 15, 15, 00, 0), new DateTime(2024, 6, 15, 23, 00, 0), "Vi holder en hyggelig sommerfest med grill og musik")); // Event test
    eventRepo.AddEvent(new Event("Træningslejr", new DateTime(2024, 8, 10, 8, 00, 0), new DateTime(2024, 8, 15, 18, 00, 0), "Intensiv træningslejr for alle medlemmer")); // Event test
    // Creates an Admin object
    Admin admin = new Admin("Henrik", "758@gmail.com", "98723141");
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

using hillerodLib;

//intialize repos
MemberRepo memberRepo = new MemberRepo();
EventRepo eventRepo = new EventRepo();
BookingRepo bookingRepo = new BookingRepo();
BoatRepo boatRepo = new BoatRepo();
MaintenanceLog maintenanceLog = new MaintenanceLog();

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
RunTest();



// Function that runs the user imput to test tests
void RunTest()
{
    Console.WriteLine("What do you want to test?");
    Console.WriteLine("\n1. Member/MemberRepo");
    Console.WriteLine("\n2. Booking/BookingRepo");
    Console.WriteLine("\n3. Events/EventRepo");
    Console.WriteLine("\n4. MemberEvent");
    Console.WriteLine("\n5. Exception and Handling");
    Console.WriteLine("\n6. DamageReport/MaintenanceLog");

    Console.Write("\nEnter number: ");
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
        case 5:
            PopulateRepos();
            TestException();
            break;
        case 6:
            PopulateRepos();
            TestMaintenanceLog();
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
    foreach (var b in bookingRepo.GetAllBookings())
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
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(1), memberRepo.FindMemberById(2) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven", boatRepo.GetBoatById(1)));
    Console.WriteLine($"\nFinding a booking by {bookingRepo.GetBookingById(3)} \n");
    bookingRepo.UpdateBooking(3, new Booking(new List<Member>() { memberRepo.FindMemberById(2), memberRepo.FindMemberById(3) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Berlin", boatRepo.GetBoatById(2)));
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

    //Print only one event out by id
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

void TestMaintenanceLog()
{
    DamageReport damageReport = new DamageReport(4, "230425", "Test Description");
    DamageReport updatedReport = new DamageReport(5, "249902", "Updated Description"); 
    List<DamageReport> damageReports = maintenanceLog.GetAllReports();
    //Testing GetAllReports() - should result in a list of DamageReports, using a foreach loop to print them out.
    Console.WriteLine("Testing GetAllReports()");
    foreach (var report in damageReports)
        Console.WriteLine(report.ToString());

    // Testing AddReport()
    Console.WriteLine("Adding a new damagereport");
    maintenanceLog.AddReport(damageReport);
    List<DamageReport> damageReportsUpdated = maintenanceLog.GetAllReports();
    foreach (var report in damageReportsUpdated)
        Console.WriteLine(report.ToString());
    // Testing FindReportByID()
    Console.WriteLine("Testing FinReportByID(4)");
    Console.WriteLine(maintenanceLog.FindReportById(4).ToString());
    // Testing UpdateReport()
    Console.WriteLine("Testing UpdateReport(2, updatedReport)");
    maintenanceLog.UpdateReport(2, updatedReport);
    Console.WriteLine(maintenanceLog.FindReportById(2).ToString());
    // Testing DeleteReport()
    Console.WriteLine("Testing DeleteReport(1)");
    maintenanceLog.DeleteReport(1);
    List<DamageReport> updatedReports = maintenanceLog.GetAllReports();
    foreach(var report in updatedReports)
        Console.WriteLine(report.ToString() );







}
// Function to test MemberEvent
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

// adds to Repos
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
    //bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(1), memberRepo.FindMemberById(2) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven", boatRepo.GetBoatById(1)));
    //bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(3), memberRepo.FindMemberById(4) }, new DateTime(2025, 7, 1, 11, 30, 0), new DateTime(2025, 7, 5, 12, 00, 0), "Odense", boatRepo.GetBoatById(3)));

    //add events to repo
    eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen")); // Event test
    eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12, 00, 0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense")); // Event test
    eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22, 12, 00, 0), new DateTime(2025, 7, 29, 12, 00, 0), "Vi kæmper om Danmarks mesterskaberne")); // Event test
    eventRepo.AddEvent(new Event("Sommerfest", new DateTime(2024, 6, 15, 15, 00, 0), new DateTime(2024, 6, 15, 23, 00, 0), "Vi holder en hyggelig sommerfest med grill og musik")); // Event test
    eventRepo.AddEvent(new Event("Træningslejr", new DateTime(2024, 8, 10, 8, 00, 0), new DateTime(2024, 8, 15, 18, 00, 0), "Intensiv træningslejr for alle medlemmer")); // Event test

    // Add DamageReports to MaintenanceLog
    maintenanceLog.AddReport(new DamageReport(1, "220725", "Test-Description"));
    maintenanceLog.AddReport(new DamageReport(2, "220725", "Test-Description"));
    maintenanceLog.AddReport(new DamageReport(3, "220725", "Test-Description"));
}

// Function to test Exceptions
void TestException()
{
    #region Exception and Handling
    // Adding a duplicate boat (should result in exception)
    Console.WriteLine("Testing for Duplicate exception");
    try
    {
        boatRepo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    // Finding a boat with a non-existent ID (Should result in exception)
    Console.WriteLine("Testing for non-existent ID");
    try
    {
        boatRepo.GetBoatById(99);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    // Adding a duplicate event (should result in an exception)
    Console.WriteLine("Testing for Duplicate exception");
    try
    {
        Event duplicateEvent = new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen");
        duplicateEvent.Id = 1;
        eventRepo.AddEvent(duplicateEvent);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    // Finding an Event with a non-existent ID (Should result in exception)
    Console.WriteLine("Testing for non-existent ID");
    try
    {
        eventRepo.GetEventById(99);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    // Adding a duplicate DamageReport (should result in an exception)
    Console.WriteLine("Testing for Duplicate exception");
    try
    {
        maintenanceLog.AddReport(new DamageReport(1, "220725", "Test-Description"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    // Finding an DamageReport with a non-existent ID (Should result in exception)
    Console.WriteLine("Testing for non-existent ID");
    try
    {
        maintenanceLog.FindReportById(99);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    #endregion
}


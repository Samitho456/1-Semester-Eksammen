using hillerodLib;

//intialize repos
MemberRepo memberRepo = new MemberRepo();
EventRepo eventRepo = new EventRepo();
BookingRepo bookingRepo = new BookingRepo();
BoatRepo boatRepo = new BoatRepo();

PopulateRepos();


// Creates a new instance of the EventRepo class, and adds events to the dictionary 
//RunTest();

// Function that runs the user imput to test tests
void RunTest()
{
    Console.WriteLine("What do you want to test?");
    Console.WriteLine("\n1. Member/MemberRepo");
    Console.WriteLine("\n2. Booking/BookingRepo");
    Console.WriteLine("\n3. Events/EventRepo");
    Console.WriteLine("\n4. MemberEvent");
    Console.WriteLine("\n5. MemberEvent");

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
            TestAdmin();
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
    boatRepo.AddBoat(new("Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018"));
    boatRepo.AddBoat(new("Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014"));
    boatRepo.AddBoat(new("Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020"));
    boatRepo.AddBoat(new("Luna", BoatType.MotorBoat, "Sunseeker", "Sport500", "Mercury V8", 10, "2019"));
    boatRepo.AddBoat(new("Aurora", BoatType.RowBoat, "Classic Wood", "RW100", "N/A", 2, "2015"));
    boatRepo.AddBoat(new("Stella", BoatType.SailBoat, "Lagoon450", "450", "2 x Yanmar 4JH57", 13, "2021"));
    boatRepo.AddBoat(new("Echo", BoatType.MotorBoat, "Bayliner", "VR6", "MerCruiser 4.5L", 8, "2020"));
    boatRepo.AddBoat(new("Nova", BoatType.RowBoat, "EcoRow", "Eco500", "N/A", 4, "2017"));
    boatRepo.AddBoat(new("Orion", BoatType.SailBoat, "Hanse418", "418", "Yanmar 4JH57", 12, "2022"));
    boatRepo.AddBoat(new("Sol", BoatType.MotorBoat, "Axopar28", "28", "Mercury V6", 9, "2019"));

    // Adds Members to the repo
    memberRepo.CreateMember(new Member("Thomas", "123@gmail.com", "12345678"));
    memberRepo.CreateMember(new Member("Jens", "456@gmail.com", "87654321"));
    memberRepo.CreateMember(new Member("Anna", "anna@gmail.com", "55555555"));
    memberRepo.CreateMember(new Member("Maria", "maria@gmail.com", "44444444"));
    memberRepo.CreateMember(new Member("Peter", "peter@gmail.com", "33333333"));
    memberRepo.CreateMember(new Member("Lars", "lars@gmail.com", "22222222"));
    memberRepo.CreateMember(new Member("Sophie", "sophie@gmail.com", "11111111"));
    memberRepo.CreateMember(new Member("Emma", "emma@gmail.com", "66666666"));
    memberRepo.CreateMember(new Member("Olivia", "olivia@gmail.com", "77777777"));
    memberRepo.CreateMember(new Member("Oscar", "oscar@gmail.com", "88888888"));

    // Adds Bookings to the repo
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(1), memberRepo.FindMemberById(2) }, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven", boatRepo.GetBoatById(1)));
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(3), memberRepo.FindMemberById(4) }, new DateTime(2025, 7, 1, 11, 30, 0), new DateTime(2025, 7, 5, 12, 00, 0), "Odense", boatRepo.GetBoatById(3)));
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(5), memberRepo.FindMemberById(6) }, new DateTime(2025, 8, 10, 9, 00, 0), new DateTime(2025, 8, 15, 18, 00, 0), "Bornholm", boatRepo.GetBoatById(5)));
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(7), memberRepo.FindMemberById(8) }, new DateTime(2025, 9, 5, 10, 00, 0), new DateTime(2025, 9, 10, 15, 00, 0), "Aarhus", boatRepo.GetBoatById(7)));
    bookingRepo.AddBooking(new Booking(new List<Member>() { memberRepo.FindMemberById(9), memberRepo.FindMemberById(10) }, new DateTime(2025, 6, 15, 8, 00, 0), new DateTime(2025, 6, 20, 20, 00, 0), "Copenhagen", boatRepo.GetBoatById(9)));

    // Adds Events to the repo
    eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryde op på havnen"));
    eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12, 00, 0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense"));
    eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22, 12, 00, 0), new DateTime(2025, 7, 29, 12, 00, 0), "Vi kæmper om Danmarks mesterskaberne"));
    eventRepo.AddEvent(new Event("Sommerfest", new DateTime(2024, 6, 15, 15, 00, 0), new DateTime(2024, 6, 15, 23, 00, 0), "Vi holder en hyggelig sommerfest med grill og musik"));
    eventRepo.AddEvent(new Event("Træningslejr", new DateTime(2024, 8, 10, 8, 00, 0), new DateTime(2024, 8, 15, 18, 00, 0), "Intensiv træningslejr for alle medlemmer"));
    eventRepo.AddEvent(new Event("Forårstur", new DateTime(2025, 4, 15, 10, 00, 0), new DateTime(2025, 4, 20, 18, 00, 0), "Fælles sejltur i foråret"));
    eventRepo.AddEvent(new Event("Havnerundfart", new DateTime(2024, 11, 20, 14, 00, 0), new DateTime(2024, 11, 20, 18, 00, 0), "Guidet tur rundt i havnen"));
    eventRepo.AddEvent(new Event("Fisketur", new DateTime(2024, 9, 5, 6, 00, 0), new DateTime(2024, 9, 5, 15, 00, 0), "Fisketur for hele familien"));
    eventRepo.AddEvent(new Event("Vintersamling", new DateTime(2025, 1, 15, 17, 00, 0), new DateTime(2025, 1, 15, 22, 00, 0), "Indendørs hygge og foredrag"));
    eventRepo.AddEvent(new Event("Julefrokost", new DateTime(2024, 12, 20, 18, 00, 0), new DateTime(2024, 12, 20, 23, 59, 0), "Julehygge og mad med medlemmer"));

}


//foreach(var i in bookingRepo.GetAllBookings())
//{
//    Console.WriteLine(i.ToString());
//}


DateTime now = new(2024, 9, 8, 0, 0, 0);
bookingRepo.UpdateAvailable(now);
List<Boat> list = boatRepo.FindAvailableBoatsByDate(bookingRepo, new DateOnly(2025, 9, 8));

//List<Boat> list2 = boatRepo.FindAvailableBoatsByDate(bookingRepo, new DateOnly(2026, 6, 16));


foreach (Boat b in list)
{
    Console.WriteLine(b.ToString());
}
Console.WriteLine();
//foreach (Boat boat in list2)
//{
//    Console.WriteLine(boat.ToString());
//}


// Function to test Admin
void TestAdmin()
{
    #region Admin
    // Create repositories
    EventRepo adminEventRepo = new EventRepo();
    BoatRepo adminBoatRepo = new BoatRepo();
    MemberRepo adminMemberRepo = new MemberRepo();
    MaintenanceLog adminMaintenanceLog = new MaintenanceLog();
    // Creates an Admin object
    Admin admin = new Admin("Henrik", "758@gmail.com", "98723141");

    // Create objects for testing
    #region Boat Objects
    Boat adminBoat1 = new Boat("Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018");
    adminBoat1.MaintenanceLog = adminMaintenanceLog;
    Boat updatedBoat = new Boat("Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014");
    Boat deletionBoat = new Boat("Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018");
    #endregion
    #region Report Objects
    DamageReport adminTestReport = new DamageReport("110125", "Test Report");
    DamageReport updatedReport = new DamageReport("20251607", "Updated test report");
    DamageReport deletionReport = new DamageReport("12132025", "Test Description");
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
    #region Booking objects
    Booking adminTestBooking = new Booking(new List<Member>() { adminMember }, new DateTime(2025, 1, 1), new DateTime(2025, 2, 1), "Test destanation", adminBoat1);
    #endregion
    Console.WriteLine("Testing Admin Class Methods with Exception Handling\n");
    #region Event Exception Testing 
    // Test Event Methods
    Console.WriteLine("---- Event Methods ----");

    // Add Event
    Console.WriteLine("Adding Event...");
    #endregion
    #endregion
}
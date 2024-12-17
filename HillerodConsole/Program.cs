using hillerodLib;
using Microsoft.VisualBasic;

//intialize repos
BoatRepo boatRepo = new BoatRepo();
MemberRepo memberRepo = new MemberRepo();
EventRepo eventRepo = new EventRepo();
BookingRepo bookingRepo = new BookingRepo();

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
PopulateRepos();

#region Test EventRepo

foreach (var item in eventRepo.SearchEventsByDateTime(new DateOnly(2025, 12, 1)))
{
    Console.WriteLine(item);
}
#endregion

#region Members that joins an event
Console.WriteLine();
eventRepo.GetEventById(1).Members.AddMember(memberRepo.FindMemberById(1));
eventRepo.GetEventById(1).Members.AddMember(memberRepo.FindMemberById(2));
foreach (var mj in eventRepo.GetEventById(1).Members.Members)
{
    Console.WriteLine(mj);
}
Console.WriteLine();
#endregion


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
    foreach (var item in bookingRepo.GetAllBookings())
    {
        Console.WriteLine(item);
    }
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

    foreach (Event e in eventRepo.SearchEventByName("Træningslejr"))
    {
        Console.WriteLine(e.ToString());
    }
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
}


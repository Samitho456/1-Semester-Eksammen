using hillerodLib;
using Microsoft.VisualBasic;

//intialize repos
BoatRepo repo = new BoatRepo();
MemberRepo memberRepo = new MemberRepo();
EventRepo eventRepo = new EventRepo();
BookingRepo bookingRepo = new BookingRepo();

// Adds Boats to the repo
repo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018")); // Boat test
repo.AddBoat(new(2, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014")); // Boat test
repo.AddBoat(new(3, "Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020")); // Boat test

// Adds Members to the repo
Member member = new Member(1, "Thomas", "123@gmail.com", "12345678"); //create member test
Member member1 = new Member(2, "Jens", "456@gmail.com", "87654321"); //create member test
Member member2 = new Member(3, "thomas", "798@gmail.com", "94629562"); //create member test
Member member3 = new Member(4, "dsfg", "asdfasdf8@gmail.com", "834257234"); //create member test


bookingRepo.AddBooking(new Booking(new List<Member>() { member,member1}, new DateTime(2025, 5, 1, 11, 30, 0), new DateTime(2025, 5, 5, 12, 00, 0), "Ven"));
bookingRepo.AddBooking(new Booking(new List<Member>() { member2, member3 }, new DateTime(2025, 7, 1, 11, 30, 0), new DateTime(2025, 7, 5, 12, 00, 0), "Odense"));


//Methode to test Members
void TestMember()
{
    //add member to repo
    memberRepo.CreateMember(member);
    memberRepo.CreateMember(member1);
    memberRepo.CreateMember(member2);

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
    Console.WriteLine("\nUpdate member");
    memberRepo.UpdateMember(2, member3);

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

void TestBooking()
{
    foreach (var item in bookingRepo.GetAllBookings())
    {
        Console.WriteLine(item);
    }
}

void TestEvent()
{
    //add events to repo
    eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11, 30, 0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen", 2)); // Event test
    eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12, 00, 0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense")); // Event test
    eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22, 12, 00, 0), new DateTime(2025, 7, 29, 12, 00, 0), "Vi kæmper om Danmarks mesterskaberne")); // Event test
    eventRepo.AddEvent(new Event("Sommerfest", new DateTime(2024, 6, 15, 15, 00, 0), new DateTime(2024, 6, 15, 23, 00, 0), "Vi holder en hyggelig sommerfest med grill og musik")); // Event test
    eventRepo.AddEvent(new Event("Træningslejr", new DateTime(2024, 8, 10, 8, 00, 0), new DateTime(2024, 8, 15, 18, 00, 0), "Intensiv træningslejr for alle medlemmer")); // Event test
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
using hillerodLib;
using Microsoft.VisualBasic;

// Creates a new instance of the EventRepo class, and adds events to the dictionary 
EventRepo eventRepo = new EventRepo();
eventRepo.AddEvent(new Event("Båd oprydning", new DateTime(2025, 12, 1, 11,30,0), new DateTime(2025, 12, 1, 17, 30, 0), "Vi skal ryder op på havnen")); // Event test
eventRepo.AddEvent(new Event("SejlTur til Odense", new DateTime(2024, 12, 1, 12,00,0), new DateTime(2024, 12, 7, 12, 30, 0), "Vi tager en tur til Odense")); // Event test
eventRepo.AddEvent(new Event("Kamp", new DateTime(2025, 7, 22,12, 00, 0), new DateTime(2025, 7, 29, 12,00,0), "Vi kæmper om Danmarks mesterskaberne")); // Event test

// Creates a new instance of the MemberRepo class, and adds Members to the dictionary 
MemberRepo memberRepo = new MemberRepo();
Member member = new Member(1, "Thomas", "123@gmail.com", "12345678"); //create member test
Member member1 = new Member(2, "Jens", "456@gmail.com", "87654321"); //create member test
Member member2 = new Member(3, "thomas", "798@gmail.com", "94629562"); //create member test
Member member3 = new Member(4, "dsfg", "asdfasdf8@gmail.com", "834257234"); //create member test

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
memberRepo.DeleteMember(3);
foreach (Member m in memberRepo.GetAllMembers())
{
    Console.WriteLine(m.ToString());
}
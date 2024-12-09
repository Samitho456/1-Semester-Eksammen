using hillerodLib;


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
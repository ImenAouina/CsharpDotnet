//Instantiate a Buffet, a SweetTooth, and a SpiceHound in Program.cs
Buffet b = new Buffet();
SweetTooth st = new SweetTooth();
SpicyHound sh = new SpicyHound();
//Have both the SweetTooth and Spice hound "Consume" from the Buffet until Full in Program.cs
while (st.IsFull == false)
{
    st.Consume(b.Serve());
}
Console.WriteLine("Maxi's Food:");
while (sh.IsFull == false)
{
    sh.Consume(b.Serve());
}
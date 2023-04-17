main();
void main()
{
    quad_print();
    Console.WriteLine("------------------");
    prop_print();
    Console.WriteLine("------------------");
    unde_print();
    Console.WriteLine("------------------");
    heli_print();

}
void quad_print()
{
    Quadrocopter quad = new Quadrocopter("rotor1", "rotor2", "rotor3", "rotor4");
    if (quad is IRobot robot_q) { Console.Write(robot_q.GetInfo()); Console.Write(" " + robot_q.GetRobotType()); }
    Console.WriteLine("");
    if (quad is IChargeble charge_q) { charge_q.Charge(); Console.WriteLine(charge_q.GetInfo()); }
    Console.WriteLine("");
    if (quad is IFlyingRobot frobot_q) { Console.WriteLine(frobot_q.GetRobotType()); }
    Console.WriteLine("");
}
void prop_print()
{
    Propeller prop = new Propeller("rotor");
    if (prop is IRobot robot_q) { Console.Write(robot_q.GetInfo()); Console.Write(" " + robot_q.GetRobotType()); }
    Console.WriteLine("");
    if (prop is IFlyingRobot frobot_q) { Console.WriteLine(frobot_q.GetRobotType()); }
    Console.WriteLine("");
}
void unde_print()
{
    UnderWaterRobot unde = new UnderWaterRobot("rotor1", "rotor2", "rotor3", "rotor4");
    if (unde is IRobot robot_q) { Console.Write(robot_q.GetInfo()); Console.Write(" " + robot_q.GetRobotType()); }
    Console.WriteLine("");
    if (unde is IChargeble charge_q) { charge_q.Charge(); Console.WriteLine(charge_q.GetInfo()); }
    Console.WriteLine("");
}
void heli_print()
{
    Helicopter heli = new Helicopter("rotor1", "rotor2");
    if (heli is IRobot robot_q) { Console.Write(robot_q.GetInfo()); Console.Write(" " + robot_q.GetRobotType()); }
    Console.WriteLine("");
    if (heli is IChargeble charge_q) { charge_q.Charge(); Console.WriteLine(charge_q.GetInfo()); }
    Console.WriteLine("");
    if (heli is IFlyingRobot frobot_q) { Console.WriteLine(frobot_q.GetRobotType()); }
    Console.WriteLine("");
}
interface IRobot
{
    string GetInfo();
    List<string> GetComponents();
    string GetRobotType() { return("I am a simple robot."); }
}
interface IChargeble
{
    void Charge();
    string GetInfo();
}
interface IFlyingRobot:IRobot
{
    string GetRobotType() { return ("I am a flying robot."); }
}
public class Quadrocopter : IFlyingRobot, IChargeble
{
    bool ChargeInfo = false;
    List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };
    string IRobot.GetInfo() { string result = string.Join(",", _components); return result; }
    List<string> IRobot.GetComponents() { return _components; }
    string IRobot.GetRobotType() { return ("I am a simple robot."); }
    public Quadrocopter(params string[] args)
    {
        List<string> components = new List<string>();
        foreach (string a in args) { components.Add(a); }
        _components = components;
    }
    void IChargeble.Charge()
    {
        Console.WriteLine("Charging...");
        Thread.Sleep(3000);
        Console.WriteLine("Charged!");
        ChargeInfo = true;
    }
    string IChargeble.GetInfo()
    {
        return ChargeInfo.ToString();
    }
    string IFlyingRobot.GetRobotType() { return ("I am a flying robot."); }
}
public class Propeller : IFlyingRobot
{
    bool ChargeInfo = false;
    List<string> _components = new List<string> { "rotor" };
    string IRobot.GetInfo() { string result = string.Join(",", _components); return result; }
    List<string> IRobot.GetComponents() { return _components; }
    string IRobot.GetRobotType() { return ("I am not a robot, I am just a propeller."); }
    public Propeller(params string[] args)
    {
        List<string> components = new List<string>();
        foreach (string a in args) { components.Add(a); }
        _components = components;
    }
    string IFlyingRobot.GetRobotType() { return ("I am a spinning engine."); }
}
public class UnderWaterRobot : IRobot, IChargeble
{
    bool ChargeInfo = false;
    List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };
    string IRobot.GetInfo() { string result = string.Join(",", _components); return result; }
    List<string> IRobot.GetComponents() { return _components; }
    string IRobot.GetRobotType() { return ("I am a underwater robot."); }
    public UnderWaterRobot(params string[] args)
    {
        List<string> components = new List<string>();
        foreach (string a in args) { components.Add(a); }
        _components = components;
    }
    void IChargeble.Charge()
    {
        Console.WriteLine("Charging...");
        Thread.Sleep(3000);
        Console.WriteLine("Charged!");
        ChargeInfo = true;
    }
    string IChargeble.GetInfo()
    {
        return ChargeInfo.ToString();
    }
}
public class Helicopter : IFlyingRobot, IChargeble
{
    bool ChargeInfo = false;
    List<string> _components = new List<string> { "rotor1", "rotor2" };
    string IRobot.GetInfo() { string result = string.Join(",", _components); return result; }
    List<string> IRobot.GetComponents() { return _components; }
    string IRobot.GetRobotType() { return ("I am a simple vehicle."); }
    public Helicopter(params string[] args)
    {
        List<string> components = new List<string>();
        foreach (string a in args) { components.Add(a); }
        _components = components;
    }
    void IChargeble.Charge()
    {
        Console.WriteLine("Charging...");
        Thread.Sleep(3000);
        Console.WriteLine("Charged!");
        ChargeInfo = true;
    }
    string IChargeble.GetInfo()
    {
        return ChargeInfo.ToString();
    }
    string IFlyingRobot.GetRobotType() { return ("I am a flying aircraft."); }
}

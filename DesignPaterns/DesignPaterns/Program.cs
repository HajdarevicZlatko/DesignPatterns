
using DesignPaterns.COR;

namespace DesignPaterns.Start
{

    public class Demo
    {
        public static void Main()
        {
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);
            var root = new CreateModifier(goblin);
            Console.WriteLine("Doubling");
            root.Add(new DoubleAttackModifier(goblin));
            root.Add(new DoublDefenseModifier(goblin));
            root.Handle();

            Console.WriteLine(goblin);



        }
    }
}


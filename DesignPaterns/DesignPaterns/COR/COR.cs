using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPaterns.COR
{
    public class Creature
    {
        public string Name;
        public int Attack, Defense;


        public Creature(string name, int attack, int defense)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Attack = attack;
            Defense = defense;
        }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense},";
        }


    }

    public class CreateModifier
    {
        protected Creature creature;
        protected CreateModifier next; // linked List

        public CreateModifier(Creature creature)
        {
            this.creature = creature;
        }
        public void Add(CreateModifier cm)
        {
            if (next != null) next.Add(cm);
            else next = cm;
        }
        public virtual void Handle() => next?.Handle();
    }

    public class DoubleAttackModifier : CreateModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }
        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}`s attack ");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class DoublDefenseModifier : CreateModifier
    {
        public DoublDefenseModifier(Creature creature) : base(creature)
        {
        }
        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}`s defense ");
            creature.Defense += 3;
            base.Handle();
        }
    }
}

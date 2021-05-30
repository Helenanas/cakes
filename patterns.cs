using System;

namespace RefactoringGuru.DesignPatterns.State.Conceptual
{
    class Admin
    {
        private Cake _cake = null;

        public Admin(Cake cake)
        {
            this.TransitionTo(cake);
        }

    }

    abstract class Cake
    {
        protected Vid_cake;

        public void SetVid(Vid cake)
        {
            this._vid = cake;
        }

        public abstract void Name();

    }

    class Vid : Cake
    {
       

        public override void Name()
        {
            Console.Cake("Vid");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код.
            var vid = new Admin(new Vid());
            vid.Request();
        }
    }
}
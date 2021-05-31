using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringGuru.DesignPatterns.State.Conceptual
{
    class Cake
    {
        public void Request(Vid vid)
        {
            vid.Request();
        }
    }
    // класс, к которому надо адаптировать другой класс   
    class Vid
    {
        public virtual void Request()
        { }
    }

    // Адаптер
    class Adapter : Vid
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    // Адаптируемый класс
    class Adaptee
    {
        public void SpecificRequest()
        { }
    }

    class Admin
    {
        static void Main(string[] args)
        {

            Vid vid = new Vid();

            vid.Id(vid);
            Name name = new Name();
            // используем адаптер
            IPole namoPole = new NametoPoleAdapter(name);

            vid.Id(camelTransport);

            Console.Read();
        }
    }
    interface IPole
    {
        void Name();
    }

    class Vid
    {
        public void Vid(IVid cakes)
        {
            Vid.Pole();
        }
    }

    // интерфейс торт
    interface IVid
    {
        void Cake();
    }

    // Адаптер от pole к vid
    class NametoPoleAdapter : Vid
    {
        Vid vid;
        public NametoPoleAdapter(Vid c)
        {
            vid = c;
        }

        public void Pole()
        {
            vid.Pole();
        }
    }


    //стратегия............................

    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }

    class Vid
    {
        static void Main(string[] args)
        {
            Cake vid = new Cake(4, "Medovik", new Pole());
            vid.Move();
            vid.Movable = new Name();
            vid.Move();

            Console.ReadLine();
        }
    }


    interface IMovable
    {
        void Move();
    }

    class Admin : IMovable
    {
        public void Move()
        {
            Console.WriteLine("na drugoe imya");
        }
    }

    class Name : IMovable
    {
        public void Move()
        {
            Console.WriteLine("na drugoe pole");
        }
    }


    public IMovable Movable { private get; set; }
    public void Move()
    {
        Movable.Move();
    }
    class Cake
    {
        protected int material; // кол-во material
        protected string Id; // модель Id

        public Cake(int num, string model, IMovable mov)
        {
            this.material = num;
            this.Id = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }
    }
    //спостерігач...................
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class ConcreteObservable : IObservable
    {
        private List<IObserver> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }
    interface IObserver
    {
        void Update();
    }
    class ConcreteObserver : IObserver
    {
        public void Update()
        {
        }
    }

    class Material
    {
        static void Main(string[] args)
        {
            Cakes cakes = new Cakes();
            Vid vid = new Vid("Polnoe pole", cakes);
            Id id = new Id("Raspologenie", cakes);
            // имитация перемесщения
            cakes.Move();
            // стоп перемещению
            cakes.StopMove();
            // имитация продажи
            cakes.Market();

            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Cakes : IObservable
    {
        CakesInfo cInfo; // информация o товаре

        List<IObserver> observers;
        public Cakes()
        {
            observers = new List<IObserver>();
            cInfo = new CakesInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(сInfo);
            }
        }

        // имитация продажи
        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class CakesInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Vid : IObserver
    {
        public string Name { get; set; }
        IObservable cakes;
        public Vid(string name, IObservable obs)
        {
            this.Name = name;
            cakes = obs;
            cakes.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            CakesInfo cInfo = (CakesInfo)ob;

            if (cInfo.USD > 30)
                Console.WriteLine("Aдмин смотрит товар;  Выбор товара: {1}", this.Name, cInfo.USD);
            else
                Console.WriteLine("Админ покупает товар;   Выбор товара: {1}", this.Name, cInfo.USD);
        }
        public void StopTrade()
        {
            cakes.RemoveObserver(this);
            cakes = null;
        }
    }

    class Admin : IObserver
    {
        public string Name { get; set; }
        IObservable cakes;
        public Admin(string name, IObservable obs)
        {
            this.Name = name;
            cakes = obs;
            cakes.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            CakesInfo cInfo = (CakesInfo)ob;

            if (cInfo.Euro > 40)
                Console.WriteLine("Админ отдает деньги;  Данные: {1}", this.Name, cInfo.Euro);
            else
                Console.WriteLine("Админ получает деньги;  Данные: {1}", this.Name, cInfo.Euro);
        }
    }



}
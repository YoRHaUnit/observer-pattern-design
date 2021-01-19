using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{

    public interface IEditor
    {
        void Update(ISubscriber subject);
    }

    public interface ISubscriber
    {
        void Attach(IEditor observer);

        void Detach(IEditor observer);

        void Notify();
    }

    public class Subscriber : ISubscriber
    {
        public int State { get; set; } = -0;

        private List<IEditor> _editors = new List<IEditor>();

        public void Attach(IEditor observer)
        {
            Console.WriteLine("Vous vous êtes abonnés à cet éditeur");
            this._editors.Add(observer);
        }

        public void Detach(IEditor observer)
        {
            this._editors.Remove(observer);
            Console.WriteLine("\nVous vous êtes désabonné de cet éditeur.");    
        }

        public void Notify()
        {
            Console.WriteLine("Vous allez bientot recevoir un nouveau magazine =)");

            foreach (var editor in _editors)
            {
                editor.Update(this);
            }
        }

        public void SomeBusinessLogic(int i)
        {
            Console.WriteLine("\nL'éditeur à publié le magazin n°"+i+" .");

            this.Notify();
        }
    }

    class Editor : IEditor
    {
        public void Update(ISubscriber subject)
        {
            if ((subject as Subscriber).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            var subscriber = new Subscriber();
            var editor = new Editor();
            subscriber.Attach(editor);


            while (i < 5)
            {
                i++;
                subscriber.SomeBusinessLogic(i);
            }

            subscriber.Detach(editor);

            Console.ReadKey();
        }
    }
}

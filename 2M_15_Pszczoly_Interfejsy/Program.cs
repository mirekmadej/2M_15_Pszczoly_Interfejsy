namespace _2M_15_Pszczoly_Interfejsy
{
    abstract class Pszczola
    {

    }
    interface IAtak
    {
        void atakuj();
    }
    class Krolowa : Pszczola
    {
        Pszczola[] pszczoly;
        public void przydzielZadanie()
        {

        }
        void bronUla(Robotnica p)
        {
            p.atakuj();
        }

    }
    abstract class Robotnica : Pszczola, IAtak
    {
        public abstract void atakuj(); 
    }
    class Zbieracz : Robotnica
    {
        void przyniesNektar()
        {
            Console.WriteLine("MAM KWIAT!");
            Console.WriteLine("MAM NEKTAR");
            Console.WriteLine("wracam do ula");
        }
        public override void atakuj()
        {
            Console.WriteLine("atakuję wroga");
        }
    }
    class Ochroniarz : Robotnica
    {
        public void patroluj()
        {
            Console.WriteLine("patroluję ");
        }
        public override void atakuj()
        {
            Console.WriteLine("atakuję wroga");
        }
        public void alarmuj()
        {
            //Krolowa.alarmujUl(this, "osa");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
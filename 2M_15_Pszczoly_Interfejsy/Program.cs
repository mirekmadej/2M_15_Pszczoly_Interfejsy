namespace _2M_15_Pszczoly_Interfejsy
{
    abstract class Pszczola
    {
        public abstract string nazwa { get; protected set; }
    }
    interface IAtak
    {
        void atakuj();
    }
    class Krolowa : Pszczola
    {
        public override string nazwa {get; protected set;}
        private const int N = 10;
        private int nr = 0;
        private Pszczola[] pszczoly = new Pszczola[N];
        public Krolowa(string nazwa = "Queen")
        {
            this.nazwa = nazwa;
        }
        public void pokazPszczoly()
        {
            Console.WriteLine("Lista pszczół:");
            foreach (var p in this.pszczoly)
            {
                Console.Write(p.nazwa + "; ");
                if (p is Pszczola)
                    Console.Write("jestem pszczołą; ");
                if (p is Robotnica)
                    Console.Write("jestem robotnicą; ");
                if (p is Zbieracz)
                    Console.Write("umiem zbierać nektar; ");
                if (p is Ochroniarz)
                    Console.Write("mogę patrolować; ");
                if (p is IAtak)
                    Console.Write("mogę bronić ul; ");

                Console.WriteLine();
            }
                
            
        }
        public void dodajPszczole(Pszczola p)
        {
            if (nr < N)
                pszczoly[nr++] = p;
            else
                Console.WriteLine("za dużo pszczół, nie moge tej dodać");
        }
        public void przydzielZadanie(int nr, string zadanie="")
        {
            Pszczola p = pszczoly[nr];
            if (p is IAtak && zadanie=="obrona")
            {
                
                if(p is Zbieracz)
                {
                    Zbieracz z = p as Zbieracz;
                    z.atakuj();
                }
                if (p is Ochroniarz)
                {
                    Ochroniarz z = p as Ochroniarz;
                    z.atakuj();
                }
                

                return;
            }
            if (p is Zbieracz)
            {
                Zbieracz z;
                z = p as Zbieracz;
                z.przyniesNektar();
            }
            if(p is Ochroniarz)
            {
                Ochroniarz z = p as Ochroniarz;
                z.patroluj();
            }
                

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
        public override string nazwa { get; protected set; }
        public Zbieracz(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public void przyniesNektar()
        {
            Console.WriteLine($"{nazwa} MAM KWIAT! MAM NEKTAR, wracam do ula");
        }
        public override void atakuj()
        {
            Console.WriteLine($"{nazwa}: bronię ula");
        }
    }
    class Ochroniarz : Robotnica
    {
        public override string nazwa { get; protected set; }
        public Ochroniarz(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public void patroluj()
        {
            Console.WriteLine($"{nazwa}: patroluję ");
        }
        public override void atakuj()
        {
            Console.WriteLine($"{nazwa}: bronię ula");
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
            Krolowa k = new Krolowa("Queen");
            k.dodajPszczole(new Zbieracz("x 1"));
            k.dodajPszczole(new Ochroniarz("o1"));
            k.dodajPszczole(new Zbieracz("z2"));
            k.dodajPszczole(new Ochroniarz("o2"));
            k.dodajPszczole(new Zbieracz("z3"));
            k.dodajPszczole(new Ochroniarz("o3"));
            k.dodajPszczole(new Zbieracz("z4"));
            k.dodajPszczole(new Zbieracz("z5"));
            k.dodajPszczole(new Zbieracz("z6"));
            k.dodajPszczole(new Zbieracz("z7"));

            k.pokazPszczoly();
            for (int i = 0; i < 10; i++) 
                k.przydzielZadanie(i);
            Console.WriteLine("najazd os na ul");
            for (int i = 0; i < 10; i++)
                k.przydzielZadanie(i,"obrona");
        }
    }
}
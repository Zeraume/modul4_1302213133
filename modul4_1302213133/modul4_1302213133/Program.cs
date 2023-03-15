// See https://aka.ms/new-console-template for more information
internal class Program
{
    public enum Buah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung,
        Kurma,
        Durian,
        Anggur,
        Melon,
        Semangka
    }

    public class kodeBuah
    {
        public static string getKodeBuah(Buah buah) 
        {
            string[] isiKodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
            int inputKodeBuah = (int)buah;
            return isiKodeBuah[inputKodeBuah];
        }
    }


    public enum charaState
    {
        Jongkok, Berdiri, Tengkurap, Terbang
    }

    public enum Trigger
    {
        TombolW, TombolS, TombolX
    }

    public class PosisiKarakterGame
    {
        public charaState CurrentState = charaState.Berdiri;
        public class Transition
        {
            public charaState FirstState;
            public charaState LastState;
            public Trigger trigger;

            public Transition(charaState FirstState, charaState LastState, Trigger trigger) { 
                this.FirstState = FirstState;
                this.LastState = LastState;
                this.trigger = trigger;
            }
        }

        Transition[] transitions =
        {
            new Transition(charaState.Jongkok, charaState.Berdiri, Trigger.TombolW),
            new Transition(charaState.Jongkok, charaState.Tengkurap, Trigger.TombolS),
            new Transition(charaState.Tengkurap, charaState.Jongkok, Trigger.TombolW),
            new Transition(charaState.Berdiri, charaState.Jongkok, Trigger.TombolS),
            new Transition(charaState.Berdiri, charaState.Terbang, Trigger.TombolW),
            new Transition(charaState.Terbang, charaState.Berdiri, Trigger.TombolS),
            new Transition(charaState.Terbang, charaState.Jongkok, Trigger.TombolX),
        };

        private charaState getNextState(charaState FirstState, Trigger trigger)
        {
            charaState LastState = FirstState; 
            for(int i = 0; i < transitions.Length; i++)
            {
                Transition changeState = transitions[i];

                if(FirstState == changeState.FirstState && trigger == changeState.trigger)
                {
                    LastState = changeState.LastState;
                }
            }
            return LastState;
        }

        public void activateTrigger(Trigger trigger)
        {
            CurrentState = getNextState(CurrentState, trigger);

            Console.WriteLine("State Character sekarang adalah: " + CurrentState);

            if(CurrentState == charaState.Berdiri)
            {
                Console.WriteLine("Posisi standby");
            } else if(CurrentState == charaState.Tengkurap)
            {
                Console.WriteLine("Posisi Istirahat");
            }
        }
    }

    public static void Main(string[] args)
    {
        //Buah
        Buah buah = Buah.Blackberry;
        string isiKodeBuah = kodeBuah.getKodeBuah(buah);
        Console.WriteLine("Buah " + buah + " memiliki kode " + isiKodeBuah);

        Console.WriteLine("---------------------------------------------------");

        //KarakterGame
        PosisiKarakterGame Chara = new PosisiKarakterGame();
        Console.WriteLine("Posisi pertama karakter: ");
        Console.WriteLine(Chara.CurrentState);
        Console.WriteLine(" ");
        Chara.activateTrigger(Trigger.TombolW);
        Console.WriteLine(" ");
        Chara.activateTrigger(Trigger.TombolS);
        Console.WriteLine(" ");
        Chara.activateTrigger(Trigger.TombolW);
        Console.WriteLine(" ");
        Chara.activateTrigger(Trigger.TombolX);
        Console.WriteLine(" ");
        Chara.activateTrigger(Trigger.TombolS);
    }
}

using System.Security.Cryptography.X509Certificates;

namespace grafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wezel w0 = new Wezel(0);
            Wezel w1 = new Wezel(1);
            Wezel w2 = new Wezel(2);
            Wezel w3 = new Wezel(3);
            Wezel w4 = new Wezel(4);
            Wezel w5 = new Wezel(5);
            Wezel w6 = new Wezel(6);
            Wezel w7 = new Wezel(7);
            Krawedz k1 = new Krawedz(1, w4, w6);
            Krawedz k2 = new Krawedz(2, w4, w5);
            Krawedz k3 = new Krawedz(3, w2, w7);
            Krawedz k4 = new Krawedz(3, w1, w6);
            Krawedz k5 = new Krawedz(4, w2, w4);
            Krawedz k6 = new Krawedz(5, w0, w1);
            Krawedz k7 = new Krawedz(5, w2, w6);
            Krawedz k8 = new Krawedz(6, w1, w5);
            Krawedz k9 = new Krawedz(6, w5, w6);
            Krawedz k10 = new Krawedz(7, w1, w7);
            Krawedz k11 = new Krawedz(8, w1, w4);
            Krawedz k12 = new Krawedz(8, w3, w6);
            Krawedz k13 = new Krawedz(9, w0, w3);
            Krawedz k14 = new Krawedz(9, w1, w2);
            Krawedz k15 = new Krawedz(9, w2, w3);
            Krawedz k16 = new Krawedz(9, w6, w7);
            List<Krawedz> krawedzie = new List<Krawedz>();
            krawedzie.Add(k1);
            krawedzie.Add(k2);  krawedzie.Add(k3); krawedzie.Add(k4);
            krawedzie.Add(k5); krawedzie.Add(k6);   krawedzie.Add(k7);
            krawedzie.Add(k8);  krawedzie.Add(k9); krawedzie.Add(k10);
            krawedzie.Add(k11); krawedzie.Add(k12);     
            krawedzie.Add(k13); krawedzie.Add(k14);
            krawedzie.Add(k15); krawedzie.Add(k16);
        }
        public Graf Stworz(List<Krawedz> krawedzie)
        {
            if (krawedzie == null)
            {
                MessageBox.Show("nie dostalem zadnej krawedzi");
                return null;
            }
            krawedzie.OrderBy(x => x.waga);
            List<Graf> listaGrafow = new List<Graf>();
            Graf g = new Graf(krawedzie[0]);
            listaGrafow.Add(g);
            while(g.ListaWezlow.Count == g.ListaKrawedzi.Count + 1 || krawedzie == null)
            {
                Krawedz k = krawedzie[0];
                krawedzie.RemoveAt(0);
                int ile = g.Sprawdz(k);
                if (ile == 0) continue;
                if(ile == 2)
                {
                    listaGrafow.Add(new Graf(k));
                }
                if(ile == 1)
                {
                    if(listaGrafow.Count == 1)
                    {
                        listaGrafow[0].Add(k);
                    }
                    else
                    {
                        listaGrafow[0].Add(k);
                        for (int i = 1;i< listaGrafow.Count; i++)
                        {
                            int git = listaGrafow[i].Sprawdz(k);
                            if(git == ile)
                            {
                                listaGrafow[0].Join(listaGrafow[i]);
                                listaGrafow.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            return listaGrafow[0];
        }
    }
    public class Graf
    {
        public List<Wezel> ListaWezlow = new List<Wezel>();
        public List<Krawedz> ListaKrawedzi = new List<Krawedz>();
        public Graf(Krawedz k)
        {
            this.ListaWezlow.Add(k.poczatek);
            this.ListaWezlow.Add(k.koniec);
            this.ListaKrawedzi.Add(k);
        }
        public int Sprawdz(Krawedz k)
        {
            int ile = 0;
            if (!this.ListaWezlow.Contains(k.poczatek)) ile++;
            if (!this.ListaWezlow.Contains(k.koniec)) ile++;
            return ile;
        }
        public void Add(Krawedz k)
        {
            if (!this.ListaKrawedzi.Contains(k)) this.ListaKrawedzi.Add(k);
            if (!this.ListaWezlow.Contains(k.poczatek)) this.ListaWezlow.Add(k.poczatek);
            if (!this.ListaWezlow.Contains(k.koniec)) this.ListaWezlow.Add(k.koniec);
        }
        public void Join(Graf g)
        {
            foreach(var k in g.ListaKrawedzi)
            {
                this.Add(k);
            }
        }
    }
    public class Krawedz
    {
        public int waga;
        public Wezel poczatek;
        public Wezel koniec;

        public Krawedz(int waga, Wezel poczatek, Wezel koniec)
        {
            this.waga = waga;
            this.poczatek = poczatek;
            this.koniec = koniec;
        }
    }
    public class Wezel
    {
        public int wartosc;
        public Wezel(int wartosc) {
            this.wartosc = wartosc;
        }
    }
}
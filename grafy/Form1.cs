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
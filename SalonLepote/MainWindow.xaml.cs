using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using SalonLepote.Forme;


namespace SalonLepote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;


        #region Select upiti
        private static string klijentiSelect = @"select KlijentID as ID, ImeKlijenta as Ime, PrezimeKlijenta as Prezime,
                                                KontaktKlijenta as Kontakt from tblKlijent";
        private static string zaposleniSelect = @"select ZaposleniID as ID, ImeZaposlenog as Ime, PrezimeZaposlenog as Prezime, 
                                                KontaktZaposlenog as Kontakt from tblZaposleni";
        private static string proizvodiSelect = @"select ProizvodID as ID, NazivProizvoda as Naziv,
                                                    CenaProizvoda as Cena from tblProizvod";
        private static string uslugeSelect = @"select UslugaID as ID, Naziv as Naziv, Opis as Vrsta
                                               from tblUsluga join tblVrstaUsluge on tblUsluga.VrstaID = tblVrstaUsluge.VrstaID";
        private static string vrsteUslugaSelect = @"select VrstaID as ID, Opis, Trajanje, Cena from tblVrstaUsluge";
        private static string terminiSelect = @"select TerminID as ID, Datum, Vreme from tblTermin";
        private static string nabavkeSelect = @"select NabavkaID as ID, Datum, Kolicina, NazivProizvoda as Proizvod, 
                                                ImeZaposlenog + ' ' + PrezimeZaposlenog as Zaposleni
                                              from tblNabavka join tblProizvod on tblNabavka.ProizvodID = tblProizvod.ProizvodID
                                                              join tblZaposleni on tblNabavka.ZaposleniID = tblZaposleni.ZaposleniID";
        private static string zakazivanjaSelect = @"select ZakazivanjeID as ID, Naziv as Usluga, Datum, Vreme as Termin,
                                                    ImeZaposlenog + ' ' + PrezimeZaposlenog as Zaposleni, ImeKlijenta + ' ' + PrezimeKlijenta as Klijent
                                                    from tblZakazivanjeTretmana join tblUsluga on tblZakazivanjeTretmana.UslugaID = tblUsluga.UslugaID
                                                                                join tblTermin on tblZakazivanjeTretmana.TerminID = tblTermin.TerminID
                                                                                 join tblZaposleni on tblZakazivanjeTretmana.ZaposleniID = tblZaposleni.ZaposleniID
                                                                                 join tblKlijent on tblZakazivanjeTretmana.KlijentID = tblKlijent.KlijentID";

        #endregion

        #region Selection sa uslovom
        private static string selectUslovKlijenti = @"select * from tblKlijent where KlijentID=";
        private static string selectUslovZaposleni = @"select * from tblZaposleni where ZaposleniID=";
        private static string selectUslovProizvodi = @"select * from tblProizvod where ProizvodID=";
        private static string selectUslovNabavke = @"select * from tblNabavka where NabavkaID=";
        private static string selectUslovUsluge = @"select * from tblUsluga where UslugaID=";
        private static string selectUslovVrsteUsluga = @"select * from tblVrstaUsluge where VrstaID=";
        private static string selectUslovTermini = @"select * from tblTermin where TerminID=";
        private static string selectUslovZakazivanja = @"select * from tblZakazivanjeTretmana where ZakazivanjeID=";
        #endregion

        #region Delete
        private static string klijentiDelete = @"delete from tblKlijent where KlijentID=";
        private static string zaposleniDelete = @"delete from tblZaposleni where ZaposleniID=";
        private static string proizvodiDelete = @"delete from tblProizvod where ProizvodID=";
        private static string nabavkeDelete = @"delete from tblNabavka where NabavkaID=";
        private static string uslugeDelete = @"delete from tblUsluga where UslugaID=";
        private static string vrsteUslugaDelete = @"delete delete from tblVrstaUsluge where VrstaID=";
        private static string terminiDelete = @"delete from tblTermin where TerminID=";
        private static string zakazivanjaDelete = @"delete from tblZakazivanjeTretmana where ZakazivanjeID=";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(zakazivanjaSelect);
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnZakazivanja_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(zakazivanjaSelect);        }

        private void btnKlijenti_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(klijentiSelect);
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(zaposleniSelect);
        }

        private void btnUsluge_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(uslugeSelect);
        }

        private void btnVrsteUsluga_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(vrsteUslugaSelect);
        }

        private void btnProizvodi_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(proizvodiSelect);
        }

        private void btnNabavke_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(nabavkeSelect);
        }
        private void btnTermini_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(terminiSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(klijentiSelect))
            {
                prozor = new FrmKlijent();
                prozor.ShowDialog();
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new FrmZaposleni();
                prozor.ShowDialog();
                UcitajPodatke(zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                prozor = new FrmProizvod();
                prozor.ShowDialog();
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(uslugeSelect))
            {
                prozor = new FrmUsluga();
                prozor.ShowDialog();
                UcitajPodatke(uslugeSelect);
            }
            else if (ucitanaTabela.Equals(vrsteUslugaSelect))
            {
                prozor = new FrmVrstaUsluge();
                prozor.ShowDialog();
                UcitajPodatke(vrsteUslugaSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                prozor = new FrmTermin();
                prozor.ShowDialog();
                UcitajPodatke(terminiSelect);
            }
            else if (ucitanaTabela.Equals(nabavkeSelect))
            {
                prozor = new FrmNabavka();
                prozor.ShowDialog();
                UcitajPodatke(nabavkeSelect);
            }
            else 
            {
                prozor = new FrmZakazivanjeTretmana();
                prozor.ShowDialog();
                UcitajPodatke(zakazivanjaSelect);
            }

        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija 
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(klijentiSelect))
                    {
                        FrmKlijent prozorKlijent = new FrmKlijent(azuriraj, red); 
                        prozorKlijent.txtIme.Text = citac["ImeKlijenta"].ToString();
                        prozorKlijent.txtPrezime.Text = citac["PrezimeKlijenta"].ToString();
                        prozorKlijent.txtKontakt.Text = citac["KontaktKlijenta"].ToString();
                        prozorKlijent.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(nabavkeSelect))
                    {
                        FrmNabavka prozorNabavka = new FrmNabavka(azuriraj, red);
                        prozorNabavka.dpDatum.SelectedDate = (DateTime)citac["Datum"];
                        prozorNabavka.txtKolicina.Text = citac["Kolicina"].ToString();
                        prozorNabavka.cbZaposleni.SelectedValue = citac["ZaposleniID"].ToString();
                        prozorNabavka.cbProizvod.SelectedValue = citac["ProizvodID"].ToString();
                        prozorNabavka.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(proizvodiSelect))
                    {
                        FrmProizvod prozorProizvod = new FrmProizvod(azuriraj, red);
                        prozorProizvod.txtNaziv.Text = citac["NazivProizvoda"].ToString();
                        prozorProizvod.txtCena.Text = citac["CenaProizvoda"].ToString();
                        prozorProizvod.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        FrmZaposleni prozorTip = new FrmZaposleni(azuriraj, red);
                        prozorTip.txtImeZaposlenog.Text = citac["ImeZaposlenog"].ToString();
                        prozorTip.txtPrezimeZaposlenog.Text = citac["PrezimeZaposlenog"].ToString();
                        prozorTip.txtKontaktZaposlenog.Text = citac["KontaktZaposlenog"].ToString();
                        prozorTip.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(uslugeSelect))
                    {
                        FrmUsluga prozorUsluga = new FrmUsluga(azuriraj, red);
                        prozorUsluga.txtNaziv.Text = citac["Naziv"].ToString();
                        prozorUsluga.cbVrsta.Text = citac["VrstaID"].ToString();
                        prozorUsluga.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(vrsteUslugaSelect))
                    {
                        FrmVrstaUsluge prozorVrsta = new FrmVrstaUsluge(azuriraj, red);
                        prozorVrsta.txtOpis.Text = citac["Opis"].ToString();
                        prozorVrsta.txtTrajanje.Text = citac["Trajanje"].ToString();
                        prozorVrsta.txtCena.Text = citac["Cena"].ToString();

                        prozorVrsta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zakazivanjaSelect))
                    {
                        FrmZakazivanjeTretmana prozorZakazivanja = new FrmZakazivanjeTretmana(azuriraj, red);
                        prozorZakazivanja.cbUsluga.SelectedValue = citac["UslugaID"].ToString();
                        prozorZakazivanja.cbTermin.SelectedValue = citac["TerminID"].ToString();
                        prozorZakazivanja.cbZaposleni.SelectedValue = citac["ZaposleniID"].ToString();
                        prozorZakazivanja.cbKlijent.SelectedValue = citac["KlijentID"].ToString();

                        prozorZakazivanja.ShowDialog();
                    }
                    else
                    {
                        FrmTermin prozorTermin = new FrmTermin(azuriraj, red);
                        prozorTermin.dpDatum.Text = citac["Datum"].ToString();
                        prozorTermin.txtVreme.Text = citac["Vreme"].ToString();
                        prozorTermin.ShowDialog();

                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(klijentiSelect))
            {
                PopuniFormu(selectUslovKlijenti);
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(nabavkeSelect))
            {
                PopuniFormu(selectUslovNabavke);
                UcitajPodatke(nabavkeSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                PopuniFormu(selectUslovZaposleni);
                UcitajPodatke(zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(uslugeSelect))
            {
                PopuniFormu(selectUslovUsluge);
                UcitajPodatke(uslugeSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                PopuniFormu(selectUslovProizvodi);
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(vrsteUslugaSelect))
            {
                PopuniFormu(selectUslovVrsteUsluga);
                UcitajPodatke(vrsteUslugaSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                PopuniFormu(selectUslovTermini);
                UcitajPodatke(terminiSelect);
            }
            else
            {
                PopuniFormu(selectUslovZakazivanja);
                UcitajPodatke(zakazivanjaSelect);
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(klijentiSelect))
            {
                ObrisiZapis(klijentiDelete);
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(nabavkeSelect))
            {
                ObrisiZapis(nabavkeDelete);
                UcitajPodatke(nabavkeSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                ObrisiZapis(zaposleniDelete);
                UcitajPodatke(zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(uslugeSelect))
            {
                ObrisiZapis(uslugeDelete);
                UcitajPodatke(uslugeSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                ObrisiZapis(proizvodiDelete);
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(vrsteUslugaSelect))
            {
                ObrisiZapis(vrsteUslugaDelete);
                UcitajPodatke(vrsteUslugaSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                ObrisiZapis(terminiDelete);
                UcitajPodatke(terminiSelect);
            }
            else
            {
                ObrisiZapis(zakazivanjaDelete);
                UcitajPodatke(zakazivanjaSelect);
            }
        }

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand 
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
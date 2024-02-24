using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalonLepote.Forme
{
    /// <summary>
    /// Interaction logic for FrmNabavka.xaml
    /// </summary>
    public partial class FrmNabavka : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmNabavka()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            cbProizvod.Focus();
            PopuniPadajuceListe();

        }

        public FrmNabavka(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            cbProizvod.Focus();
            this.red = red;
            this.azuriraj = azuriraj;
            PopuniPadajuceListe();

        }
        private void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiZaposlene = @"select ZaposleniID, ImeZaposlenog + ' ' + PrezimeZaposlenog as zaposleni, KontaktZaposlenog from tblZaposleni"; 
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                DataTable dtZaposleni = new DataTable();
                daZaposleni.Fill(dtZaposleni);
                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

                string vratiProizvode = @"select ProizvodID, NazivProizvoda, CenaProizvoda from tblProizvod"; 
                SqlDataAdapter daProizvodi = new SqlDataAdapter(vratiProizvode, konekcija);
                DataTable dtProizvodi = new DataTable();
                daProizvodi.Fill(dtProizvodi);
                cbProizvod.ItemsSource = dtProizvodi.DefaultView;
                daProizvodi.Dispose();
                dtProizvodi.Dispose();


            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)dpDatum.SelectedDate;
            string datum = date.ToString("yyyy-MM-dd");
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@Kolicina", SqlDbType.Int).Value = txtKolicina.Text;
                cmd.Parameters.Add("@ZaposleniID", SqlDbType.Int).Value = cbZaposleni.SelectedValue;
                cmd.Parameters.Add("@ProizvodID", SqlDbType.Int).Value = cbProizvod.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblNabavka set Datum=@Datum,Kolicina=@Kolicina, ZaposleniID=@ZaposleniID, ProizvodID=@ProizvodID  where NabavkaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblNabavka(Datum, Kolicina, ZaposleniID, ProizvodID)
                                    values (@Datum, @Kolicina, @ZaposleniID, @ProizvodID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

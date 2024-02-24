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
    /// Interaction logic for FrmZakazivanjeTretmana.xaml
    /// </summary>
    public partial class FrmZakazivanjeTretmana : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmZakazivanjeTretmana()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            cbUsluga.Focus();
            PopuniPadajuceListe();
        }

        public FrmZakazivanjeTretmana(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            cbUsluga.Focus();
            PopuniPadajuceListe();
            this.red = red;
            this.azuriraj = azuriraj;
        }

        private void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiUslugu = @"select UslugaID, Naziv, VrstaID from tblUsluga"; 
                SqlDataAdapter daUsluga = new SqlDataAdapter(vratiUslugu, konekcija);
                DataTable dtUsluga = new DataTable();
                daUsluga.Fill(dtUsluga);
                cbUsluga.ItemsSource = dtUsluga.DefaultView;
                daUsluga.Dispose();
                dtUsluga.Dispose();

                string vratiTermin = @"select TerminID, Datum, Vreme from tblTermin"; 
                SqlDataAdapter daTermin = new SqlDataAdapter(vratiTermin, konekcija);
                DataTable dtTermin = new DataTable();
                daTermin.Fill(dtTermin);
                cbTermin.ItemsSource = dtTermin.DefaultView;
                daTermin.Dispose();
                dtTermin.Dispose();

                string vratiZaposlenog = @"select ZaposleniID, ImeZaposlenog, PrezimeZaposlenog, KontaktZaposlenog from tblZaposleni"; 
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlenog, konekcija);
                DataTable dtZaposleni = new DataTable();
                daZaposleni.Fill(dtZaposleni);
                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

                string vratiKlijenta = @"select KlijentID, ImeKlijenta + ' ' + PrezimeKlijenta as Klijent, KontaktKlijenta from tblKlijent"; 
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijenta, konekcija);
                DataTable dtKlijent = new DataTable();
                daKlijent.Fill(dtKlijent);
                cbKlijent.ItemsSource = dtKlijent.DefaultView;
                daKlijent.Dispose();
                dtKlijent.Dispose();

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
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija 
                };
                cmd.Parameters.Add("@UslugaID", SqlDbType.Int).Value = cbUsluga.SelectedValue; 
                cmd.Parameters.Add("@TerminID", SqlDbType.Int).Value = cbTermin.SelectedValue;
                cmd.Parameters.Add("@ZaposleniID", SqlDbType.Int).Value = cbZaposleni.SelectedValue;
                cmd.Parameters.Add("@KlijentID", SqlDbType.Int).Value = cbKlijent.SelectedValue;
                
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblZakazivanjeTretmana set UslugaID=@UslugaID, TerminID=@TerminID, ZaposleniID=@ZaposleniID, KlijentID=@KlijentID
                        where ZakazivanjeID = @id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblZakazivanjeTretmana(UslugaID, TerminID, ZaposleniID, KlijentID)
                                    values (@UslugaID, @TerminID, @ZaposleniID, @KlijentID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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

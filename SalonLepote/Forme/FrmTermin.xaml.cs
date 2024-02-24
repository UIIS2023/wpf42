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
    /// Interaction logic for FrmTermin.xaml
    /// </summary>
    public partial class FrmTermin : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmTermin()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            dpDatum.Focus();
        }

        public FrmTermin(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            dpDatum.Focus();
            this.red = red;
            this.azuriraj = azuriraj;
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
                cmd.Parameters.Add("@Vreme", SqlDbType.Time).Value = txtVreme.Text;

               
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblTermin set Datum=@Datum, Vreme=@Vreme where TerminID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTermin(Datum, Vreme)
                                    values (@Datum, @Vreme)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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

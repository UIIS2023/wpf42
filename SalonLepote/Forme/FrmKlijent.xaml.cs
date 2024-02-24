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
    /// Interaction logic for FrmKlijent.xaml
    /// </summary>
    public partial class FrmKlijent : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmKlijent()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
        }

        public FrmKlijent(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
            this.red = red;
            this.azuriraj = azuriraj;
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
                cmd.Parameters.Add("@ImeKlijenta", SqlDbType.NVarChar).Value = txtIme.Text; 
                cmd.Parameters.Add("@PrezimeKlijenta", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@KontaktKlijenta", SqlDbType.NVarChar).Value = txtKontakt.Text;
                
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKlijent set ImeKlijenta=@ImeKlijenta, PrezimeKlijenta=@PrezimeKlijenta, KontaktKlijenta=@KontaktKlijenta
                        where KlijentID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKlijent(ImeKlijenta, PrezimeKlijenta, KontaktKlijenta)
                                    values (@ImeKlijenta, @PrezimeKlijenta, @KontaktKlijenta)";
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
                MessageBox.Show("Doslo je do greske priliom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
    


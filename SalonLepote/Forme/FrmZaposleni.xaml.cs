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
    /// Interaction logic for FrmZaposleni.xaml
    /// </summary>
    public partial class FrmZaposleni : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmZaposleni()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeZaposlenog.Focus();
           
        }

        public FrmZaposleni(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeZaposlenog.Focus();
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
                cmd.Parameters.Add("@ImeZaposlenog", SqlDbType.NVarChar).Value = txtImeZaposlenog.Text; 
                cmd.Parameters.Add("@PrezimeZaposlenog", SqlDbType.NVarChar).Value = txtPrezimeZaposlenog.Text;
                cmd.Parameters.Add("@KontaktZaposlenog", SqlDbType.NVarChar).Value = txtKontaktZaposlenog.Text;
                
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblZaposleni set ImeZaposlenog=@ImeZaposlenog, PrezimeZaposlenog=@PrezimeZaposlenog, KontaktZaposlenog=@KontaktZaposlenog
                        where ZaposleniID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblZaposleni(ImeZaposlenog, PrezimeZaposlenog, KontaktZaposlenog)
                                    values (@ImeZaposlenog, @PrezimeZaposlenog, @KontaktZaposlenog)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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

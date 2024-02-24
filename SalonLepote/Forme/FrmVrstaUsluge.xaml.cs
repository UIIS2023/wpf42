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
    /// Interaction logic for FrmVrstaUsluge.xaml
    /// </summary>
    public partial class FrmVrstaUsluge : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmVrstaUsluge()
        {

            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtOpis.Focus();
            
        }
        public FrmVrstaUsluge(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtOpis.Focus();
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
                cmd.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = txtOpis.Text; 
                cmd.Parameters.Add("@Trajanje", SqlDbType.Int).Value = txtTrajanje.Text;
                cmd.Parameters.Add("@Cena", SqlDbType.Int).Value = txtCena.Text;
               
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblVrstaUsluge set Opis = @Opis, Trajanje=@Trajanje, Cena=@Cena
                        where VrstaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblVrstaUsluge(Opis, Trajanje, Cena)
                                    values (@Opis, @Trajanje, @Cena)";
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

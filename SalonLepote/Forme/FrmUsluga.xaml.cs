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
    /// Interaction logic for FrmUsluga.xaml
    /// </summary>
    public partial class FrmUsluga : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmUsluga()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNaziv.Focus();
            PopuniPadajuceListe();
        }

        public FrmUsluga(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNaziv.Focus();
            this.red = red;
            this.azuriraj = azuriraj;
            PopuniPadajuceListe();

        }

        private void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiVrstu = @"select VrstaID, Opis, Trajanje, Cena from tblVrstaUsluge"; 
                SqlDataAdapter daVrsta = new SqlDataAdapter(vratiVrstu, konekcija);
                DataTable dtVrsta = new DataTable();
                daVrsta.Fill(dtVrsta);
                cbVrsta.ItemsSource = dtVrsta.DefaultView;
                daVrsta.Dispose();
                dtVrsta.Dispose();

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
                cmd.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = txtNaziv.Text; 
                cmd.Parameters.Add("@VrstaID", SqlDbType.Int).Value = cbVrsta.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblUsluga set Naziv = @Naziv, VrstaID=@VrstaID
                                        where UslugaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblUsluga(Naziv, VrstaID)
                                    values (@Naziv, @VrstaID)";
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

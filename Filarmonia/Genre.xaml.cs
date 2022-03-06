using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Filarmonia
{
    /// <summary>
    /// Логика взаимодействия для Genre.xaml
    /// </summary>
    public partial class Genre : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public Genre()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик вывода данных из базы данных в окно
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try

            {

                connect.Open();

                SqlCommand command = new SqlCommand("SELECT ID_genre, Name_genre AS 'Жанр' from Genre", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                connect.Close();

            }

        }
        /// <summary>
        /// Обработчик нажатия кнопки "Найти"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        int g = 0;
        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            {
                if (g == 0)
                {

                    SqlCommand command1 = new SqlCommand("SELECT ID_genre, Name_genre AS 'Жанр' from Genre where (Name_genre like  '" + Poisk1.Text + "%') ", connect);
                    connect.Open();


                    DataTable datatbl1 = new DataTable();
                    datatbl1.Load(command1.ExecuteReader());
                    dg1.ItemsSource = datatbl1.DefaultView;
                    connect.Close();
                    g = 1;
                }
                else
                {
                    Window_Loaded(sender, e);
                    g = 0;
                }
            }
        }
        /// <summary>
        /// Обработчик вывода данных в датагрид
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg1.SelectedItem == null) return;


            DataRowView row = (DataRowView)dg1.SelectedItem;

            NameGenre.Text = row["Жанр"].ToString();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MenuImpresario ter = new MenuImpresario();
            this.Close();
            ter.Show();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите удалить"); return; }

            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Del = new SqlCommand("Genre_Delete", connect);

                Del.CommandType = CommandType.StoredProcedure;

                Del.Parameters.AddWithValue("ID_genre", (int)row["ID_genre"]);

                Del.ExecuteNonQuery();


            }

            catch (SqlException ex)

            {

                MessageBox.Show("Нельзя удалить данный жанр, так как она используется в другой таблице");

            }

            finally

            {

                connect.Close();

                Window_Loaded(sender, e);

            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Изменить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите изменить"); return; }
            if (NameGenre.Text == "") { MessageBox.Show("Поле обязательно для заполнения!"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(NameGenre.Text)) { MessageBox.Show("Нельзя вводить числа в поле наименование жанра"); return; }
            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("Genre_Update", connect);
                Upd.CommandType = CommandType.StoredProcedure;
                Upd.Parameters.AddWithValue("@ID_genre", (int)row["ID_genre"]);

                Upd.Parameters.AddWithValue("@Name_genre", NameGenre.Text);
                Upd.ExecuteNonQuery();

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                connect.Close();

                Window_Loaded(sender, e);

            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NameGenre.Text == "") { MessageBox.Show("Поле обязательно для заполнения!"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(NameGenre.Text)) { MessageBox.Show("Нельзя вводить числа в поле наименование жанра"); return; }
            try

            {

                connect.Open();

                SqlCommand add = new SqlCommand("Genre_Insert", connect);

                add.CommandType = CommandType.StoredProcedure;

                add.Parameters.AddWithValue("@Name_genre", NameGenre.Text);




                add.ExecuteNonQuery();

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                connect.Close();

                Window_Loaded(sender, e);

            }
        }
    }
}

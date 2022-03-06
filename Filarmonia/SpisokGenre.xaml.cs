using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Filarmonia
{
    /// <summary>
    /// Логика взаимодействия для SpisokGenre.xaml
    /// </summary>
    public partial class SpisokGenre : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public SpisokGenre()
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

                SqlCommand command = new SqlCommand("SELECT ID_list_of_the_genre, Name_genre  AS 'Жанр', Surname_actor  AS 'Фамилия артиста' from List_of_the_genre join Genre on ID_genre=genre_ID join Actor on ID_Actor=Actor_ID ", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;


                SqlCommand command4 = new SqlCommand("SELECT ID_genre, Name_genre as 'Жанр' from Genre", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Genre.ItemsSource = datatbl4.DefaultView;
                Genre.DisplayMemberPath = "Жанр";
                Genre.SelectedValuePath = "ID_genre";

                SqlCommand command3 = new SqlCommand("SELECT ID_Actor, Surname_actor as 'Фамилия артиста' from Actor", connect);

                DataTable datatbl3 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Actor.ItemsSource = datatbl4.DefaultView;
                Actor.DisplayMemberPath = "Фамилия артиста";
                Actor.SelectedValuePath = "ID_Actor";

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

                    SqlCommand command1 = new SqlCommand("SELECT ID_list_of_the_genre, Name_genre  AS 'Жанр', Surname_actor  AS 'Фамилия артиста' from List_of_the_genre join Genre on ID_genre=genre_ID join Actor on ID_Actor=Actor_ID where  (Name_genre like  '" + Poisk1.Text + "%') or (Surname_actor like  '" + Poisk1.Text + "%') ", connect);
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

          

            Genre.Text = row["Жанр"].ToString();

            Actor.Text = row["Фамилия артиста"].ToString();

        }
        /// <summary>
        /// Обработчик нажатия кнопки "Добавить жанр"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            Genre ter = new Genre();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "добавить артиста"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void AddActor_Click(object sender, RoutedEventArgs e)
        {
            Actor ter = new Actor();
            this.Close();
            ter.Show();
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
                SqlCommand Del = new SqlCommand("List_of_the_genre_Delete", connect);

                Del.CommandType = CommandType.StoredProcedure;

                Del.Parameters.AddWithValue("ID_list_of_the_genre", (int)row["ID_list_of_the_genre"]);

                Del.ExecuteNonQuery();


            }

            catch (SqlException ex)

            {

                MessageBox.Show("Нельзя удалить данную строку так как она используется в другой таблице");

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
            if (Genre.SelectedValue == null || Actor.SelectedValue == null ) { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("List_of_the_genre_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_list_of_the_genre", (int)row["ID_list_of_the_genre"]);


                Upd.Parameters.AddWithValue("@ID_genre", Genre.SelectedValue);

                Upd.Parameters.AddWithValue("@Actor_ID", Actor.SelectedValue);


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
            if (Genre.SelectedValue == null || Actor.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand add = new SqlCommand("List_of_the_genre_Insert", connect);

                add.CommandType = CommandType.StoredProcedure;



                add.Parameters.AddWithValue("@ID_genre", Genre.SelectedValue);

                add.Parameters.AddWithValue("@Actor_ID", Actor.SelectedValue);


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

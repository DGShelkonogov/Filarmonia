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

    public partial class Soorugen : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public Soorugen()
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

                SqlCommand command = new SqlCommand("SELECT ID_Cultural_building, Name_Cultural_building  AS 'Наименование культурного сооружения', Name_type_of_structure  AS 'Тип сооружения' from Cultural_building join Type_of_structure on ID_type_of_structure=type_of_structure_ID ", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;


                SqlCommand command4 = new SqlCommand("SELECT ID_type_of_structure, Name_type_of_structure from Type_of_structure", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Type.ItemsSource = datatbl4.DefaultView;
                Type.DisplayMemberPath = "Name_type_of_structure";
                Type.SelectedValuePath = "ID_type_of_structure";

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

                    SqlCommand command1 = new SqlCommand("SELECT ID_Cultural_building, Name_Cultural_building  AS 'Наименование культурного сооружения', Name_type_of_structure  AS 'Тип сооружения' from Cultural_building join Type_of_structure on ID_type_of_structure=type_of_structure_ID where (Name_Cultural_building like  '" + Poisk1.Text + "%') or (Name_type_of_structure like  '" + Poisk1.Text + "%')", connect);
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

            NameSoorugen.Text = row["Наименование культурного сооружения"].ToString();

            Type.Text = row["Тип сооружения"].ToString();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Добавить новый тип"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            TypeSoorugen ter = new TypeSoorugen();
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
            MenuAdmin ter = new MenuAdmin();
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
                SqlCommand Del = new SqlCommand("Cultural_building_Delete", connect);

                Del.CommandType = CommandType.StoredProcedure;

                Del.Parameters.AddWithValue("ID_Cultural_building", (int)row["ID_Cultural_building"]);

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
            if (NameSoorugen.Text == "" || Type.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(NameSoorugen.Text)) { MessageBox.Show("Нельзя вводить числа в поле наименование сооружения"); return; }

            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("Cultural_building_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_Cultural_building", (int)row["ID_Cultural_building"]);

                Upd.Parameters.AddWithValue("@Name_Cultural_building ", NameSoorugen.Text);

                Upd.Parameters.AddWithValue("@type_of_structure_ID", Type.SelectedValue);

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
            if (NameSoorugen.Text == "" || Type.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(NameSoorugen.Text)) { MessageBox.Show("Нельзя вводить числа в поле наименование сооружения"); return; }

            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand add = new SqlCommand("Cultural_building_Insert", connect);

                add.CommandType = CommandType.StoredProcedure;


                add.Parameters.AddWithValue("@Name_Cultural_building ", NameSoorugen.Text);

                add.Parameters.AddWithValue("@type_of_structure_ID", Type.SelectedValue);

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

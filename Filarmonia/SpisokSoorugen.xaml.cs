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
    /// Логика взаимодействия для SpisokSoorugen.xaml
    /// </summary>
    public partial class SpisokSoorugen : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public SpisokSoorugen()
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

                SqlCommand command = new SqlCommand("SELECT ID_list_of_characteristics, Name_type_of_structure  AS 'Тип сооружения', Name_charcteristic_of_the_structure  AS 'Наименование харктеристик сооружения', size as 'Размер' from [List_of_characteristics] join Type_of_structure on ID_type_of_structure=type_of_structure_ID join charcteristic_of_the_structure on ID_charcteristic_of_the_structure=charcteristic_of_the_structure_ID ", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;


                SqlCommand command4 = new SqlCommand("SELECT ID_type_of_structure, Name_type_of_structure from Type_of_structure", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Type.ItemsSource = datatbl4.DefaultView;
                Type.DisplayMemberPath = "Name_type_of_structure";
                Type.SelectedValuePath = "ID_type_of_structure";

                SqlCommand command3 = new SqlCommand("SELECT ID_charcteristic_of_the_structure, Name_charcteristic_of_the_structure from charcteristic_of_the_structure", connect);

                DataTable datatbl3 = new DataTable();

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
        /// Обработчик вывода данных в датагрид
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg1.SelectedItem == null) return;



            DataRowView row = (DataRowView)dg1.SelectedItem;

            Type.Text = row["Тип сооружения"].ToString();

            NameSoorugen.Text = row["Наименование характеристик сооружения"].ToString();

            Size.Text = row["Размер"].ToString();


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

                    SqlCommand command1 = new SqlCommand("SELECT ID_list_of_characteristics, Name_type_of_structure  AS 'Тип сооружения', Name_charcteristic_of_the_structure  AS 'Наименование харктеристик сооружения', size as 'Размер' from [List_of_characteristics] join Type_of_structure on ID_type_of_structure=type_of_structure_ID join charcteristic_of_the_structure on ID_charcteristic_of_the_structure=charcteristic_of_the_structure_ID where  (Name_type_of_structure like  '" + Poisk1.Text + "%') or (Name_charcteristic_of_the_structure like  '" + Poisk1.Text + "%') or (size like  '" + Poisk1.Text + "%') ", connect);
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
                SqlCommand Del = new SqlCommand("List_of_characteristics_Delete", connect);

                Del.CommandType = CommandType.StoredProcedure;

                Del.Parameters.AddWithValue("ID_list_of_characteristics", (int)row["ID_list_of_characteristics"]);

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
        /// Обработчик нажатия кнопки "Изменить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите изменить"); return; }
            if (Type.SelectedValue == null || NameSoorugen.SelectedValue == null || Size.Text == "") { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("List_of_characteristics_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_list_of_characteristics", (int)row["ID_list_of_characteristics"]);


                Upd.Parameters.AddWithValue("@ID_type_of_structure", Type.SelectedValue);

                Upd.Parameters.AddWithValue("@ID_charcteristic_of_the_structure", NameSoorugen.SelectedValue);

                Upd.Parameters.AddWithValue("@size ", Size.Text);

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
            if (Type.SelectedValue == null || NameSoorugen.SelectedValue == null || Size.Text == "") { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand add = new SqlCommand("List_of_characteristics_Insert", connect);

                add.CommandType = CommandType.StoredProcedure;




                add.Parameters.AddWithValue("@ID_type_of_structure", Type.SelectedValue);

                add.Parameters.AddWithValue("@ID_charcteristic_of_the_structure", NameSoorugen.SelectedValue);

                add.Parameters.AddWithValue("@size ", Size.Text);

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

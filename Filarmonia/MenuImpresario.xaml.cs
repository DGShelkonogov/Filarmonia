using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MenuImpresario.xaml
    /// </summary>
    public partial class MenuImpresario : Window
    {
        public MenuImpresario()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню актеров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Actor_Click(object sender, RoutedEventArgs e)
        {
            Actor ter = new Actor();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню списка актеров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Spisok_Actor_Click(object sender, RoutedEventArgs e)
        {
            SpisokActor ter = new SpisokActor();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню списка жанров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Spisok_Genre_Click(object sender, RoutedEventArgs e)
        {
            SpisokGenre ter = new SpisokGenre();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню списка жанров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void M_Genre_Click(object sender, RoutedEventArgs e)
        {
            Genre ter = new Genre();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню мероприятий"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Ever_Click(object sender, RoutedEventArgs e)
        {
            ActorEvent ter = new ActorEvent();
            this.Close();
            ter.Show();
        }
    }
}

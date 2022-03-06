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
    /// Логика взаимодействия для MenuActor.xaml
    /// </summary>
    public partial class MenuActor : Window
    {
        public MenuActor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Меню жанров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            GenreActor ter = new GenreActor();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню актеров для актеров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void ActortoActor_Click(object sender, RoutedEventArgs e)
        {
            ActorForActor ter = new ActorForActor();
            this.Close();
            ter.Show();
        }
    }
}

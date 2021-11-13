using Crypthat.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crypthat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BlockChain _blocks;

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedBlock = BlocksList.SelectedIndex;
            BlockContent.Text = _blocks[selectedBlock].Data;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBlock = BlocksList.SelectedIndex;
            if (selectedBlock is -1)
            {
                MessageBox.Show("Выберите блок!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_blocks is null)
            {
                MessageBox.Show("Добавьте хоть один блок!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _blocks.Insert(selectedBlock, BlockContent.Text);

            BlocksData.Text = _blocks.ToString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(BlockContent.Text))
            {
                MessageBox.Show("Введите текст блока!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_blocks is null)
            {
                _blocks = new BlockChain(BlockContent.Text);
            }
            else
            {
                _blocks.Add(BlockContent.Text);
            }

            BlocksList.Items.Add(_blocks[^1].Data);


            BlockContent.Text = "";
            BlocksData.Text = _blocks.ToString();
        }

        private void BlockContent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
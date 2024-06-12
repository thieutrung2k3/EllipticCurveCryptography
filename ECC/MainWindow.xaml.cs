using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Words.NET;

namespace ECC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Values values;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtPlainText1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập bản rõ!!");
            }
            else
            {
                string s = txtPlainText1.Text;
                values = EllipticCurveCryptography.ToEncrypt(s);
                string en = "";
                foreach(EncryptedVersion ev in values.encryptedVersions)
                {
                    en += ev.ToString();
                }
                txtCipherText1.Text = en;
            }

        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            txtCipherText2.Text = txtCipherText1.Text;
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach(Point p in EllipticCurveCryptography.ToEncrypt(txtPlainText1.Text).getListConvert())
            {
                s += p.ToString() + "\n";
            }
            txtPlainText2.Text = EllipticCurveCryptography.ToDecrypt(values);
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word documents (*.docx)|*.docx|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string content = "";
                    if (filePath.EndsWith(".docx"))
                    {
                        using (DocX document = DocX.Load(filePath))
                        {
                            foreach (var p in document.Paragraphs)
                            {
                                content += p.Text + "\n";
                            }
                        }
                    }
                    else if (filePath.EndsWith(".txt"))
                    {
                        content = System.IO.File.ReadAllText(filePath);
                    }

                    txtPlainText1.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word documents (*.docx)|*.docx|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string content = "";
                    if (filePath.EndsWith(".docx"))
                    {
                        using (DocX document = DocX.Load(filePath))
                        {
                            foreach (var p in document.Paragraphs)
                            {
                                content += p.Text + "\n";
                            }
                        }
                    }
                    else if (filePath.EndsWith(".txt"))
                    {
                        content = System.IO.File.ReadAllText(filePath);
                    }

                    txtCipherText2.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word documents (*.docx)|*.docx|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    if (filePath.EndsWith(".docx"))
                    {
                        using (DocX document = DocX.Create(filePath))
                        {
                            document.InsertParagraph(txtCipherText1.Text);
                            document.Save();
                        }
                    }
                    else if (filePath.EndsWith(".txt"))
                    {
                        System.IO.File.WriteAllText(filePath, txtCipherText1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }

        }

        private void btnSave2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word documents (*.docx)|*.docx|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    if (filePath.EndsWith(".docx"))
                    {
                        using (DocX document = DocX.Create(filePath))
                        {
                            document.InsertParagraph(txtPlainText2.Text);
                            document.Save();
                        }
                    }
                    else if (filePath.EndsWith(".txt"))
                    {
                        System.IO.File.WriteAllText(filePath, txtPlainText2.TText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }

        }
    }
}
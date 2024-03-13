using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            xmlOpenButton.Click += XMLOpenButton_Click;
            xslOpenButton.Click += XSLOpenButton_Click;
            transformButton.Click += TransformButton_Click;
            outputSaveButton.Click += OutputSaveButton_Click;
        }

        private XmlDocument xmlDocument = new XmlDocument();

        private void XMLOpenButton_Click(object sender, EventArgs e)
        {
            if (xmlOpenDialog.ShowDialog() == DialogResult.OK)
            {
                xmlPathLabel.Text = xmlOpenDialog.FileName;
            }
        }
        private void XSLOpenButton_Click(object sender, EventArgs e)
        {
            if (xslOpenDialog.ShowDialog() == DialogResult.OK)
            {
                xslPathLabel.Text = xslOpenDialog.FileName;
            }
        }
        private void OutputSaveButton_Click(object sender, EventArgs e)
        {
            if (outputSaveDialog.ShowDialog() == DialogResult.OK)
            {
                outputSaveDialog.FileName = Path.ChangeExtension(outputSaveDialog.FileName, ".xml");
                outputPathLabel.Text = outputSaveDialog.FileName;
            }
        }
        private void TransformButton_Click(object sender, EventArgs e)
        {
            // Проверяется, все ли файлы были выбраны
            if (IsFileSelected(xmlOpenDialog, ".xml"))
            {
                MessageBox.Show("XML-файл не выбран", "Файл не выбран");
                return;
            }
            if (IsFileSelected(xslOpenDialog, ".xsl"))
            {
                MessageBox.Show("XSL-файл не выбран", "Файл не выбран");
                return;
            }
            if (string.IsNullOrEmpty(outputSaveDialog.FileName))
            {
                MessageBox.Show("Директория сохранения не выбрана", "Директория не выбрана");
                return;
            }

            ConvertXML();
            ModifyOutput(out XmlNodeList groupNodes);
            ModifyInput(out XmlNode listNode);
            ShowResult(groupNodes, listNode);
        }
        private void ConvertXML()
        {
            // Преобразование
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslOpenDialog.FileName);
            xslt.Transform(xmlOpenDialog.FileName, outputSaveDialog.FileName);
        }
        private void ModifyOutput(out XmlNodeList groupNodes)
        {
            // Добавление атрибута в выходные данные
            xmlDocument.Load(outputSaveDialog.FileName);

            groupNodes = xmlDocument.SelectNodes("//group");
            foreach (XmlNode groupNode in groupNodes)
            {
                int itemCount = groupNode.SelectNodes("item").Count;
                groupNode.Attributes.Append(xmlDocument.CreateAttribute("count"));
                groupNode.Attributes["count"].Value = itemCount.ToString();
            }

            xmlDocument.Save(outputSaveDialog.FileName);
        }
        private void ModifyInput(out XmlNode listNode)
        {
            // Добавление атрибута во входные данные
            xmlDocument.Load(xmlOpenDialog.FileName);

            listNode = xmlDocument.SelectSingleNode("//list");
            int itemCount = listNode.SelectNodes("item").Count;
            listNode.Attributes.Append(xmlDocument.CreateAttribute("count"));
            listNode.Attributes["count"].Value = itemCount.ToString();

            xmlDocument.Save(xmlOpenDialog.FileName);
        }
        private void ShowResult(XmlNodeList groupNodes, XmlNode listNode)
        {
            // Отображение результатов в GUI
            outputListBox.Items.Clear();

            xmlDocument.Load(outputSaveDialog.FileName);

            groupNodes = xmlDocument.SelectNodes("//group");
            foreach (XmlNode groupNode in groupNodes)
            {
                outputListBox.Items.Add($"Имя группы: \"{groupNode.Attributes["name"].Value}\", Количество элементов: \"{groupNode.Attributes["count"].Value}\"");
            }

            xmlDocument.Load(xmlOpenDialog.FileName);

            listNode = xmlDocument.SelectSingleNode("//list");
            outputListBox.Items.Add($"Количество элементов в <list>: \"{listNode.Attributes["count"].Value}\"");
        }
        private bool IsFileSelected(OpenFileDialog openFileDialog, string extension)
        {
            return string.IsNullOrEmpty(openFileDialog.FileName) || !Path.GetExtension(openFileDialog.FileName).Equals(extension);
        }
    }
}
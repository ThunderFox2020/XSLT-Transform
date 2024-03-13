using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class MainForm
    {
        private IContainer components = null;
        private Button xmlOpenButton;
        private Button xslOpenButton;
        private Button transformButton;
        private Button outputSaveButton;
        private OpenFileDialog xmlOpenDialog;
        private OpenFileDialog xslOpenDialog;
        private SaveFileDialog outputSaveDialog;
        private Label xmlPathLabel;
        private Label xslPathLabel;
        private Label outputPathLabel;
        private ListBox outputListBox;

        // Инициализация и настройка компонентов формы
        private void InitializeComponent()
        {
            xmlOpenButton = new Button();
            xslOpenButton = new Button();
            transformButton = new Button();
            outputSaveButton = new Button();
            xmlOpenDialog = new OpenFileDialog();
            xslOpenDialog = new OpenFileDialog();
            outputSaveDialog = new SaveFileDialog();
            xmlPathLabel = new Label();
            xslPathLabel = new Label();
            outputPathLabel = new Label();
            outputListBox = new ListBox();
            SuspendLayout();
            
            xmlOpenButton.Name = "xmlOpenButton";
            xmlOpenButton.Text = "Выбрать XML";
            xmlOpenButton.Location = new Point(20, 20);
            xmlOpenButton.Size = new Size(100, 25);
            xmlOpenButton.Margin = new Padding(0);
            xmlOpenButton.TabIndex = 0;
            xmlOpenButton.UseVisualStyleBackColor = true;
            
            xslOpenButton.Name = "xslOpenButton";
            xslOpenButton.Text = "Выбрать XSL";
            xslOpenButton.Location = new Point(20, 65);
            xslOpenButton.Size = new Size(100, 25);
            xslOpenButton.Margin = new Padding(0);
            xslOpenButton.TabIndex = 1;
            xslOpenButton.UseVisualStyleBackColor = true;
            
            transformButton.Name = "transformButton";
            transformButton.Text = "Преобразовать XML";
            transformButton.Location = new Point(20, 155);
            transformButton.Size = new Size(345, 50);
            transformButton.TabIndex = 2;
            transformButton.UseVisualStyleBackColor = true;
            
            outputSaveButton.Name = "outputSaveButton";
            outputSaveButton.Text = "Сохранить";
            outputSaveButton.Location = new Point(20, 110);
            outputSaveButton.Size = new Size(100, 25);
            outputSaveButton.Margin = new Padding(0);
            outputSaveButton.TabIndex = 3;
            outputSaveButton.UseVisualStyleBackColor = true;
            
            xmlOpenDialog.Filter = "\"XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
            
            xslOpenDialog.Filter = "\"XSL files (*.xsl;*.xslt)|*.xsl;*.xslt|All files (*.*)|*.*\"";
            
            xmlPathLabel.Name = "xmlPathLabel";
            xmlPathLabel.Text = "Выберите файл XML...";
            xmlPathLabel.Location = new Point(140, 20);
            xmlPathLabel.Size = new Size(225, 25);
            xmlPathLabel.Margin = new Padding(0);
            xmlPathLabel.Padding = new Padding(10, 0, 0, 0);
            xmlPathLabel.TextAlign = ContentAlignment.MiddleLeft;
            xmlPathLabel.TabIndex = 4;
            xmlPathLabel.AutoEllipsis = true;
            
            xslPathLabel.Name = "xslPathLabel";
            xslPathLabel.Text = "Выберите файл XSL...";
            xslPathLabel.Location = new Point(140, 65);
            xslPathLabel.Size = new Size(225, 25);
            xslPathLabel.Margin = new Padding(0);
            xslPathLabel.Padding = new Padding(10, 0, 0, 0);
            xslPathLabel.TextAlign = ContentAlignment.MiddleLeft;
            xslPathLabel.TabIndex = 5;
            xslPathLabel.AutoEllipsis = true;
            
            outputPathLabel.Name = "outputPathLabel";
            outputPathLabel.Text = "Выберите директорию для сохранения";
            outputPathLabel.Location = new Point(140, 110);
            outputPathLabel.Size = new Size(225, 25);
            outputPathLabel.Margin = new Padding(0);
            outputPathLabel.Padding = new Padding(10, 0, 0, 0);
            outputPathLabel.TextAlign = ContentAlignment.MiddleLeft;
            outputPathLabel.TabIndex = 6;
            outputPathLabel.AutoEllipsis = true;
            
            outputListBox.Name = "outputListBox";
            outputListBox.Location = new Point(20, 225);
            outputListBox.Size = new Size(345, 160);
            outputListBox.Margin = new Padding(0);
            outputListBox.TabIndex = 7;
            outputListBox.FormattingEnabled = true;
            outputListBox.Items.AddRange(new object[] { "" });
            
            Name = "MainForm";
            Text = "XML Transform";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 411);
            AutoScaleDimensions = new SizeF(6F, 13F);
            Controls.Add(outputPathLabel);
            Controls.Add(outputSaveButton);
            Controls.Add(xslPathLabel);
            Controls.Add(xmlPathLabel);
            Controls.Add(xslOpenButton);
            Controls.Add(xmlOpenButton);
            Controls.Add(outputListBox);
            Controls.Add(transformButton);
            ResumeLayout(false);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
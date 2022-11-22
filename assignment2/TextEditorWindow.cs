using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace assignment2
{
    public partial class TextEditorWindow : Form
    {
        //reference to login page
        LogInScreen logInScreen;
        string name, userType, currentFile;

        public TextEditorWindow(LogInScreen logInScreen, string name, string userType)
        {
            InitializeComponent();
            this.logInScreen = logInScreen;
            this.name = name;
            this.userType = userType;


            UserName.Text = "Username: "+ name;

            if (userType == "View" )
            {
                richTextBox.Enabled = false;
                toolStripButtonBold.Enabled = false;
                toolStripButtonItalic.Enabled = false;
                toolStripButtonUnderline.Enabled = false;
                toolStripButtonUnderline.Enabled = false;
                openToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled =false;
                saveAsToolStripMenuItem.Enabled=false;

            }
            



        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0 && Single.TryParse(toolStripComboBox1.Text, out Single fontSize))
            {
                Font currentFont = richTextBox.SelectionFont;
                if (currentFont != null)
                    richTextBox.SelectionFont = new Font(currentFont.FontFamily, fontSize, currentFont.Style);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create an instance of the OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            //set properties
            dialog.Title = "Open";
            //Filter the file type to open
            dialog.Filter = "Rich Text Format files (*.rtf)|*.rtf|" +
                "Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //call the showDialog()method to show the dialog box
            DialogResult result = dialog.ShowDialog();
            //check the user response
            if (result == DialogResult.OK)
            {//get the filename
                currentFile = dialog.FileName;
                MessageBox.Show("The File Selected was:" + currentFile);
                //do something read the file content
                
            //get the file content
                LoadFile();//method below
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if there is string inside current file
            if (!string.IsNullOrEmpty(currentFile))
            {
                
                SaveFile();
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }  
        }

       

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create an instance of the openFileDialog
            SaveFileDialog saveAsFile = new SaveFileDialog();
            //Set Properties, Filter the file types
            saveAsFile.Filter = "Rich Text Format files (*.rtf)|*.rtf|" +
                "Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveAsFile.Title = "Save As";
            //call the ShowDialog()method t show the dialog box
            DialogResult dialogResult = saveAsFile.ShowDialog();
            //check the user response
            if(dialogResult == DialogResult.OK)
            {
                //do something to save the file
                currentFile = saveAsFile.FileName;
                MessageBox.Show("Your file is successfully saves in " + currentFile);
                SaveFile();// this method below , write text, and  into richText 
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            logInScreen.Show();
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
           
            ChangeFontStyle(FontStyle.Bold);
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Italic);
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Underline);
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Cut();
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
                richTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Thank you for you text here. Text Editor v2.0.0 Text editor: Yumeng Qin", "About",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveFile()
        {
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                File.WriteAllText(currentFile, richTextBox.Rtf);
            else if (fileExtension == ".txt")
                File.WriteAllText(currentFile, richTextBox.Text);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();

            richTextBox.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click( new object(), new EventArgs());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if there is string inside current file
            if (!string.IsNullOrEmpty(currentFile))
            {
                MessageBox.Show("Just save your enter", "Save", MessageBoxButtons.OKCancel);
                SaveFile();
            }
            else
            {
                //if just type not get through currentFile
                MessageBox.Show("Just save your enter", "Save", MessageBoxButtons.OKCancel);
                //saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //create an instance of the openFileDialog
            SaveFileDialog saveAsFile = new SaveFileDialog();
            //Set Properties, Filter the file types
            saveAsFile.Filter = "Rich Text Format files (*.rtf)|*.rtf|" +
                "Plain Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveAsFile.Title = "Save As";
            //call the ShowDialog()method t show the dialog box
            DialogResult dialogResult = saveAsFile.ShowDialog();
            //check the user response
            if (dialogResult == DialogResult.OK)
            {
                //do something to save the file
                currentFile = saveAsFile.FileName;
                MessageBox.Show("Your file is successfully saves in " + currentFile);
                SaveFile();// this method below , write text, and  into richText 
            }
        }

        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void topToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LoadFile()
        {
            //.GetExtension get.txt or .rtf
            string fileExtension = Path.GetExtension(currentFile);
            if (fileExtension == ".rtf")
                //use .Loadfile method, which loaf s specific type of file into the rich text box
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.RichText);
            else if (fileExtension == ".txt")
                richTextBox.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
        }




        private void TextEditorWindow_Load(object sender, EventArgs e)
        {
            
            if (userType == "View")
            {
                newToolStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                
                richTextBox.Enabled = false;
                topToolStrip.Enabled = false;
                leftToolStrip.Enabled = false;
            }
        }


        private void ChangeFontStyle(FontStyle style)
        {
            if (style != FontStyle.Bold && style != FontStyle.Italic &&
                style != FontStyle.Underline)
                throw new System.InvalidProgramException("字体格式错误");
            RichTextBox tempRichTextBox = new RichTextBox();  //将要存放被选中文本的副本  
            int curRtbStart = richTextBox.SelectionStart;
            int len = richTextBox.SelectionLength;
            int tempRtbStart = 0;
            Font font = richTextBox.SelectionFont;
            if (len <= 1 && font != null) //与上边的那段代码类似，功能相同  
            {
                if (style == FontStyle.Bold && font.Bold ||
                    style == FontStyle.Italic && font.Italic ||
                    style == FontStyle.Underline && font.Underline)
                {
                    richTextBox.SelectionFont = new Font(font, font.Style ^ style);
                }
                else if (style == FontStyle.Bold && !font.Bold ||
                         style == FontStyle.Italic && !font.Italic ||
                         style == FontStyle.Underline && !font.Underline)
                {
                    richTextBox.SelectionFont = new Font(font, font.Style | style);
                }
                return;
            }
            tempRichTextBox.Rtf = richTextBox.SelectedRtf;
            tempRichTextBox.Select(len - 1, 1); //选中副本中的最后一个文字  
                                                //克隆被选中的文字Font，这个tempFont主要是用来判断  
                                                //最终被选中的文字是否要加粗、去粗、斜体、去斜、下划线、去下划线  
            Font tempFont = (Font)tempRichTextBox.SelectionFont.Clone();

            //清空2和3  
            for (int i = 0; i < len; i++)
            {
                tempRichTextBox.Select(tempRtbStart + i, 1);  //每次选中一个，逐个进行加粗或去粗  
                if (style == FontStyle.Bold && tempFont.Bold ||
                    style == FontStyle.Italic && tempFont.Italic ||
                    style == FontStyle.Underline && tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style ^ style);
                }
                else if (style == FontStyle.Bold && !tempFont.Bold ||
                         style == FontStyle.Italic && !tempFont.Italic ||
                         style == FontStyle.Underline && !tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style | style);
                }
            }
            tempRichTextBox.Select(tempRtbStart, len);
            richTextBox.SelectedRtf = tempRichTextBox.SelectedRtf; //将设置格式后的副本拷贝给原型  
            richTextBox.Select(curRtbStart, len);
        }
        
    }
}

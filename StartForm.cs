using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBall
{
    public partial class StartForm : Form
    {
        private readonly List<Color> _basicColor = new List<Color>{ Color.White, Color.Black, Color.Blue, Color.Red, Color.Green };

        private ComboBox _comboBoxBackgraundColor;
        private ComboBox _comboxBoxBallColor;
        private TextBox _textBoxSize;
        private TextBox _textBoxSpeed;

        private Font _font2 = new Font("Arial", 10);
        private Padding _margin2 = new Padding(8, 0, 9, 0);

        public StartForm()
        {
            Text = "Start";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(230, 250);

            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Padding = new Padding(2);
            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            table.Controls.Add(new Label() { Text = "Setting", Font = new Font("Arial", 16), Dock = DockStyle.Fill });
            table.Controls.Add(new Label() 
            { 
                Text = "Backgraund color",
                Font = _font2, 
                TextAlign = ContentAlignment.BottomLeft, 
                Dock = DockStyle.Fill 
            });

            _comboBoxBackgraundColor = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "Name",
                Dock = DockStyle.Fill,
                Margin = _margin2
            };
            foreach (var color in _basicColor)
                _comboBoxBackgraundColor.Items.Add(color);
            _comboBoxBackgraundColor.SelectedIndex = 1;

            table.Controls.Add(_comboBoxBackgraundColor, 0, 2);
            table.Controls.Add(new Label() 
            {
                Text = "Ball color",
                Font = _font2,
                TextAlign = ContentAlignment.BottomLeft,
                Dock = DockStyle.Fill
            });
            
            _comboxBoxBallColor = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "Name",
                Dock = DockStyle.Fill,
                Margin = _margin2
            };
            foreach (var color in _basicColor)
                _comboxBoxBallColor.Items.Add(color);
            _comboxBoxBallColor.SelectedIndex = 3;

            table.Controls.Add(_comboxBoxBallColor);
            table.Controls.Add(new Label()
            {
                Text = "Ball size (px)",
                Font = _font2,
                TextAlign = ContentAlignment.BottomLeft,
                Dock = DockStyle.Fill
            });

            _textBoxSize = new TextBox()
            {
                Text = "100",
                Dock = DockStyle.Fill,
                Margin = _margin2
            };
            _textBoxSize.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            table.Controls.Add(_textBoxSize);
            table.Controls.Add(new Label()
            {
                Text = "Ball speed (px/frame)",
                Font = _font2,
                TextAlign = ContentAlignment.BottomLeft,
                Dock = DockStyle.Fill
            });

            _textBoxSpeed = new TextBox()
            {
                Text = "8",
                Dock = DockStyle.Fill,
                Margin = _margin2
            };
            _textBoxSize.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            table.Controls.Add(_textBoxSpeed);

            var startButton = new Button()
            {
                Text = "Start",
                TextAlign = ContentAlignment.MiddleCenter
            };
            startButton.Click += (sender, args) => StartSimulation();

            table.Controls.Add(startButton);

            KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    StartSimulation();
            };
        }
        private void StartSimulation()
        {
            if (int.TryParse(_textBoxSize.Text, out int ballSize) && int.TryParse(_textBoxSpeed.Text, out int ballSpeed))
            {
                var newForm = new SimulationForm(new Setup((Color)_comboBoxBackgraundColor.SelectedItem, (Color)_comboxBoxBallColor.SelectedItem, ballSize, ballSpeed));
                newForm.Show();
            }
            else
            {
                MessageBox.Show("The size and speed must be in numbers", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBall
{
    public partial class SimulationForm : Form
    {
        private Setup _setup;
        private int _margin;

        private int _distans;
        private int _speed;
        private int _direction = 1;// 1 - forward; -1 - forward

        public SimulationForm(Setup setup)
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            BackColor = setup.BackgroundColor;

            KeyDown += (sender, args) =>
            {     
                switch (args.KeyData)
                {
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.Up:
                        _speed += _speed <= 50 ? 1 : 0;
                        break;
                    case Keys.Down:
                        _speed -= _speed > 0 ? 1 : 0;
                        break;
                }
            };

            _setup = setup;
            _speed = setup.BallSpeed;
            _margin = _setup.BallSize + 10;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ClientSize.Width / 2 + _distans >= ClientSize.Width - _margin)
                _direction = -1;
            if (ClientSize.Width / 2 + _distans <= _margin)
                _direction = 1;
            _distans += _speed * _direction;
            
            e.Graphics.Clear(_setup.BackgroundColor);
            e.Graphics.FillEllipse(
                new SolidBrush(_setup.BallColor),
                (ClientSize.Width / 2 - _setup.BallSize / 2) + _distans,
                ClientSize.Height / 2 - _setup.BallSize / 2,
                _setup.BallSize, _setup.BallSize);
            Invalidate();
        }
    }
}

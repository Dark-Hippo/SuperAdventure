using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Coded from http://scottlilly.com/learn-c-by-building-a-simple-rpg-index/
/// currently up to 09.1
/// </summary>
namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        public SuperAdventure()
        {
            InitializeComponent();

            SetUpNewPlayer();

            SetUpFields();

        }

        private void SetUpNewPlayer()
        {
            _player = new Player(10, 10, 20, 0, 1);
        }

        private void SetUpFields()
        {
            this.lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            this.lblGold.Text = _player.Gold.ToString();
            this.lblExperience.Text = _player.ExperiencePoints.ToString();
            this.lblLevel.Text = _player.Level.ToString();
        }
    }
}

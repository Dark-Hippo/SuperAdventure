using Engine;
using System.Windows.Forms;

/// <summary>
/// Coded from http://scottlilly.com/learn-c-by-building-a-simple-rpg-index/
/// currently up to 14.1
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

        private void btnNorth_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEast_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSouth_Click(object sender, System.EventArgs e)
        {

        }

        private void btnWest_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUseWeapon_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, System.EventArgs e)
        {

        }
    }
}

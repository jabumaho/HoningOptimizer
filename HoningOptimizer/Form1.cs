using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace HoningOptimizer
{
    public partial class Form1 : Form
    {
        private int lvl = 0;
        private double chance = 0;
        private double costs = 0;
        private double base_gold_cost = 0;
        private HoningData data;
        private Optimizer opt;
        private string dataPath = Application.UserAppDataPath + "\\golddata.json";
        
        public Form1()
        {
            InitializeComponent();
            List<Lvl> lvls = new List<Lvl>();
            for(int i = 7; i <= 15; i++)
                lvls.Add(new Lvl() {Text = i.ToString(), Value = i});
            lvl_picker.DataSource = lvls;
            lvl_picker.DisplayMember = "Text";
            lvl_picker.ValueMember = "Value";

            data = new HoningData();
            opt = new Optimizer(data);

            string json = "";
            if (File.Exists(dataPath))
            {
                json = File.ReadAllText(dataPath);
                UserData d = JsonSerializer.Deserialize<UserData>(json);
                stonegold.Text = d.stoneGold.ToString();
                leapgold.Text = d.leapGold.ToString();
                fusiongold.Text = d.fusionGold.ToString();
                gracegold.Text = d.graceGold.ToString();
                blessinggold.Text = d.blessingGold.ToString();
                protgold.Text = d.protGold.ToString();
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            lvl = (int) lvl_picker.SelectedValue;
            
            try
            {
                if(rbtn_armor.Checked)
                    base_gold_cost = data.armorcosts[lvl][0]*(Convert.ToDouble(stonegold.Text)/10) + 
                                     data.armorcosts[lvl][1]*Convert.ToInt32(leapgold.Text) + 
                                     data.armorcosts[lvl][2]*Convert.ToInt32(fusiongold.Text) + 70;
                if(rbtn_weapon.Checked)
                    base_gold_cost = data.weaponcosts[lvl][0]*(Convert.ToDouble(stonegold.Text)/10) + 
                                     data.weaponcosts[lvl][1]*Convert.ToInt32(leapgold.Text) + 
                                     data.weaponcosts[lvl][2]*Convert.ToInt32(fusiongold.Text) + 120;

                List<double> result = opt.optimize(base_gold_cost, lvl, Convert.ToInt32(gracegold.Text),
                    Convert.ToInt32(blessinggold.Text), Convert.ToInt32(protgold.Text));
                lbl_grace.Text = result[0].ToString();
                lbl_blessing.Text = result[1].ToString();
                lbl_protection.Text = result[2].ToString();
                lbl_goldcost.Text = Math.Ceiling(result[3]).ToString();
                
                save();
            }
            catch (Exception exception)
            {
                MessageBox.Show("IDIOT SANDWICH");
            }
        }

        public void save()
        {
            try
            {
                UserData ud = new UserData()
                {
                    stoneGold = Convert.ToInt32(stonegold.Text),
                    leapGold = Convert.ToInt32(leapgold.Text),
                    fusionGold = Convert.ToInt32(fusiongold.Text),
                    blessingGold = Convert.ToInt32(blessinggold.Text),
                    graceGold = Convert.ToInt32(gracegold.Text),
                    protGold = Convert.ToInt32(protgold.Text)
                };
                string json = JsonSerializer.Serialize(ud);
                File.WriteAllText(dataPath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }

    public class UserData
    {
        public int stoneGold{ get; set; }
        public int leapGold{ get; set; }
        public int fusionGold{ get; set; }
        public int graceGold{ get; set; }
        public int blessingGold{ get; set; }
        public int protGold{ get; set; }
    }
    
    public class Lvl
    {
        public Lvl() {}
        public int Value { set; get; }
        public string Text { set; get; }
    }
}
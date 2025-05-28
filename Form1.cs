using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIzza
{
    public partial class Pizza : Form
    {
        public Pizza()
        {
            InitializeComponent();
        }

        float CalculateSizePrice()
        {
            if(rbSmall.Checked) { return Convert.ToSingle(rbSmall.Tag); }
            else if (rbMidium.Checked) { return Convert.ToSingle(rbMidium.Tag); }
            else  { return Convert.ToSingle(rbLarge.Tag); }
        }

        float CalculateCrustPrice()
        {
            if (rbThinCrust.Checked) { return Convert.ToSingle(rbThinCrust.Tag); }
            else { return Convert.ToSingle(rbThickCrust.Tag); }
        }

        float CalculateToppingsPrice()
        {
            float ToppingsPrice = 0;

            if (chkCheese.Checked) { ToppingsPrice += Convert.ToSingle(chkCheese.Tag); }
            if (chkMushrooms.Checked) { ToppingsPrice += Convert.ToSingle(chkMushrooms.Tag); }
            if (chkOlives.Checked) { ToppingsPrice += Convert.ToSingle(chkOlives.Tag); }
            if (chkOnions.Checked) { ToppingsPrice += Convert.ToSingle(chkOnions.Tag); }
            if (chkTomatoes.Checked) { ToppingsPrice += Convert.ToSingle(chkTomatoes.Tag); }
            if (chkPeppers.Checked) { ToppingsPrice += Convert.ToSingle(chkPeppers.Tag); }
            
            return ToppingsPrice;

        }

        float CalculateTotalPrice()
        {
            return CalculateSizePrice() + CalculateCrustPrice() + CalculateToppingsPrice();
        }

        void UpdateTotalPrice()
        {
            lbTotalPrice.Text = CalculateTotalPrice().ToString() + " $";
        }

        void UpdateWhereToEat()
        {
            if(rbTakeAway.Checked) { lbWhereToEat.Text = "Take Away"; return; }
            else { lbWhereToEat.Text = "Eat in"; return; }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            lbToppings.Text = "";
            if (chkCheese.Checked) { lbToppings.Text += "Extra Cheese, "; }
            if (chkTomatoes.Checked) { lbToppings.Text += "Tomatoes, "; }
            if (chkOlives.Checked) { lbToppings.Text += "Olives, "; }
            if (chkOnions.Checked) { lbToppings.Text += "Onion, "; }
            if (chkMushrooms.Checked) { lbToppings.Text += "Mushrooms, "; }
            if (chkPeppers.Checked) { lbToppings.Text += "Green Peppers, "; }

            if (lbToppings.Text == "")
                lbToppings.Text = "No Toppings";
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if(rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }
            if (rbMidium.Checked)
            {
                lbSize.Text = "Midium";
                return;
            }
            if (rbLarge.Checked)
            {
                lbSize.Text = "Large";
                return;
            }
        }

        void UpadatCrust()
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked) { lbCrust.Text = "Thin Crust"; return; }
            else{ lbCrust.Text = "Thick Crust"; return; }
        }

        void Reset()
        {
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            UpdateTotalPrice();
            UpdateWhereToEat();
            UpdateToppings();
            UpdateSize();
            UpadatCrust();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to order ?", "Confirm Order",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Succecfully", "Succecfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbSize.Enabled = false;
                gbCrust.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMidium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpadatCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpadatCrust();
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gbSize.Enabled = true;
            gbCrust.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbSmall.Checked = true;

            rbThickCrust.Checked = false;
            rbThinCrust.Checked = false;

            chkCheese.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkOlives.Checked = false;
            chkOnions.Checked = false;
            chkPeppers.Checked = false;

            rbTakeAway.Checked = false;
            rbEatIn.Checked = false;

            Reset();
        }

        private void Pizza_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}

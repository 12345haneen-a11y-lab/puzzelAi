using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<puzzel> puzzels = new List<puzzel>();

        public Form1()
        {
            InitializeComponent();
            init();
            shuffle();
        }
        void init()
        {
            puzzels.Add(button1);
            puzzels.Add(button2);
            puzzels.Add(button3);
            puzzels.Add(button4);
            puzzels.Add(button5);
            puzzels.Add(button6);
            puzzels.Add(button7);
            puzzels.Add(button8);
            puzzels.Add(button9);
            place(puzzels[0], null, button2, null, button4);
            place(puzzels[1], button1, button3, null, button5);
            place(puzzels[2], button2, null, null, button6);
            place(puzzels[3], null, button5, button1, button7);
            place(puzzels[4], button4, button6, button2, button8);
            place(puzzels[5], button5, null, button3, button9);
            place(puzzels[6], null, button8, button4, null);
            place(puzzels[7], button7, button9, button5, null);
            place(puzzels[8], button8, null, button6, null);


        }
        void place(puzzel x, puzzel left, puzzel right, puzzel up, puzzel down)
        {
            x.left = left;
            x.right = right;
            x.up = up;
            x.down = down;

        }
        void shuffle()
        {
           List<int> nums = new List<int> { 1,2,3,4,5,6,7,8,9 };
            Random r = new Random();
            nums = nums.OrderBy(x=>r.Next()).ToList();
            for (int i = 0; i < puzzels.Count; i++)
            {
                if (nums[i]==9)
                {
                    puzzels[i].Text = "";
                }
                else
                {
                    puzzels[i].Text = nums[i].ToString();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((puzzel)sender).left!=null && ((puzzel)sender).left.Text=="")
            {
                swap(((puzzel)sender).left, (puzzel)sender);
            }
            else if (((puzzel)sender).right != null && ((puzzel)sender).right.Text == "")
            {
                swap(((puzzel)sender).right, (puzzel)sender);

            }
            else if (((puzzel)sender).up != null && ((puzzel)sender).up.Text == "")
            {
                swap(((puzzel)sender).up, (puzzel)sender);

            }
            else if (((puzzel)sender).down != null && ((puzzel)sender).down.Text == "")
            {
                swap(((puzzel)sender).down, (puzzel)sender);

            }
            if (goal())
            {
                MessageBox.Show("you win");
            }
        }
        void swap(puzzel a, puzzel b)
        {
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = temp;

        }
        bool goal()
        {
            for (int i = 0; i < puzzels.Count; i++)
            {
                if (!(i<8 &&  puzzels[i].Text ==(i+1).ToString() || i == 8 && puzzels[i].Text ==""))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

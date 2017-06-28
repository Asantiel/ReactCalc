using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactCalc;
using ReactCalc.Models;

namespace WinCalc
{
    public partial class frm_Main : Form
    {
        private Calc Calc { get; set; } 

        public frm_Main()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calc = new Calc();

            var operations = Calc.Operations;

            lbOperations.DataSource = operations;
            lbOperations.DisplayMember = "Name";

            lbOperations.SelectedIndex = 0;
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var displayOper = lbOperations.SelectedItem as IDisplayOperation;
            if (displayOper != null)
            {
                lblDescription.Text = string.Format("Автор {0}{1}Описание: {2}",
                    displayOper.Author,
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(displayOper.Description) ? displayOper.Description : ""
                    );
            }
        }

        private void frm_Main_Activated(object sender, EventArgs e)
        {
            tbx.Focus();
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            //определям операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            var displayOper = oper as IDisplayOperation;

            if (displayOper.DisplayOper == true)
            {
                return;
            }
            else
            {
                FastExec(oper);
            }
        }



        private void FastExec(IOperation oper)
        {

            var x = Calc.ToDouble(tbx.Text);
            var y = Calc.ToDouble(tby.Text);

            try
            {
                //вычисляем
                var result = Calc.Execute(oper.Execute, new[] {x, y});

                var displayOper = oper as IDisplayOperation;

                //if (displayOper.DisplayOper == true)
                //{
                //    return;
                //}
                //else
                //{
                    string operName;
                    operName = displayOper != null
                     ? operName = displayOper.DisplayName
                     : operName = oper.Name;
                    //возвращаем результат
                    lblResult.Text = string.Format("{0}={1}{2}", operName, result, Environment.NewLine);
                //}
            }
            catch (Exception ex)
            {
                lblResult.Text = string.Format("Опаньки: {0}", ex.Message);
            }
        }

        private void tby_TextChanged(object sender, EventArgs e)
        {
            //определям операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            var displayOper = oper as IDisplayOperation;

            if (displayOper.DisplayOper == true)
            {
                return;
            }
            else
            {
                FastExec(oper);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //определям операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            FastExec(oper);
        }

        private void tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tby.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                //определям операцию
                var oper = lbOperations.SelectedItem as IOperation;
                if (oper == null)
                {
                    lblResult.Text = "Выберите нормальную операцию";
                    return;
                }

                FastExec(oper);
            }
        }

        private void tby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tbx.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                //определям операцию
                var oper = lbOperations.SelectedItem as IOperation;
                if (oper == null)
                {
                    lblResult.Text = "Выберите нормальную операцию";
                    return;
                }

                FastExec(oper);
            }
        }
    }
}

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

        private IOperation operation { get; set; }

        private DateTime? LastPressTime { get; set; }

        private IOperation Operation 
        {
            get
            {
                return operation;
            }

            set
            {
                operation = value;
                DispOperation = value as IDisplayOperation;
            } 
        }

        private IDisplayOperation DispOperation { get; set; }



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
            DispOperation = lbOperations.SelectedItem as IDisplayOperation;
            if (DispOperation != null)
            {
                lblDescription.Text = string.Format("Автор {0}{1}Описание: {2}",
                    DispOperation.Author,
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(DispOperation.Description) ? DispOperation.Description : ""
                    );
            }

            LastPressTime = DateTime.Now;
            timer1.Start();
            
        }

        private void frm_Main_Activated(object sender, EventArgs e)
        {
            tbx.Focus();
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            //определям операцию
            Operation = lbOperations.SelectedItem as IOperation;
            if (Operation == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            DispOperation = Operation as IDisplayOperation;

            if (DispOperation.DisplayOper == true)
            {
                return;
            }
            else
            {
                FastExec(Operation);
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

                DispOperation = oper as IDisplayOperation;

                    string operName;
                    operName = DispOperation != null
                     ? operName = DispOperation.DisplayName
                     : operName = oper.Name;
                    //возвращаем результат
                    lblResult.Text = string.Format("{0}={1}{2}", operName, result, Environment.NewLine);
            }
            catch (Exception ex)
            {
                lblResult.Text = string.Format("Опаньки: {0}", ex.Message);
            }
        }

        private void tby_TextChanged(object sender, EventArgs e)
        {
            //определям операцию
            var Operation = lbOperations.SelectedItem as IOperation;
            if (Operation == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            DispOperation = Operation as IDisplayOperation;

            if (DispOperation.DisplayOper == true)
            {
                return;
            }
            else
            {
                FastExec(Operation);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //определям операцию
            Operation = lbOperations.SelectedItem as IOperation;
            if (Operation == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            FastExec(Operation);
        }

        private void tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tby.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                LastPressTime = DateTime.Now;
                timer1.Start();
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
                LastPressTime = DateTime.Now;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LastPressTime.HasValue)
            {
                var diffTime = DateTime.Now - LastPressTime.Value;

                if (diffTime.TotalMilliseconds >= 200)
                {
                    Calculate(); // переделать FastExec
                    LastPressTime = null;
                    timer1.Stop();
                }
            }
        }

         private void Calculate()
        {
            // определяем операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            // определяем входные данные
            var x = Calc.ToDouble(tbx.Text);
            var y = Calc.ToDouble(tby.Text);
            try
            {
                // вычисляем 
                var result = Calc.Execute(oper.Execute, new[] { x, y });


                string operName = DispOperation != null
                    ? DispOperation.DisplayName
                    : oper.Name;
                // возвращаем результат
                lblResult.Text = string.Format("{0} = {1} {2}", operName, result, Environment.NewLine);
            }
            catch (Exception ex)
            {
                lblResult.Text = "Опаньки: {ex.Message}";
            }
        }
    }
}

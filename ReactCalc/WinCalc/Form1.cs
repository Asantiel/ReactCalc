using ReactCalc;
using ReactCalc.Models;
//using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        private Calc Calc { get; set; }

        private IOperation operation { get; set; }

        private IOperation Operation {
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
        
        private DateTime? LastPressTime { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Calc = new Calc();

            var operations = Calc.Operations;

            lbOperations.DataSource = operations;
            lbOperations.DisplayMember = "Name";

            lbOperations.SelectedIndex = 0;

            lblResult.Text = "";

            timer1.Interval = 300;
        }

        private void Calculate()
        {
            // определяем операцию
            if (Operation == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            // определяем входные данные
            var x = Calc.ToNumber(tbX.Text);
            var y = Calc.ToNumber(tbY.Text);

            try
            {
                // вычисляем
                var result = Calc.Execute(Operation.Execute, new[] { x, y });
                
                var operName = DispOperation != null
                    ? DispOperation.DisplayName
                    : Operation.Name;

                // возвращаем результат
                lblResult.Text = $"{result}";
            }
            catch (Exception ex)
            {
                lblResult.Text = string.Format("Опаньки: {0}", ex.Message);
            }
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescription.Text = "";

            Operation = lbOperations.SelectedItem as IOperation;

            if (DispOperation != null)
            {
                lblDescription.Text = string.Format("Автор: {0}{1}Описание: {2}",
                    DispOperation.Author,
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(DispOperation.Description) ? DispOperation.Description : "нет"
                    );
            }
            LastPressTime = DateTime.Now;
            timer1.Start();
        }

        private void tbX_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                tbY.Focus();
            }
            else
            {
                LastPressTime = DateTime.Now;
                timer1.Start();
            }
        }

        private void tbY_KeyUp(object sender, KeyEventArgs e)
        {
            LastPressTime = DateTime.Now;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LastPressTime.HasValue)
            {
                var diffTime = DateTime.Now - LastPressTime.Value;

                if (diffTime.TotalMilliseconds >= 200)
                {
                    Calculate();
                    LastPressTime = null;
                    timer1.Stop();
                }
            }
        }
    }
}

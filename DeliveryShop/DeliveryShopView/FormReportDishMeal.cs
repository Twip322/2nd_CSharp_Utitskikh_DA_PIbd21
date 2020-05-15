using System;
using System.Windows.Forms;
using Unity;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;

namespace AbstractShopView
{
    public partial class FormReportDishMeal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportDishMeal(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;

        }
        private void ButtonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetProductComponent();
                ReportDataSource source = new ReportDataSource("DataSetDishMeal", dataSource);
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}

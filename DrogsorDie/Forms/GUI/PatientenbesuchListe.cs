using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DrogsorDie.Forms.GUI
{
    public partial class PatientenbesuchListe : Form
    {
        private Logik.Patient Patient;
        public  PatientenbesuchListe(Logik.Patient patient)
        {
            Patient = patient;
            InitializeComponent();
            refreshDataGrid();
            
        }

        private void refreshDataGrid()
        {
            try
            {
                List<Logik.Patientenbesuch> bPatientenbesuches =
                    Logik.PatientenbesuchListe.getPatientenbesuche(Patient);
                int i = 0;
                foreach (var bpatientenbesuch in bPatientenbesuches)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[i].Cells[0].Value = bPatientenbesuches[i].Id;
                    dataGridView1.Rows[i].Cells[1].Value = bPatientenbesuches[i].EinlieferungsZeitpunkt.ToString();
                    i++;
                }
            }
            catch (Exception e)
            {
                
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Patientenbesuch patientform = new Patientenbesuch( Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            patientform.Show();
        }
    }
}